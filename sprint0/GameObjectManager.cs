using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Numerics;

namespace sprint0
{
    public class GameObjectManager : IUpdateable, IDrawable
    {
        private Game1 game;
        public List<ISprite> projectilesInFlight = new List<ISprite>();
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

        public void Draw(GameTime gameTime)
        {
            foreach (Sprite projectile in projectilesInFlight)
            {
                projectile.Draw(gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < projectilesInFlight.Count; i++)
            {
                projectilesInFlight[i].Update(gameTime);
                //Issue is in ProjectileBackToShooter because it assumes shooter is enemy
                if (ProjectileOutOfBounds(projectilesInFlight[i])
                    || ProjectileBackToShooter(projectilesInFlight[i]))
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
                return HandleShootingProjectilePlayer(projectile, game.player);
            }
            return HandleShootingProjectileEnemy(projectile, game.currEnemy);
        }

        private bool HandleShootingProjectilePlayer(ISprite projectile, Player player)
        {
            string initDirection = initDirectionOfFire.GetValueOrDefault(projectile);
            if (initDirection.Equals("right"))
            {
                return projectile.Position.X < player.Position.X;
            }
            else if (initDirection.Equals("left"))
            {
                return projectile.Position.X > player.Position.X;
            }
            else if (initDirection.Equals("up"))
            {
                return projectile.Position.Y > player.Position.Y;
            }
            return projectile.Position.Y < player.Position.Y;
        }

        private bool HandleShootingProjectileEnemy(ISprite projectile, Enemy enemy)
        {
            string initDirection = initDirectionOfFire.GetValueOrDefault(projectile);
            if (initDirection.Equals("right"))
            {
                return projectile.Position.X < enemy.Position.X;
            }
            else if (initDirection.Equals("left"))
            {
                return projectile.Position.X > enemy.Position.X;
            }
            else if (initDirection.Equals("up"))
            {
                return projectile.Position.Y > enemy.Position.Y;
            }
            return projectile.Position.Y < enemy.Position.Y;
        }
    }
}

