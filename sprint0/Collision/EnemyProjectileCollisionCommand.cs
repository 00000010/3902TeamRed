using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    internal class EnemyProjectileCollisionCommand : ICommand
    {
        IEnemy enemy;
        IProjectile projectile;
        string intersectionLoc;
        GameObjectManager manager;
        public EnemyProjectileCollisionCommand(IObject enemy, IObject projectile, string intersectionLoc, GameObjectManager manager)
        {
            this.enemy = (IEnemy)enemy;
            this.projectile = (IProjectile)projectile;
            this.intersectionLoc = intersectionLoc;
            this.manager = manager;
        }

        public void Execute()
        {
            if (!Projectile.IsDesiredProjectile(projectile, "ZeldaBoom"))
            {
                manager.RemoveObject((IObject)projectile);
            }

            //WANT TO MODIFY THIS SO THAT ENEMY UPDATES SPRITE AS WELL
            enemy.Health -= projectile.CollideDamage;
            if (enemy.Health <= 0)
            {
                manager.RemoveObject((IObject)enemy);
                manager.RemoveFromRoom(enemy);
                SoundFactory.Instance.zeldaEnemyDie.Play();
            }
            else
            {
                SoundFactory.Instance.zeldaEnemyHit.Play();
            } 
        }
    }
}