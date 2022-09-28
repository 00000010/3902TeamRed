using Microsoft.Xna.Framework;
using System;
using System.Reflection;
using System.Windows.Input;

namespace sprint0
{
    internal class LinkRunningLeftCommand : ICommand
    {
        private Game1 game;
        public LinkRunningLeftCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            SpriteRectangle sR = new LinkRectangle();
            sR = new Left(sR);
            sR = new Running(sR);
            game.player.SourceRectangle = sR.SourceRectangle(sR);
            
            game.player.Frame = 0;
            game.player.Velocity = new Vector2(-1, 0);
        }
    }
}
