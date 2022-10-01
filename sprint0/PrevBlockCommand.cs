using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class PrevBlockCommand : ICommand
    {
        private Game1 game;
        public PrevBlockCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.currBlockIndex--;
            if (game.currBlockIndex < 0)
            {
                game.currBlockIndex = game.blocks.Count-1;
            }
            game.block.SourceRectangle = game.blocks[game.currBlockIndex].SourceRectangle;
            game.block.Texture = game.blocks[game.currBlockIndex].Texture;
        }
    }
}
