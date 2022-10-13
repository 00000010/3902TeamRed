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
    internal class LinkStandingLeftDamagedCommand : Interfaces.ICommand
    {
        private Game1 game;
        public LinkStandingLeftDamagedCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if (game.player is Sprite)
            {
                Sprite player = game.player;

                SpriteRectangle sR = new LinkRectangle();
                sR = new Left(sR);
                sR = new Damaged(sR);
                player.SourceRectangle = sR.SourceRectangle(sR);

                player.Frame = 0;
                player.Velocity = new Vector2(0, 0);
            }
        }
    }
}
