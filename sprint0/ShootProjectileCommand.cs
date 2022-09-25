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
            if (game.arrow is Sprite)
            {
                Sprite arrow = (Sprite)game.arrow;
                Sprite copy = (Sprite)arrow.Clone();
                copy.Position = game.player.Position;
                copy.Velocity = new Vector2(10, 0);
                copy.SourceRectangle = SpriteRectangle.arrowRight;
                manager.addProjectile(copy);
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
            if (game.boomerang is Sprite)
            {
                Sprite boomerang = (Sprite)game.boomerang;
                Sprite copy = (Sprite)boomerang.Clone();
                copy.Position = game.currEnemy.Position;
                //Goriya shoots boomerang in the direction of movement
                copy.Velocity = game.currEnemy.Velocity * 5;
                copy.SourceRectangle = boomerang.SourceRectangle;
                manager.addProjectile(copy);
            }
        }
    }
}

