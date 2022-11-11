using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace sprint0
{
    internal class LoadLevelCommand : ICommand
    {
        private Game1 game;
        private LevelLoader loader;

        public LoadLevelCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            loader = game.loader;
            loader.LoadLevel("Dungeon1"); //Change string, this is testing
        }
    }

    internal class ReloadLevelCommand : ICommand
    {
        private Game1 game;
        private LevelLoader loader;

        public ReloadLevelCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            loader = game.loader;
            loader.UnloadRoom();
            loader.LoadLevel("Dungeon1"); //Change string, This is testing
        }
    }
}
