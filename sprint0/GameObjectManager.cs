using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Numerics;
using sprint0.Interfaces;
using sprint0.Rectangles;
using sprint0.Enemies;
using static System.Reflection.Metadata.BlobBuilder;

namespace sprint0
{
    public class GameObjectManager : IUpdateable, IDrawable
    {
        private Game1 game;
        public ISprite player;
        public List<ISprite> projectilesInFlight = new List<ISprite>();
        public List<ISprite> enemies = new List<ISprite>();
        public List<ISprite> blocks = new List<ISprite>();
        public List<ISprite> items = new List<ISprite>();
        public Dictionary<ISprite, string> initDirectionOfFire = new Dictionary<ISprite, string>();
        public Dictionary<ISprite, string> shooterOfProjectile = new Dictionary<ISprite, string>();


        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public GameObjectManager(Game1 game)
        {
            this.game = game;
        }

        event EventHandler<EventArgs> IUpdateable.EnabledChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<EventArgs> IUpdateable.UpdateOrderChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<EventArgs> IDrawable.DrawOrderChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<EventArgs> IDrawable.VisibleChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void addProjectile(ISprite projectile, string direction, string shooter)
        {
            projectilesInFlight.Add(projectile);
            initDirectionOfFire.Add(projectile, direction);
            shooterOfProjectile.Add(projectile, shooter);
        }

        public void removeProjectile(ISprite projectile)
        {
            projectilesInFlight.Remove(projectile);
        }

        public void addEnemy(Enemy enemy)
        {
            enemies.Add(enemy);
        }

        public void removeEnemy(Enemy enemy)
        {
            enemies.Remove(enemy);
        }

        public void addPlayer(Player player)
        {
            this.player = player;
        }

        public void addBlock(ISprite block)
        {
            blocks.Add(block);
        }

        public void removeBlock(ISprite block)
        {
            blocks.Remove(block);
        }

        public void addItem(ISprite item)
        {
            items.Add(item);
        }

        public void removeItem(ISprite item)
        {
            items.Remove(item);
        }

        public void Draw(GameTime gameTime)
        {
            foreach (Sprite projectile in projectilesInFlight)
            {
                projectile.Draw(gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            UpdateProjectileMotion(gameTime);
            //Handling all different types of collision
            CollisionDetection.HandleAllCollidables(player, projectilesInFlight, enemies, blocks, items, shooterOfProjectile, this);
        }

        public void UpdateProjectileMotion(GameTime gameTime)
        {
            for (int i = 0; i < projectilesInFlight.Count; i++)
            {
                projectilesInFlight[i].Update(gameTime);
                //Issue is in ProjectileBackToShooter because it assumes shooter is enemy
                if (ProjectileOutOfBounds(projectilesInFlight[i]) || ProjectileBackToShooter(projectilesInFlight[i]))
                {
                    game.currEnemy.projectileInMotion = false;
                    i--;
                }
            }
        }

        private bool ProjectileOutOfBounds(ISprite projectile)
        {
            if (projectile.Position.X > 800 || projectile.Position.X < 0 || projectile.Position.Y > 480 || projectile.Position.Y < 0)
            {
                removeProjectile(projectile);
                return true;
            }
            return false;
        }

        private bool ProjectileBackToShooter(ISprite projectile)
        {
            //Ensures that nothing happens if shooter is player
            if (shooterOfProjectile.GetValueOrDefault(projectile).Equals("player"))
            {
                return HandleShootingProjectile(projectile, game.player);
            }
            return HandleShootingProjectile(projectile, game.currEnemy);
        }

        private bool HandleShootingProjectile(ISprite projectile, ISprite sprite)
        {
            if (projectile is Projectile)
            {
                Projectile copyProj = (Projectile)projectile;
                if (copyProj.SourceRectangle != ProjectileRectangle.Boomerang) return false;
            }
            string initDirection = initDirectionOfFire.GetValueOrDefault(projectile);
            if (initDirection.Equals("right"))
            {
                return projectile.Position.X < sprite.Position.X;
            }
            else if (initDirection.Equals("left"))
            {
                return projectile.Position.X > sprite.Position.X;
            }
            else if (initDirection.Equals("up"))
            {
                return projectile.Position.Y > sprite.Position.Y;
            }
            return projectile.Position.Y < sprite.Position.Y;
        }
    }
}

