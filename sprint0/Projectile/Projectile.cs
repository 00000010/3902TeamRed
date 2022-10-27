using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class Projectile : IProjectile, IObject
    {
        public Sprite Sprite { get; set; }
        public Vector2 Position { get { return Sprite.Position; } set { Sprite.Position = value; } }
        public Vector2 Velocity { get { return Sprite.Velocity; } set { Sprite.Velocity = value; } }
        public Direction Direction { get; set; }
        public Vector2 InitPosition { get; set; }

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public Projectile() { }
        public virtual void Draw(GameTime gameTime)
        {
            Sprite.Draw(gameTime);
        }

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public static void UpdateProjectileMotion(GameTime gameTime, List<IProjectile> projectilesInFlight, GameObjectManager manager)
        {
            for (int i = 0; i < projectilesInFlight.Count; i++)
            {
                HandleProjectileOutOfBounds(projectilesInFlight[i], manager);
                HandleProjectileBackToShooter(projectilesInFlight[i], manager);
            }
            UpdateVelocityBoomerang(projectilesInFlight, manager);
        }

        private static bool HandleProjectileOutOfBounds(IProjectile projectile, GameObjectManager manager)
        {
            if (projectile.Position.X > 800 || projectile.Position.X < 0 || projectile.Position.Y > 480 || projectile.Position.Y < 0)
            {
                manager.RemoveObject(projectile);
                return true;
            }
            return false;
        }


        //Make enemy own projectiles that it shoots
        private static bool HandleProjectileBackToShooter(IProjectile projectile, GameObjectManager manager)
        {
            bool result = (projectile.Direction == Direction.LEFT && projectile.Position.X > projectile.InitPosition.X)
                || (projectile.Direction == Direction.RIGHT && projectile.Position.X < projectile.InitPosition.X)
                || (projectile.Direction == Direction.UP && projectile.Position.Y > projectile.InitPosition.Y)
                || (projectile.Direction == Direction.DOWN && projectile.Position.Y < projectile.InitPosition.Y);
            if (result)
            {
                manager.RemoveObject(projectile);
                //Use reflection to get type of projectile and notify shooter to update if projectile is boomerang
                Type typeOfProj = projectile.GetType();
                string projTypeName = typeOfProj.Name;
                if (projTypeName.Equals("ZeldaBoom")) manager.shooterOfProjectile.GetValueOrDefault(projectile).ShotBoomerang = false;
            }
                return result;
        }

        public static void UpdateVelocityBoomerang(List<IProjectile> projectilesInFlight, GameObjectManager manager)
        {
            for (int i = 0; i < projectilesInFlight.Count; i++)
            {
                Type typeOfProj = projectilesInFlight[i].GetType();
                string projTypeName = typeOfProj.Name;
                if (projTypeName.Equals("ZeldaBoom")) ChangeBoomerangVelocity(projectilesInFlight[i]);
            }
        }

        public static void ChangeBoomerangVelocity(IProjectile projectile)
        {
            if (projectile.Direction == Direction.LEFT)
            {
                projectile.Velocity = new Vector2(projectile.Velocity.X + (float)0.2, projectile.Velocity.Y);
            }
            else if (projectile.Direction == Direction.RIGHT)
            {
                projectile.Velocity = new Vector2(projectile.Velocity.X - (float)0.2, projectile.Velocity.Y);
            }
            else if (projectile.Direction == Direction.DOWN)
            {
                projectile.Velocity = new Vector2(projectile.Velocity.X, projectile.Velocity.Y + (float)0.2);
            }
            else
            {
                projectile.Velocity = new Vector2(projectile.Velocity.X, projectile.Velocity.Y - (float)0.2);
            }
        }
    }
}
