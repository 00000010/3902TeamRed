using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class Player : Sprite
    {
        private int delay = 0;
        public Vector2 Velocity { get; set; }

        public Player(Texture2D texture, Rectangle[] sourceRectangle, SpriteBatch spriteBatch, Vector2 position) 
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
            if (delay == 10)
            {
                Frame++;
                delay = 0;
            }
            delay++;
            //Frame++;
            if (Frame >= SourceRectangle.Length)
            {
                Frame = 0;
            }
        }

        private void UpdatePosition(GameTime gameTime)
        {
            Position += Velocity;

            // wrap around screen
            if (Position.X > 800)
            {
                this.Position = new Vector2(0 - SourceRectangle[Frame].Width * 10, Position.Y);
            }

            if (Position.Y > 480)
            {
                this.Position = new Vector2(Position.X, 0 - SourceRectangle[Frame].Height * 10);
            }
        }

        private void UpdateVelocity(GameTime gameTime)
        {
            // no-op
        }
    }
}
