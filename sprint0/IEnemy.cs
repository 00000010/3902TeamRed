﻿using Microsoft.Xna.Framework;
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
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Direction Direction { get; set; }
        public State State { get; set; }
    }
}
