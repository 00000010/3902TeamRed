using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.Rectangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace sprint0.Commands
{
    internal class LinkStandingLeftCommand : Interfaces.ICommand
    {
        private Game1 game;
        public LinkStandingLeftCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            SpriteRectangle sR = new LinkRectangle();
            sR = new Left(sR);
            game.player.SourceRectangle = sR.SourceRectangle(sR);

            game.player.Frame = 0;
            game.player.Velocity = new Vector2(0, 0);
        }
    }
}
