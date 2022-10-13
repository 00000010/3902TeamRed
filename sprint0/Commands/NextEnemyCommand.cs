using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

namespace sprint0.Commands
{
    internal class NextEnemyCommand : Interfaces.ICommand
    {
        private Game1 game;
        public NextEnemyCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.currEnemyIndex++;
            if (game.currEnemyIndex >= game.enemies.Count) game.currEnemyIndex = 0;
            game.currEnemy.SourceRectangle = game.enemies[game.currEnemyIndex];
            game.currEnemy.Frame = 0;
        }
    }
}
