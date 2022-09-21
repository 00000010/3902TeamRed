using Microsoft.Xna.Framework;
using System;
using System.Reflection;
using System.Windows.Input;

namespace sprint0
{
    internal class LinkRunningForwardCommand : ICommand
    {
        private Game1 game;
        public LinkRunningForwardCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if (this.game.player is Sprite)
            {
                Sprite player = (Sprite)this.game.player;

                SpriteRectangle sR = new LinkRectangle();
                sR = new Running(sR);
                player.SourceRectangle = sR.SourceRectangle(sR);
                player.Frame = 0;
                player.Velocity = new Vector2(0, 1);
            }
        }
    }
}
