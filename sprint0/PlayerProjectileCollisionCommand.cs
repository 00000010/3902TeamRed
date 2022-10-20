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
            //projectile removed when hits enemy (cant implement yet because enemy waits for boomerang even though it is removed)
        }
    }
}