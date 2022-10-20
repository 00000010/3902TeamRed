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
                //Issue is in ProjectileBackToShooter because it assumes shooter is enemy
                //ProjectileBackToShooter(projectilesInFlight[i])
                if (ProjectileOutOfBounds(projectilesInFlight[i], manager)) i--;
            }
        }

        private static bool ProjectileOutOfBounds(IProjectile projectile, GameObjectManager manager)
        {
            if (projectile.Position.X > 800 || projectile.Position.X < 0 || projectile.Position.Y > 480 || projectile.Position.Y < 0)
            {
                manager.removeProjectile(projectile);
                return true;
            }
            return false;
        }
    }
}
