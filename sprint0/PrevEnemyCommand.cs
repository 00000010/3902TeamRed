using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;

namespace sprint0
{
    internal class PrevEnemyCommand : ICommand
    {
        private Game1 game;
        public PrevEnemyCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.currIndex--;
            if (game.currIndex < 0) game.currIndex = game.enemies.Count - 1;
            game.currEnemy.SourceRectangle = game.enemies[game.currIndex];
            game.currEnemy.Frame = 0;
        }
    }
}
