using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

namespace sprint0
{
    internal class NextEnemyCommand : ICommand
    {
        private Game1 game;
        public NextEnemyCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.currIndex++;
            if (game.currIndex >= game.enemies.Count) game.currIndex = 0;
            game.currEnemy.SourceRectangle = game.enemies[game.currIndex];
            game.currEnemy.Frame = 0;
        }
    }
}
