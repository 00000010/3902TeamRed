using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class Item : Sprite
    {
        public Vector2 Velocity { get; set; }
        public Item(Texture2D texture, Rectangle[] sourceRectangle, SpriteBatch spriteBatch, Vector2 position)
            : base(texture, sourceRectangle, spriteBatch, position)
        {
            Velocity = Vector2.Zero;
        }

        public override void Update(GameTime gameTime)
        {
            UpdateVelocity(gameTime);
            UpdatePosition(gameTime);
            UpdateFrame(gameTime);
        }

        private void UpdateFrame(GameTime gameTime)
        {
            Frame++;
            if (Frame >= SourceRectangle.Length)
            {
                Frame = 0;
            }
        }

        private void UpdatePosition(GameTime gameTime)
        {
            Position += Velocity;
        }

        private void UpdateVelocity(GameTime gameTime)
        {
            // no-op
        }
    }
}

