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
        public static Rectangle[] Stalfos = { 
            new Rectangle(420, 120, 16, 16),
            new Rectangle(420, 150, 16, 16)
        };

        //Bat
        public static Rectangle[] Keese = {
            new Rectangle(235, 273, 16, 10),
            new Rectangle(260, 273, 16, 10)
            
        };

        //Boomerang enemy
        public static Rectangle[] GoriyaLeft = { 
            new Rectangle(27, 57, 20, 20), 
            new Rectangle(27, 87, 20, 20)
        };

        public static Rectangle[] GoriyaRight =
        {
            new Rectangle(89, 59, 20, 20),
            new Rectangle(89, 89, 20, 20)
        };

        public static Rectangle[] GoriyaUp =
        {
            new Rectangle(55, 89, 20, 20),
            new Rectangle(55, 57, 20, 20)
        };

        public static Rectangle[] GoriyaDown =
        {
            new Rectangle(0, 57, 20, 20),
            new Rectangle(0, 87, 20, 20)
        };

        public static Rectangle[] Gel = { 
            new Rectangle(417, 177, 20, 20),
            new Rectangle(417, 209, 20, 20) 
        };

        public static Rectangle[] Dragon = {
            new Rectangle(2, 12, 23, 30),
            new Rectangle(27, 13, 23, 30),
            new Rectangle(51, 13, 23, 30),
            new Rectangle(77, 13, 23, 30)
        };

        public static Rectangle[] ZeldaOldMan = {
            new Rectangle(19, 12, 15, 15)
        };

        //Spinny and shoots things
        public static Rectangle[] Octorok = {
            new Rectangle(0, 0, 20, 20),
            new Rectangle(28, 0, 20, 20),
            new Rectangle(58, 0, 20, 20),
            new Rectangle(88, 0, 20, 20)
        };
    }
}
