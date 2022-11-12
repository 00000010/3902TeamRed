using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public interface ICamera : IUpdateable
    {
        public Sprite Sprite { get; set; }
        public Vector2 Position { get { return Sprite.Position; } set { Sprite.Position = value; } }
        public Vector2 Velocity { get { return Sprite.Velocity; } set { Sprite.Velocity = value; } }
        //public Direction Direction { get; set; }
        //public State State { get; set; }
        public void CurtainTransition(List<object> roomObjects, GameTime gameTime);
        public void PanLeftTransition(List<object> roomObjects, GameTime gameTime);
        public void PanRightTransition(List<object> roomObjects, GameTime gameTime);
        public void PanUpTransition(List<object> roomObjects, GameTime gameTime);
        public void PanDownTransition(List<object> roomObjects, GameTime gameTime);
    }
}