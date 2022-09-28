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
    internal class Projectile : Sprite
    {
        public string InitFiringDirection {get;set;}
        public Projectile(Texture2D texture, Rectangle[] sourceRectangle, SpriteBatch spriteBatch, Vector2 position)
            : base(texture, sourceRectangle, spriteBatch, position)
        {
        }

        protected override void UpdateVelocity(GameTime gameTime)
        {
            if (SourceRectangle != ProjectileRectangle.Boomerang) return;
            if (InitFiringDirection.Equals("left")) 
            {
                Velocity = new Vector2(Velocity.X + (float) 0.05, 0);
            } 
            else if (InitFiringDirection.Equals("right"))
            {
                Velocity = new Vector2(Velocity.X - (float)0.05, 0);
            }
            else if (InitFiringDirection.Equals("up"))
            {
                Velocity = new Vector2(0, Velocity.Y + (float)0.05);
            }
            else
            {
                Velocity = new Vector2(0, Velocity.Y - (float)0.05);
            }
        }
    }
}
