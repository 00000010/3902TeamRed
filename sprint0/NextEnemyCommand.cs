using Microsoft.Xna.Framework;
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
              
            if (this.game.currEnemy is Enemy)
            {
                Enemy enemy = (Enemy)this.game.currEnemy;
                this.game.currIndex++;
                if (this.game.currIndex >= this.game.rectangles.Count) this.game.currIndex = 0;
                enemy.SourceRectangle = this.game.rectangles[this.game.currIndex];
                enemy.Frame = 0;
            }
        }
    }
}
