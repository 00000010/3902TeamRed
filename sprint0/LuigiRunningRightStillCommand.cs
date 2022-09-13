﻿using Microsoft.Xna.Framework;
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
            if (this.game.player is Sprite)
            {
                Sprite player = (Sprite)this.game.player;
                player.SourceRectangle = SpriteRectangle.LuigiRunningRight;
                player.Frame = 0;
                player.Velocity = new Vector2(0, 0);
            }
        }
    }
}
