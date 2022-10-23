using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    internal class EnemyProjectileCommand : ICommand
    {
        private Game1 game;
        private IEnemy enemy;
        private string name;
        private GameObjectManager manager;

        public EnemyProjectileCommand(Game1 game, IEnemy enemy, string name)
        {
            this.game = game;
            manager = game.manager;
            this.enemy = enemy;
            this.name = name;
        }

        public void Execute()
        {
            IProjectile projectile = null;
            if (name.Equals("Goriya"))
            {
                projectile = ProjectileFactory.Instance.ZeldaBoomerang(enemy.Position, enemy.Direction);
            }
            else if (name.Equals("Octorok"))
            {
                projectile = ProjectileFactory.Instance.ZeldaRock(enemy.Position, enemy.Direction);
            }
            manager.AddObject(projectile);
        }
    }
}
