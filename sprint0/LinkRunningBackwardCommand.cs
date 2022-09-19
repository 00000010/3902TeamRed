﻿using Microsoft.Xna.Framework;
using System;
using System.Reflection;
using System.Windows.Input;

namespace sprint0
{
    internal class LinkRunningBackwardCommand : ICommand
    {
        private Game1 game;
        public LinkRunningBackwardCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if (this.game.player is Sprite)
            {
                Sprite player = (Sprite)this.game.player;

                SpriteRectangleNew sR = new LinkRectangle();
                sR = new Up(sR);
                sR = new Running(sR);
                player.SourceRectangle = sR.SourceRectangle(sR);

                player.Frame = 0;
                player.Velocity = new Vector2(0, -1);
            }
        }
    }
}
