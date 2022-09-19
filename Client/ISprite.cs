using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public interface ISprite : IUpdateable, IDrawable
    {
        Vector2 Position { get; set; }
        SpriteBatch SpriteBatch { get; set; }
    }
}
