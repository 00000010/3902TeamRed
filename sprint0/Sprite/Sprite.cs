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
    public class Sprite : ISprite
    {
        // TODO: delete, for testing purposes
        private int delay = 0;

        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRectangle { get; set; }
        public Rectangle DestinationRectangle { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public float LayerDepth { get; set; }

        public Direction Direction { get; set; }
        public int NumUpdates { get; set; }

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
        /// <param name="layerDepth">float between 0 and 1, with a higher number indicating drawn later</param>
        public Sprite(Texture2D texture, Rectangle[] sourceRectangle, SpriteBatch spriteBatch, Vector2 position, float layerDepth)
        {
            Texture = texture;
            SourceRectangle = sourceRectangle;
            Position = position;
            LayerDepth = layerDepth;
            Velocity = Vector2.Zero;
            SpriteBatch = spriteBatch;
            Frame = 0;
            UpdateDestinationRectangle();
        }

        private void UpdateDestinationRectangle()
        {
            int height = SourceRectangle[Frame].Height;
            int width = SourceRectangle[Frame].Width;

            DestinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width * Constants.SCALING_FACTOR, height * Constants.SCALING_FACTOR);
        }

        public virtual void Update(GameTime gameTime)
        {
            UpdateVelocity(gameTime);
            UpdatePosition();
            UpdateFrame(gameTime);
            UpdateDestinationRectangle();
        }

        public virtual void Draw(GameTime gameTime)
        {
            SpriteBatch.Draw(Texture, DestinationRectangle, SourceRectangle[Frame], Color.White, rotation: 0, origin: Vector2.Zero, effects: SpriteEffects.None, LayerDepth);
        }

        public virtual void UpdateVelocity(GameTime gameTime)
        {
            // no-op
        }

        public virtual void UpdatePosition()
        {
            Position += Velocity;

            //Don't wrap around screen for projectiles
            // TODO: ouch! fix this messy if statement
            if (SourceRectangle == ItemRectangle.BowArrowUp || SourceRectangle == ItemRectangle.BowArrowDown || SourceRectangle == ItemRectangle.BowArrowLeft || SourceRectangle == ItemRectangle.BowArrowRight) return;

            // wrap around screen
            // TODO: probably remove as this is from sprint2
            //if (Position.X > 800)
            //{
            //    Position = new Vector2(0, Position.Y);
            //}
            //else if (Position.X < 0)
            //{
            //    Position = new Vector2(800 - SourceRectangle[Frame].Width, Position.Y);
            //}
            //else if (Position.Y > 480)
            //{
            //    Position = new Vector2(Position.X, 0);
            //} 
            //else if (Position.Y < 0)
            //{
            //    Position = new Vector2(Position.X, 480 - SourceRectangle[Frame].Height);
            //}
        }

        public virtual void UpdateFrame(GameTime gameTime)
        {
            //Waits for 4 updates to occur before doing another update
            if (NumUpdates < 4)
            {
                NumUpdates++;
                return;
            }
            NumUpdates = 0;

            //Updates frame
            Frame++;
            if (Frame >= SourceRectangle.Length)
            {
                Frame = 0;
            }
        }
    }
}