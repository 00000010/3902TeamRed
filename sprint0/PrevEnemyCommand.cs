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
            if (this.game.currEnemy is Enemy)
            {
                Enemy enemy = (Enemy)this.game.currEnemy;
                this.game.currIndex--;
                if (this.game.currIndex < 0) this.game.currIndex = this.game.rectangles.Count - 1;
                enemy.SourceRectangle = this.game.rectangles[this.game.currIndex];
                enemy.Frame = 0;
            }
        }
    }
}
