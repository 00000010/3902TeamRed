using Microsoft.Xna.Framework;
using System;
using System.Reflection;
using System.Windows.Input;

namespace sprint0
{
    internal class LuigiRunningRightStillCommand : ICommand
    {
        private Game1 game;
        public LuigiRunningRightStillCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.player.SourceRectangle = SpriteRectangle.LuigiRunningRight;
            game.player.Frame = 0;
            game.player.Velocity = new Vector2(0, 0);
        }
    }
}
