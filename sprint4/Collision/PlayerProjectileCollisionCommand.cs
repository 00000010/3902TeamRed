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
        IPlayer player;
        IProjectile projectile;
        string intersectionLoc;
        GameObjectManager manager;
        public PlayerProjectileCollisionCommand(IObject player, IObject projectile, string intersectionLoc, GameObjectManager manager)
        {
            this.player = (IPlayer)player;
            this.projectile = (IProjectile)projectile;
            this.intersectionLoc = intersectionLoc;
            this.manager = manager;
        }

        public void Execute()
        {
            if (!GameObjectManager.IsDesiredObject((IObject)projectile, "ZeldaBoom"))
            {
                //link takes damage
                manager.RemoveObject((IObject)projectile);
            }

            player.TakingDamage = true;
            player.Damaged = projectile.CollideDamage;
            player.UpdatePlayerSprite(manager);

            SoundFactory.Instance.zeldaLinkHurt.Play();
        }
    }
}