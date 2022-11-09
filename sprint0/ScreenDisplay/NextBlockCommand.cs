using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class NextBlockCommand : ICommand
    {
        private Game1 game;
        public NextBlockCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.manager.RemoveObject(game.block);

            if (game.block is ZeldaBlackBlock)
            {
                game.block = BlockFactory.Instance.ZeldaGreenBlock(game.block.Position);
            }
            else if (game.block is ZeldaGreenBlock)
            {
                game.block = BlockFactory.Instance.ZeldaPurpleBlock(game.block.Position);
            }
            else if (game.block is ZeldaPurpleBlock)
            {
                game.block = BlockFactory.Instance.ZeldaBlackBlock(game.block.Position);
            }
            
            game.manager.AddObject(game.block);           
        }
    }
}
