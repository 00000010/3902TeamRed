using System.Xml.Schema;

namespace LidgrenServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var server = new Server();
            server.StartServer();
            server.ReadMessages();
        }
    }
}
