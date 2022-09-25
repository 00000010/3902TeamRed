using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    internal class ShootProjectileCommand : ICommand
    {
        private static Game1 game;
        public static GameObjectManager manager;
        private string projectile;

        //Constructor for the player to use
        public ShootProjectileCommand(Game1 gameParam, string projectile = "player")
        {
            game = gameParam;
            manager = gameParam.manager;
            this.projectile = projectile;
        }


        //Constructor for enemies to use
        public ShootProjectileCommand(string projectile = "player")
        {
            this.projectile = projectile;
        }

        public void Execute()
        {
            //A player pr
            if (projectile.Equals("player"))
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
                copy.Velocity = new Vector2(10, 0);
                copy.SourceRectangle = SpriteRectangle.arrowRight;
                manager.addProjectile(copy, "right");
            }
        }

        private void FireEnemyProjectile()
        {
            if (projectile.Equals("boomerang"))
            {
                FireGoriyaProjectile();
            }
        }

        //Different types of enemy projectiles
        private void FireGoriyaProjectile()
        {
            if (game.boomerang is Projectile)
            {
                Projectile boomerang = (Projectile)game.boomerang;
                string initFiringDirection = GetDirection(boomerang.Velocity);
                boomerang.InitFiringDirection = initFiringDirection;
                Projectile copy = (Projectile)boomerang.Clone();
                copy.Position = game.currEnemy.Position;
                //Goriya shoots boomerang in the direction of movement
                copy.Velocity = game.currEnemy.Velocity * 5;
                copy.SourceRectangle = boomerang.SourceRectangle;
                manager.addProjectile(copy, initFiringDirection);
            }
        }

        private static string GetDirection(Vector2 Velocity)
        {
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
    }
}

