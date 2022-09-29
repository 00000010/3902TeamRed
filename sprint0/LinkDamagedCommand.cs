using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace sprint0
{
    internal class LinkDamagedCommand : ICommand
    {
        private Game1 game;

        public LinkDamagedCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            SpriteRectangle sR = new LinkRectangle(
                game.player.SourceRectangle[0].X,
                game.player.SourceRectangle[0].Y,
                game.player.SourceRectangle.Length);
            sR = new Damaged(sR);
            game.player.SourceRectangle = sR.SourceRectangle(sR);

            game.player.Frame = 0;
        }
    }
}
