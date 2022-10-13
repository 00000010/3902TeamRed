using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using sprint0.Rectangles;
using System;
using System.Reflection;
using System.Windows.Input;

namespace sprint0.Commands
{
    internal class LinkRunningRightCommand : Interfaces.ICommand
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
