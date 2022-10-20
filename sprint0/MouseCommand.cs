using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    enum MouseButton { Left, Right }
    internal class MouseCommand
    {
        public MouseButton Button { get; set; }
        public Rectangle Area { get; set; }

        public MouseCommand(MouseButton button, Rectangle area)
        {
            Button = button;
            Area = area;
        }
        public bool Equals(MouseState mouseState)
        {
            if ((Button == MouseButton.Left) &&
                (mouseState.LeftButton == ButtonState.Pressed) &&
                (Area.Contains(new Point(mouseState.X, mouseState.Y))))
            {
                return true;
            }
            
            if ((Button == MouseButton.Right) &&
                (mouseState.RightButton == ButtonState.Pressed) &&
                (Area.Contains(new Point(mouseState.X, mouseState.Y))))
            {
                return true;
            }
            
            return false;
        }
    }
}
    
