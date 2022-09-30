using sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sprint0
{
    public class PrevItemCommand : ICommand
    {
        private Game1 game;
        public PrevItemCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.currItemIndex--;
            if (game.currItemIndex < 0)
            {
                game.currItemIndex = game.items.Count-1;
            }
            game.item.SourceRectangle = game.items[game.currItemIndex].SourceRectangle;
            game.item.Texture = game.items[game.currItemIndex].Texture;
        }
    }
}

