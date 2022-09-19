using Lidgren.Network;
using Microsoft.Xna.Framework.Input;
using NVorbis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LidgrenServer
{
    internal class Server
    {
        private NetServer server;
        private List<NetPeer> clients;

        int running = 0; // temp variable to hold player state

        enum MessageType { END_OF_MESSAGE = 99, REQUEST_UPDATE = 1, SEND_UPDATE = 2, KEY = 3 } // move to static class


        public void StartServer()
        {
            NetPeerConfiguration config = new NetPeerConfiguration("lidgren");
            config.Port = 6969;

            server = new NetServer(config);
            server.Start();

            if (server.Status == NetPeerStatus.Running)
            {
                Debug.WriteLine("Server is running on port " + config.Port);
            }

            clients = new List<NetPeer>(); // change this to ordered list to keep track of players?
        }

        public void ReadMessages()
        {
            NetIncomingMessage message;
            bool readMessages = true;

            while (readMessages)
            {
                while ((message = server.ReadMessage()) != null)
                {
                    switch (message.MessageType)
                    {
                        case NetIncomingMessageType.Data:
                            {
                                Debug.WriteLine(BitConverter.ToString(message.Data));

                                MessageType type = (MessageType)message.ReadInt32();
                                IPAddress ip = message.SenderEndPoint.Address;
                                int port = message.SenderEndPoint.Port;

                                
                                switch (type)
                                {
                                    case MessageType.REQUEST_UPDATE:
                                        {
                                            int packet = message.ReadInt32();
                                            Debug.WriteLine("UPDATE from {0}:{1} packet {2}", ip, port, packet);
                                            ReadUpdate(message);
                                            SendUpdate(message.SenderConnection, packet);
                                            break;
                                        }
                                    default:
                                        {
                                            Debug.WriteLine("Unknown byte");
                                            break;
                                        }
                                }
 
                                break;
                            }
                        case NetIncomingMessageType.StatusChanged:
                            {
                                Debug.WriteLine(message.SenderConnection.Status);
                                break;
                            }
                        default:
                            {
                                Debug.WriteLine("Unhandled message type: {message.MessageType}");
                                break;
                            }
                    }
                    server.Recycle(message);
                }
            }
        }

        private void SendUpdate(NetConnection connection, int packet)
        {
            NetOutgoingMessage out_message = server.CreateMessage();

            out_message.Write((int)MessageType.SEND_UPDATE);
            out_message.Write(packet);
            out_message.Write(running);
            out_message.Write((int)MessageType.END_OF_MESSAGE);

            server.SendMessage(out_message, connection, NetDeliveryMethod.ReliableOrdered);
            server.FlushSendQueue();
        }

        private void ReadUpdate(NetIncomingMessage message)
        {
            while (message.PeekInt32() != (int)MessageType.END_OF_MESSAGE)
            {
                Keys key = (Keys)message.ReadInt32();
                if (key == Keys.D1)
                {
                    running = 0;
                }
                if (key == Keys.D3)
                {
                    running = 1;
                }

                Debug.WriteLine(key);
            }
        }
    }
}
