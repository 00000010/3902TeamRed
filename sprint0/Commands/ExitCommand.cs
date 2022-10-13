using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using sprint0.Interfaces;

namespace sprint0
{
    internal class ExitCommand : Interfaces.ICommand
    {
        private Game1 game;
        public ExitCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            this.game.Exit();
        }
    }
}
