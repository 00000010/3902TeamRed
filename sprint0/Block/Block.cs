using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    internal class Block : IBlock
    {
        public Sprite Sprite { get; set; }
        public Vector2 Position { get { return Sprite.Position; } set { Sprite.Position = value; } }
        public int DrawOrder => throw new NotImplementedException();
        public bool Visible => throw new NotImplementedException();

        public Block() { }

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime)
        {
            Sprite.Draw(gameTime);
        }
    }
}

