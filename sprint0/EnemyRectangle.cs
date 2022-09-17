using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class EnemyRectangle
    { 
        //Skeleton
        public static Rectangle[] Stalfos = { new Rectangle(417, 117, 20, 20),
                    new Rectangle(417, 148, 20, 20)};

        //Bat
        public static Rectangle[] Keese = { new Rectangle(257, 268, 20, 20),
                    new Rectangle(234, 268, 20, 20)};

        //Boomerang enemy
        public static Rectangle[] Goriya = { new Rectangle(89, 59, 20, 20), new Rectangle(89, 89, 20, 20),
                    new Rectangle(55, 89, 20, 20), new Rectangle(55, 57, 20, 20), new Rectangle(27, 57, 20, 20), 
            new Rectangle(27, 87, 20, 20), new Rectangle(0, 57, 20, 20), new Rectangle(0, 87, 20, 20)};

        public static Rectangle[] Gel = { new Rectangle(417, 177, 20, 20), new Rectangle(417, 209, 20, 20) };

        //Spinny and shoots things
        public static Rectangle[] Octorok = { new Rectangle(0, 0, 20, 20), new Rectangle(28, 0, 20, 20), 
            new Rectangle(58, 0, 20, 20), new Rectangle(88, 0, 20, 20) };
    }
}
