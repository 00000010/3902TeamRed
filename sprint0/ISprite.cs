using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public interface ISprite : IUpdateable, IDrawable
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        //Rectangle[] SourceRectangle { get; set; }
        SpriteBatch SpriteBatch { get; set; }
    }
}
