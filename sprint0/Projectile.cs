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
    public class Projectile : IProjectile
    {
        //public string InitFiringDirection { get; set; }
        public Sprite Sprite { get; set; }
        public Vector2 Position { get { return Sprite.Position; } set { Sprite.Position = value; } }
        public Vector2 Velocity { get; set; }
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
            Position += Velocity;
            Sprite.Update(gameTime);
        }
        //public Projectile(Texture2D texture, Rectangle[] sourceRectangle, SpriteBatch spriteBatch, Vector2 position)
        //    //: base(texture, sourceRectangle, spriteBatch, position)
        //{
        //}

        //public override void UpdateVelocity(GameTime gameTime)
        //{
        //    if (SourceRectangle != ProjectileRectangle.Boomerang) return;
        //    if (InitFiringDirection.Equals("left")) 
        //    {
        //        Velocity = new Vector2(Velocity.X + (float) 0.05, 0);
        //    } 
        //    else if (InitFiringDirection.Equals("right"))
        //    {
        //        Velocity = new Vector2(Velocity.X - (float)0.05, 0);
        //    }
        //    else if (InitFiringDirection.Equals("up"))
        //    {
        //        Velocity = new Vector2(0, Velocity.Y + (float)0.05);
        //    }
        //    else
        //    {
        //        Velocity = new Vector2(0, Velocity.Y - (float)0.05);
        //    }
        //}
    }
}
