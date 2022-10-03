using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    internal class ShootProjectileCommand : ICommand
    {
        private static Game1 game;
        public static GameObjectManager manager;
        private string shooter;

        //Constructor for the player to use
        public ShootProjectileCommand(Game1 gameParam, string shooter = "player")
        {
            game = gameParam;
            manager = gameParam.manager;
            this.shooter = shooter;
        }

        //Constructor for enemies to use
        public ShootProjectileCommand(string shooter = "player")
        {
            this.shooter = shooter;
        }

        public void Execute()
        {
            //A player pr
            if (shooter.Equals("player"))
            {
                FirePlayerProjectile();
            } else
            {
                FireEnemyProjectile();
            }
        }

        //Distinguishing between firing player and enemy projectiles

        private void FirePlayerProjectile()
        {
            if (game.arrow is Projectile)
            {
                Projectile arrow = (Projectile)game.arrow;
                Projectile copy = (Projectile)arrow.Clone();
                copy.Position = game.player.Position;
                copy.Velocity = game.player.Velocity * 5;
                //Handling the initial case where link is still
                if (copy.Velocity == new Vector2(0, 0)) copy.Velocity = new Vector2(0, 5); 
                string initFiringDirection = GetDirection(copy.Velocity);
                copy.SourceRectangle = HandleSpriteRectangle(SpriteRectangle.arrow, initFiringDirection);
                manager.addProjectile(copy, initFiringDirection, shooter);
            }
        }

        private Rectangle[] HandleSpriteRectangle(Rectangle[] projectileRectangles, string initFiringDirection)
        {
            if (initFiringDirection.Equals("down"))
            {
                return new Rectangle[] { projectileRectangles[3] };
            }
            else if (initFiringDirection.Equals("up"))
            {
                return new Rectangle[] { projectileRectangles[1] };
            }
            else if (initFiringDirection.Equals("left"))
            {
                return new Rectangle[] { projectileRectangles[2] };
            }
            return new Rectangle[] { projectileRectangles[0] };
        }

        private void FireEnemyProjectile()
        {
            if (shooter.Equals("boomerang"))
            {
                FireDifferentEnemyProjectile(game.boomerang);
            }
            else if (shooter.Equals("rock"))
            {
                FireDifferentEnemyProjectile(game.rock);
            }
        }

        //Different types of enemy projectiles
        private void FireDifferentEnemyProjectile(ISprite gameProjectile)
        {
            if (gameProjectile is Projectile)
            {
                Projectile projectile = (Projectile)gameProjectile;
                string initFiringDirection = GetDirection(projectile.Velocity, "enemy");
                projectile.InitFiringDirection = initFiringDirection;
                Projectile copy = (Projectile)projectile.Clone();
                copy.Position = game.currEnemy.Position;
                //Goriya shoots boomerang in the direction of movement
                copy.Velocity = game.currEnemy.Velocity * 5;
                HandleVelocityIfOctorok(copy, initFiringDirection);
                copy.SourceRectangle = projectile.SourceRectangle;
                manager.addProjectile(copy, initFiringDirection, shooter);
            }
        }

        private void HandleVelocityIfOctorok(Projectile copy, string initFiringDirection)
        {
            if (copy.SourceRectangle != ProjectileRectangle.Rock) return;
            
            //We know Octorok is the one that fired now
            if (initFiringDirection.Equals("down"))
            {
                copy.Velocity = new Vector2(0, 10);
            }
            else if (initFiringDirection.Equals("up"))
            {
                copy.Velocity = new Vector2(0, -10);
            }
            else if (initFiringDirection.Equals("left"))
            {
                copy.Velocity = new Vector2(-10, 0);
            } 
            else
            {
                copy.Velocity = new Vector2(10, 0);
            }
        }

        private static string GetDirection(Vector2 Velocity, string shooter = "player")
        {
            if (shooter.Equals("enemy") && game.currEnemy.SourceRectangle == EnemyRectangle.Octorok)
            {
                return HandleInitialDirectionIfOctorok(game.currEnemy);
            }
            if (Velocity.X > 0)
            {
                return "right";
            } 
            else if (Velocity.X < 0)
            {
                return "left";
            }
            else if (Velocity.Y > 0)
            {
                return "up";
            }
            return "down";
        }

        private static string HandleInitialDirectionIfOctorok(Enemy enemy)
        {
            if (enemy.Frame == 0)
            {
                return "down";
            }
            else if (enemy.Frame == 1)
            {
                return "left";
            }
            else if (enemy.Frame == 2)
            {
                return "up";
            }
            return "right";
        }
    }
}

