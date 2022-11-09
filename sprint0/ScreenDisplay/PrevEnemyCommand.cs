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
            game.manager.RemoveObject(game.enemy);

            if (game.enemy is Stalfos)
            {
                game.enemy = EnemyFactory.Instance.Octorok(game.enemy.Position);
            }
            else if (game.enemy is Keese)
            {
                game.enemy = EnemyFactory.Instance.Stalfos(game.enemy.Position);
            }
            else if (game.enemy is Gel)
            {
                game.enemy = EnemyFactory.Instance.Keese(game.enemy.Position);
            }
            else if (game.enemy is Goriya)
            {
                game.enemy = EnemyFactory.Instance.Gel(game.enemy.Position);
            }
            else if (game.enemy is Octorok)
            {
                game.enemy = EnemyFactory.Instance.Goriya(game.enemy.Position);
            }

            game.manager.AddObject(game.enemy);
        }
    }
}
