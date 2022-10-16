using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public interface IBackground : IDrawable
    {
        SpriteBatch SpriteBatch { get; set; }
    }
}

