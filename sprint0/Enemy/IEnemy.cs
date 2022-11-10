using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public interface IEnemy : IDrawable, IUpdateable
    {
        public Sprite Sprite { get; set; }
        public Vector2 Position { get { return Sprite.Position; } set { Sprite.Position = value; } }
        public Vector2 Velocity { get { return Sprite.Velocity; } set { Sprite.Velocity = value; } }
        public Direction Direction { get; set; }
        public State State { get; set; }
        public int Health { get; set; }
        public bool ShotBoomerang { get; set; }
        /// <summary>
        /// Scale of 1-10, with 1 being weakest and 10 being strongest. 0 indicates no damage if Link collides with it.
        /// </summary>
        public int CollideDamage { get; set; }
    }
}
