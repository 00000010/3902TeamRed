using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class SpriteRectangle
    {
        public static Rectangle[] LuigiStandingRight = { new Rectangle(210, 0, 16, 16) };
        public static Rectangle[] LuigiRunningRight = { new Rectangle(240, 0, 16, 16),
                    new Rectangle(270, 0, 16, 16),
                    new Rectangle(300, 0, 16, 16) };
        public static Rectangle[] arrowRight = { new Rectangle(210, 200, 16, 5) };
    }
}
