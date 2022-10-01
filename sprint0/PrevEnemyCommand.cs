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
            game.currEnemyIndex--;
            if (game.currEnemyIndex < 0) game.currEnemyIndex = game.enemies.Count - 1;
            game.currEnemy.SourceRectangle = game.enemies[game.currEnemyIndex];
            game.currEnemy.Frame = 0;
        }
    }
}
