using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    internal class PlayerEnemyCollisionCommand : ICommand
    {
        IObject player;
        IObject enemy;
        string intersectionLoc;
        GameObjectManager manager;
        IPlayer managedPlayer;

        public PlayerEnemyCollisionCommand(IObject player, IObject enemy, string intersectionLoc, GameObjectManager manager)
        {
            this.player = player;
            this.enemy = enemy;
            this.intersectionLoc = intersectionLoc;
            this.manager = manager;
        }

        public void Execute()
        {
            Player player = (Player)this.player;
            Enemy enemy = (Enemy)this.enemy;

            managedPlayer = manager.player;

            if (intersectionLoc.Contains("top"))
            {
                if (player.Velocity.Y > 0 || enemy.Velocity.Y < 0)  // if the player is directed towards the enemy and enemy moving towards player
                {
                    player.Position -= new Vector2(0, 2);
                }
            }
            if (intersectionLoc.Contains("bottom"))
            {
                if (player.Velocity.Y < 0 || enemy.Velocity.Y > 0)
                {
                    player.Position += new Vector2(0, 2);
                }
            }
            if (intersectionLoc.Contains("left"))
            {
                if (player.Velocity.X > 0 || enemy.Velocity.X < 0)
                {
                    player.Position -= new Vector2(2, 0);
                }
            }
            if (intersectionLoc.Contains("right"))
            {
                if (player.Velocity.X < 0 || enemy.Velocity.X > 0)
                {
                    player.Position += new Vector2(2, 0);
                }
            }

            if (enemy.CollideDamage > 0)
            {
                managedPlayer.TakingDamage = true;
                managedPlayer.Damaged = enemy.CollideDamage;
                player.UpdatePlayerSprite(manager);
                SoundFactory.Instance.zeldaLinkHurt.Play();
            }
        }
    }
}