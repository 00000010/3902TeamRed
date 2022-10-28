using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    internal class PlayerProjectileCollisionCommand : ICommand
    {
        IObject player;
        IObject projectile;
        string intersectionLoc;
        GameObjectManager manager;
        public PlayerProjectileCollisionCommand(IObject player, IObject projectile, string intersectionLoc, GameObjectManager manager)
        {
            this.player = player;
            this.projectile = projectile;
            this.intersectionLoc = intersectionLoc;
            this.manager = manager;
        }

        public void Execute()
        {
            //link takes damage
            manager.objectsToRemove.Add(projectile);
            if (Projectile.IsBoomerang((IProjectile)projectile))
            {
                manager.shooterOfProjectile.GetValueOrDefault((IProjectile)projectile).ShotBoomerang = false; ;
            }
            SoundFactory.Instance.zeldaLinkHurt.Play();
        }
    }
}