using Microsoft.Xna.Framework;
using System;
using System.Reflection;
using System.Windows.Input;

namespace sprint0
{
    internal class LinkRunningRightCommand : ICommand
    {
        private Game1 game;
        public LinkRunningRightCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            SpriteRectangle sR = new LinkRectangle();
            sR = new Right(sR);
            sR = new Running(sR);
            game.player.SourceRectangle = sR.SourceRectangle(sR);

            game.player.Frame = 0;
            game.player.Velocity = new Vector2(1, 0);
        }
    }
}
