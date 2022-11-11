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
        public int CollideDamage { get; set; }

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
            UpdateDistanceFireballs(projectilesInFlight, manager);
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
        private static void HandleProjectileBackToShooter(IProjectile projectile, GameObjectManager manager)
        {
            if (!GameObjectManager.IsDesiredObject((IObject)projectile, "ZeldaBoom")) return;
            bool result = (projectile.Direction == Direction.LEFT && projectile.Position.X > projectile.InitPosition.X)
                || (projectile.Direction == Direction.RIGHT && projectile.Position.X < projectile.InitPosition.X)
                || (projectile.Direction == Direction.UP && projectile.Position.Y > projectile.InitPosition.Y)
                || (projectile.Direction == Direction.DOWN && projectile.Position.Y < projectile.InitPosition.Y);
            if (result)
            {
                manager.RemoveObject(projectile);
                manager.shooterOfProjectile.GetValueOrDefault(projectile).ShotBoomerang = false;
            }
        }

        public static void UpdateVelocityBoomerang(List<IProjectile> projectilesInFlight, GameObjectManager manager)
        {
            for (int i = 0; i < projectilesInFlight.Count; i++)
            {
                if (GameObjectManager.IsDesiredObject((IObject)projectilesInFlight[i], "ZeldaBoom")) ChangeBoomerangVelocity(projectilesInFlight[i]);
            }
        }

        public static void UpdateDistanceFireballs(List<IProjectile> projectilesInFlight, GameObjectManager manager)
        {
            for (int i = 0; i < projectilesInFlight.Count; i++)
            {
                if (GameObjectManager.IsDesiredObject((IObject)projectilesInFlight[i], "ZeldaFire")) RemoveFireballIfNeeded(projectilesInFlight[i], manager);
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
                projectile.Velocity = new Vector2(projectile.Velocity.X, projectile.Velocity.Y - (float)0.2);
            }
            else
            {
                projectile.Velocity = new Vector2(projectile.Velocity.X, projectile.Velocity.Y + (float)0.2);
            }
        }

        public static void RemoveFireballIfNeeded(IProjectile projectile, GameObjectManager manager)
        {
            float distance = Math.Abs(projectile.Position.X - projectile.InitPosition.X) +
                Math.Abs(projectile.Position.Y - projectile.InitPosition.Y);
            if (distance > 100) manager.RemoveObject(projectile);
        }
    }
}
