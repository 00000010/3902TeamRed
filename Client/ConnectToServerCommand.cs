using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class ConnectToServerCommand : ICommand
    {
        private Game1 game;
        ConnectToServerCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            this.game.client = new Client();
            this.game.client.StartClient();
            this.game.updateables.Add(this.game.client);
        }
    }
}
