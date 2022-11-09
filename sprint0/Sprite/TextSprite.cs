using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    internal class TextSprite : ISprite
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Rectangle[] SourceRectangle { get; set; }
        public SpriteFont SpriteFont { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public SpriteBatch SpriteBatch { get; set; }

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public TextSprite(SpriteBatch spriteBatch, Vector2 position, SpriteFont spriteFont, string text, Color color)
        {
            SpriteBatch = spriteBatch;
            Position = position;
            SpriteFont = spriteFont;
            Text = text;
            Color = color;
        }

        public void Draw(GameTime gameTime)
        {
            SpriteBatch.DrawString(SpriteFont, Text, Position, Color);
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
