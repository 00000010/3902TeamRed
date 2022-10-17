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
        ISprite player;
        ISprite enemy;
        string intersectionLoc;
        GameObjectManager manager;
        public PlayerEnemyCollisionCommand(ISprite player, ISprite enemy, string intersectionLoc, GameObjectManager manager)
        {
            this.player = player;
            this.enemy = enemy;
            this.intersectionLoc = intersectionLoc;
            this.manager = manager;
        }

        public void Execute()
        {
            Player Player = (Player)player;
            Enemy Enemy = (Enemy)enemy;
            if (intersectionLoc == "top")
            {
                if (Player.Velocity.Y > 0 && Enemy.Velocity.Y < 0)  // if the player is directed towards the enemy and enemy moving towards player
                {
                    Enemy.Velocity = -Enemy.Velocity;  //enemy changes direction
                }
            }
            else if (intersectionLoc == "bottom")
            {
                if (Player.Velocity.Y < 0 && Enemy.Velocity.Y > 0)
                {
                    Enemy.Velocity = -Enemy.Velocity;
                }
            }
            else if (intersectionLoc == "left")
            {
                if (Player.Velocity.X < 0 && Enemy.Velocity.X > 0)
                {
                    Enemy.Velocity = -Enemy.Velocity;
                }
            }
            else //right
            {
                if (Player.Velocity.X > 0 && Enemy.Velocity.X < 0)
                {
                    Enemy.Velocity = -Enemy.Velocity;
                }
            }
        }
    }
}