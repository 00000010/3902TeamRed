using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace sprint0
{
    public class GameObjectManager : IUpdateable, IDrawable
    {
        private Game1 game;
        public List<ISprite> projectilesInFlight = new List<ISprite>();
        public Dictionary<ISprite, string> initDirectionOfFire = new Dictionary<ISprite, string>();


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

        public void addProjectile(ISprite projectile, string direction)
        {
            projectilesInFlight.Add(projectile);
            initDirectionOfFire.Add(projectile, direction);
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
            string initDirection = initDirectionOfFire.GetValueOrDefault(projectile);
            if (initDirection.Equals("right"))
            {
                return projectile.Position.X < game.currEnemy.Position.X;
            }
            else if (initDirection.Equals("left"))
            {
                return projectile.Position.X > game.currEnemy.Position.X;
            }
            else if (initDirection.Equals("up"))
            {
                return projectile.Position.Y > game.currEnemy.Position.Y;
            }
            return projectile.Position.Y < game.currEnemy.Position.Y;
        }
    }
}

