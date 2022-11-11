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
                //We have enemies knowing when they shoot boomerangs. Have to develop a way for projectiles
                //to notify enemies when boomerang is removed
                projectile = ProjectileFactory.Instance.ZeldaBoomerang(enemy.Position, enemy.Direction);
                enemy.ShotBoomerang = true;
            }
            else if (name.Equals("Octorok"))
            {
                projectile = ProjectileFactory.Instance.ZeldaRock(enemy.Position, enemy.Direction);
            }
            else if (name.Equals("Dragon"))
            {
                projectile = ProjectileFactory.Instance.ZeldaDragonProj(enemy.Position, new Vector2(-5, 0));
                IProjectile projectile2 = ProjectileFactory.Instance.ZeldaDragonProj(enemy.Position, new Vector2(-5, -3));
                IProjectile projectile3 = ProjectileFactory.Instance.ZeldaDragonProj(enemy.Position, new Vector2(-5, 3));
                manager.AddObject(projectile2);
                manager.shooterOfProjectile.Add(projectile2, (IShooter)enemy);
                manager.AddObject(projectile3);
                manager.shooterOfProjectile.Add(projectile3, (IShooter)enemy);
            }
            manager.AddObject(projectile);
            manager.shooterOfProjectile.Add(projectile, (IShooter) enemy);
        }
    }
}
