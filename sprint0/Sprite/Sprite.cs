using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
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
        public string objectKind { get; set; }

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
            objectKind = "Sprite";
            Texture = texture;
            SourceRectangle = sourceRectangle;
            DestinationRectangle = sourceRectangle[0]; //testing
            Position = position;
            LayerDepth = layerDepth;
            Velocity = Vector2.Zero;
            SpriteBatch = spriteBatch;
            Frame = 0;
            UpdateDestinationRectangle();
        }

        /// <summary>
        /// Create an uninitialized Sprite. Exercise caution if using this constructor.
        /// </summary>
        public Sprite() {}

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

            if (SourceRectangle == ItemRectangle.BowArrowUp || SourceRectangle == ItemRectangle.BowArrowDown || SourceRectangle == ItemRectangle.BowArrowLeft || SourceRectangle == ItemRectangle.BowArrowRight) return;
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

        /// <summary>
        /// Perform a deep copy and return the copy with no references attached.
        /// </summary>
        /// <returns></returns>
        public Sprite Copy()
        {
            var copy = new Sprite(Texture, SourceRectangle, SpriteBatch, Position, LayerDepth);
            copy.Texture = this.Texture;

            // Perform a deep copy of the source rectangles array.
            copy.SourceRectangle = new Rectangle[this.SourceRectangle.Length];
            for (int i = 0; i < this.SourceRectangle.Length; i++)
            {
                copy.SourceRectangle[i] = new Rectangle(this.SourceRectangle[i].X, this.SourceRectangle[i].Y, this.SourceRectangle[i].Width, this.SourceRectangle[i].Height);
            }

            copy.SpriteBatch = this.SpriteBatch;
            copy.Position = this.Position;
            copy.LayerDepth = this.LayerDepth;
            return copy;
        }
    }
}