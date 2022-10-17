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
        ISprite enemy;
        ISprite projectile;
        string intersectionLoc;
        GameObjectManager manager;
        public EnemyProjectileCollisionCommand(ISprite enemy, ISprite projectile, string intersectionLoc, GameObjectManager manager)
        {
            this.enemy = enemy;
            this.projectile = projectile;
            this.intersectionLoc = intersectionLoc;
            this.manager = manager;
        }

        public void Execute()
        {
            //enemy needs to take damage, and die after a few projectile hits
            manager.removeProjectile((IProjectile)projectile);
        }
    }
}