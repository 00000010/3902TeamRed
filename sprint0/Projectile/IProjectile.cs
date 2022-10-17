using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public interface IProjectile : IDrawable, IUpdateable
    {
        public Sprite Sprite { get; set; }
        public Vector2 Position { get { return Sprite.Position; } set { Sprite.Position = value; } }
        public Vector2 Velocity { get { return Sprite.Velocity; } set { Sprite.Velocity = value; } }
        public Direction Direction { get; set; }
    }
}
