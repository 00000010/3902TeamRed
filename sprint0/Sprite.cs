﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class Sprite : Interfaces.ISprite
    {
        // TODO: delete, for testing purposes
        private int delay = 0;

        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRectangle { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        public int Direction { get; set; }
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
        public Sprite(Texture2D texture, Rectangle[] sourceRectangle, SpriteBatch spriteBatch, Vector2 position)
        {
            Texture = texture;
            SourceRectangle = sourceRectangle;
            Position = position;
            SpriteBatch = spriteBatch;
            Frame = 0;
        }

        public virtual void Update(GameTime gameTime)
        {
            UpdateVelocity(gameTime);
            UpdatePosition();
            UpdateFrame();
        }

        public virtual void Draw(GameTime gameTime)
        {
            int height = SourceRectangle[Frame].Height;
            int width = SourceRectangle[Frame].Width;

            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);

            SpriteBatch.Draw(Texture, destinationRectangle, SourceRectangle[Frame], Color.White);
        }

        protected virtual void UpdateVelocity(GameTime gameTime)
        {
            // no-op
            return;
        }

        protected virtual void UpdatePosition()
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

        protected virtual void UpdateFrame()
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

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
