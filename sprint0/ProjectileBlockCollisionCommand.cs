﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            manager.objectsToRemove.Add(projectile);
            //boomerang enemy breaks since they wait for the boomerang even though it is removed.
        }
    }
}