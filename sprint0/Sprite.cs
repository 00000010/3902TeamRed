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
    internal class Sprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRectangle { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public int Direction { get; set; }

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public int Frame { get; set; }

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        /// <summary>
        /// Create a sprite from a spritesheet given its location from a
        /// spritesheet and put it in the game at the specified position with a
        /// velocity and direction.
        /// </summary>
        /// <param name="texture">the spritesheet</param>
        /// <param name="sourceRectangle">the rectangle containing the sprite
        /// from the spritesheet</param>
        /// <param name="spriteBatch"></param>
        /// <param name="position">where to put the sprite</param>
        /// <param name="velocity">the velocity of the sprite when placed</param>
        /// <param name="direction">the direction the sprite is facing (0 is up,
        /// 1 is right, 2 is down, 3 is left)</param>
        public Sprite(Texture2D texture, Rectangle[] sourceRectangle, SpriteBatch spriteBatch, Vector2 position, Vector2 velocity, int direction)
        {
            Texture = texture;
            SourceRectangle = sourceRectangle;
            Position = position;
            Velocity = velocity;
            SpriteBatch = spriteBatch;
            Frame = 0;
        }

        public void Update(GameTime gameTime)
        {
            UpdateVelocity();
            UpdatePosition();
            UpdateFrame();
        }

        public void Draw(GameTime gameTime)
        {
            int height = SourceRectangle[Frame].Height;
            int width = SourceRectangle[Frame].Width;

            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);

            SpriteBatch.Draw(Texture, destinationRectangle, SourceRectangle[Frame], Color.White);
        }

        private void UpdateVelocity()
        {
            // no-op
            return;
        }

        private void UpdatePosition()
        {
            Position += Velocity;

            // wrap around screen
            if (Position.X > 800)
            {
                this.Position = new Vector2(0 - SourceRectangle[Frame].Width, Position.Y);
            }

            if (Position.Y > 480)
            {
                this.Position = new Vector2(Position.X, 0 - SourceRectangle[Frame].Height);
            }    
        }

        private void UpdateFrame()
        {
            Frame++;
            if (Frame >= SourceRectangle.Length)
            {
                Frame = 0;
            }
        }
    }
}
