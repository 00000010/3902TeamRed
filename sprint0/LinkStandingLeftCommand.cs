using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace sprint0
{
    internal class LinkStandingLeftCommand : ICommand
    {
        private Game1 game;
        public LinkStandingLeftCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if (this.game.player is Sprite)
            { 
                Sprite player = (Sprite)this.game.player;
                player.SourceRectangle = SpriteRectangle.LinkStandingLeft;
                player.Frame = 0;
                player.Velocity = new Vector2(0, 0);
            }
        }
    }
}
