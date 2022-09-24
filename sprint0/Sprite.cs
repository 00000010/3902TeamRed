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
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRectangle { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public Vector2 Position { get; set; }

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public int Frame { get; set; }

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

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
            // no-op
        }

        public virtual void Draw(GameTime gameTime)
        {
            int height = SourceRectangle[Frame].Height * 10;
            int width = SourceRectangle[Frame].Width * 10;

            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);

            SpriteBatch.Draw(Texture, destinationRectangle, SourceRectangle[Frame], Color.White);
        }
    }
}
