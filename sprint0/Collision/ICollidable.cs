using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public interface ICollidable
    {
        public Rectangle CollidableRectangle { get; set; }
        public Vector2 Position { get; set; }
        public void ReactToCollision(object collider);
    }
}

