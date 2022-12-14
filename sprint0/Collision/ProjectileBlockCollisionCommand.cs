using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    internal class ProjectileBlockCollisionCommand : ICommand
    {
        IObject projectile;
        IObject block;
        string intersectionLoc;
        GameObjectManager manager;
        public ProjectileBlockCollisionCommand(IObject projectile, IObject block, string intersectionLoc, GameObjectManager manager)
        {
            this.projectile = projectile;
            this.block = block;
            this.intersectionLoc = intersectionLoc;
            this.manager = manager;
        }

        public void Execute()
        {
            //Don't do anything if a projectile collision happened with a waterblock
            if (GameObjectManager.IsDesiredObject(block, "WaterBlock")) return;  
            
            manager.objectsToRemove.Add(projectile);
            if (GameObjectManager.IsDesiredObject(projectile, "ZeldaBoom"))
            {
                manager.shooterOfProjectile.GetValueOrDefault((IProjectile)projectile).ShotBoomerang = false; ;
            }
        }
    }
}