using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class ProjectileRectangle
    {
        //Boomerang
        public static Rectangle[] Boomerang = { 
            new Rectangle(79, 402, 7, 10),
            new Rectangle(88, 402, 7, 10),
            new Rectangle(88, 420, 7, 10),
            new Rectangle(79, 420, 7, 10)
        };
        
        //Rock
        public static Rectangle[] Rock = { 
            new Rectangle(91, 303, 10, 10)
        };

        //Fire
        public static Rectangle[] Fire = {
            new Rectangle(300, 1, 15, 15),
            new Rectangle(300, 32, 15, 15)
        };
    }
}
