using Lidgren.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    enum MessageType { END_OF_MESSAGE = 99, REQUEST_UPDATE = 1, SEND_UPDATE = 2, KEY = 3 } // move to static class
    public class Client : IUpdateable
    {
        private NetClient client;
        public bool Connected { get; set; }
        public List<Keys> KeysPressed { get; set; } // keys currently being pressed
        
        int packet;


        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();
        
        public Client()
        {
            Connected = false;
            packet = 0;
            KeysPressed = new List<Keys>();
        }

        public void StartClient()
        {
            NetPeerConfiguration config = new NetPeerConfiguration("lidgren");
            config.AutoFlushSendQueue = false;
            config.LocalAddress = IPAddress.Parse("127.0.0.1");
            client = new NetClient(config);
            client.Start();

            string ip = "127.0.0.1";
            int port = 6969;

            client.Connect(ip, port);

            NetIncomingMessage connection_message;

            while ((connection_message = client.ReadMessage()) == null)
            {
                Debug.WriteLine("Waiting on connection...");
                System.Threading.Thread.Sleep(100);
            }
            Debug.WriteLine(BitConverter.ToString(connection_message.Data));
            Debug.WriteLine("Connected to {0}:{1}.", connection_message.SenderEndPoint.Address, connection_message.SenderEndPoint.Port);
            client.ReadMessage(); // this message is some sort of ack from the server and can be ignored for now

            Connected = true;
        }

        public void Update(GameTime gameTime)
        { 
            client.SendMessage(UpdateMessage(), NetDeliveryMethod.ReliableOrdered);
            client.FlushSendQueue();
            ReadLatestMessage();
        }

        public NetOutgoingMessage UpdateMessage()
        {
            NetOutgoingMessage out_message = client.CreateMessage();

            out_message.Write((int)MessageType.REQUEST_UPDATE);
            out_message.Write(packet);
            packet++;
            
            foreach (Keys key in KeysPressed)
            {
                out_message.Write((int)key);
            }
            KeysPressed.Clear();


            out_message.Write((int)MessageType.END_OF_MESSAGE);

            return out_message;
        }

        public void ReadLatestMessage()
        {
            NetIncomingMessage in_message;
            NetIncomingMessage next_message;

            if ((in_message = client.ReadMessage()) != null)
            {
                // make sure we have the most recent message
                while ((next_message = client.ReadMessage()) != null)
                {
                    in_message = next_message;
                }

                Debug.WriteLine(BitConverter.ToString(in_message.Data));

                MessageType type = (MessageType)in_message.ReadInt32();
                IPAddress ip = in_message.SenderEndPoint.Address;
                int port = in_message.SenderEndPoint.Port;

                if (type == MessageType.SEND_UPDATE)
                {
                    Debug.WriteLine("UPDATE from {0}:{1} for {2}", ip, port, in_message.ReadInt32());
                    Debug.WriteLine("running: {0} {1}", in_message.ReadInt32(), (MessageType)in_message.ReadInt32());
                }
                else
                {
                    Debug.WriteLine("Unknown int32 from {0}:{1}", ip, port);
                }

                client.Recycle(in_message);
            }
        }

        public void Disconnect()
        {
            client.Disconnect("disconnected");
        }
    }
}
