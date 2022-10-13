using Microsoft.Xna.Framework;
using sprint0.Commands;
using sprint0.Enemies;
using sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    public class CollisionResolution
    {
        //Calls the command that corresponds to the collision
        //intersectionLoc can be left,right,top, or bottom
        public static void PlayerAgainstProjectile(ISprite player, ISprite projectile, GameObjectManager manager)
        {
            //link takes damage

            //projectile removed when hits enemy (cant implement yet because enemy waits for boomerang even though it is removed)
        }
        public static void PlayerAgainstEnemy(ISprite player, ISprite enemy, String intersectionLoc)
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
        public static void PlayerAgainstBlock(ISprite player, ISprite block, String intersectionLoc)
        {
            Player Player = (Player)player;
            if (intersectionLoc == "top")
            {
                if (Player.Velocity.Y > 0)  // if the velocity is directed towards the block
                {
                    Player.Velocity = Vector2.Zero;
                }
            }
            else if (intersectionLoc == "bottom")
            {
                if (Player.Velocity.Y < 0)
                {
                    Player.Velocity = Vector2.Zero;
                }
            }
            else if (intersectionLoc == "left")
            {
                if (Player.Velocity.X < 0)
                {
                    Player.Velocity = Vector2.Zero;
                }
            }
            else //right
            {
                if (Player.Velocity.X > 0)
                {
                    Player.Velocity = Vector2.Zero;
                }
            }
        }
        public static void PlayerAgainstItem(ISprite player, ISprite item)
        {
            //link will have all items to start with, they wont pick up any items yet
        }
        public static void EnemyAgainstProjectile(ISprite enemy, ISprite projectile, GameObjectManager manager)
        {
            //enemy needs to take damage, and die after a few projectile hits
            manager.projectilesInFlight.Remove(projectile);
        }
        public static void EnemyAgainstEnemy(ISprite enemy, ISprite enemy2, String intersectionLoc)
        {

            Enemy Enemy1 = (Enemy)enemy;
            Enemy Enemy2 = (Enemy)enemy2;
            if (intersectionLoc == "top")
            {
                if (Enemy1.Velocity.Y > 0 && Enemy2.Velocity.Y < 0)  // if the enemy1 is directed towards enemy2 AND enemy2 moving towards enemy1
                {
                    Enemy1.Velocity = -Enemy1.Velocity;  //enemy1 changes direction
                    Enemy2.Velocity = -Enemy2.Velocity;  //enemy2 changes direction
                }
            }
            else if (intersectionLoc == "bottom")
            {
                if (Enemy1.Velocity.Y < 0 && Enemy2.Velocity.Y > 0)
                {
                    Enemy1.Velocity = -Enemy1.Velocity;  //enemy1 changes direction
                    Enemy2.Velocity = -Enemy2.Velocity;  //enemy2 changes direction
                }
            }
            else if (intersectionLoc == "left")
            {
                if (Enemy1.Velocity.X < 0 && Enemy2.Velocity.X > 0)
                {
                    Enemy1.Velocity = -Enemy1.Velocity;  //enemy1 changes direction
                    Enemy2.Velocity = -Enemy2.Velocity;  //enemy2 changes direction
                }
            }
            else //right
            {
                if (Enemy1.Velocity.X > 0 && Enemy2.Velocity.X < 0)
                {
                    Enemy1.Velocity = -Enemy1.Velocity;  //enemy1 changes direction
                    Enemy2.Velocity = -Enemy2.Velocity;  //enemy2 changes direction
                }
            }
        }
        
        public static void EnemyAgainstBlock(ISprite enemy, ISprite block, String intersectionLoc)
        {
            Enemy Enemy = (Enemy)enemy;
            if (intersectionLoc == "top")
            {
                if (Enemy.Velocity.Y > 0)  // if the velocity is directed towards the block
                {
                    Enemy.Velocity = Vector2.Zero;
                }
            }
            else if (intersectionLoc == "bottom")
            {
                if (Enemy.Velocity.Y < 0)
                {
                    Enemy.Velocity = Vector2.Zero;
                }
            }
            else if (intersectionLoc == "left")
            {
                if (Enemy.Velocity.X < 0)
                {
                    Enemy.Velocity = Vector2.Zero;
                }
            }
            else //right
            {
                if (Enemy.Velocity.X > 0)
                {
                    Enemy.Velocity = Vector2.Zero;
                }
            }
        }
        public static void ProjectileAgainstBlock(ISprite projectile, ISprite block, GameObjectManager manager)
        {
            manager.projectilesInFlight.Remove(projectile); //projectile breaks when hits block
            //boomerang enemy breaks since they wait for the boomerang even though it is removed.
        }
    }
}
