using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Creator
{
    public class CreateNewRoomCommand : ICommand
    {
        Game1 game;
        object obj;
        public CreateNewRoomCommand(Game1 game, object obj)
        {
            this.game = game;
            this.obj = obj;
        }

        public void Execute()
        {
            Debug.WriteLine("Testing for a block change");
            game.creator.currentObject = obj;
        }
    }
}
