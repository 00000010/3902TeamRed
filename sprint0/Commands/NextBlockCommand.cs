using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0.Interfaces;

namespace sprint0.Commands
{
    public class NextBlockCommand : Interfaces.ICommand
    {
        private Game1 game;
        public NextBlockCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.currBlockIndex++;
            if (game.currBlockIndex >= game.blocks.Count)
            {
                game.currBlockIndex = 0;
            }
            game.block.SourceRectangle = game.blocks[game.currBlockIndex].SourceRectangle;
            game.block.Texture = game.blocks[game.currBlockIndex].Texture;
        }
    }
}

