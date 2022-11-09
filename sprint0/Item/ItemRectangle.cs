using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class ItemRectangle
    {
        //used for both arrow and silverarrow and bow
        public static Rectangle[] BowArrowUp = { new Rectangle(6, 0, 5, 16) };
        public static Rectangle[] BowArrowDown = { new Rectangle(6, 16, 5, 16) };
        public static Rectangle[] BowArrowLeft = { new Rectangle(16, 5, 16, 5) };
        public static Rectangle[] BowArrowRight = { new Rectangle(16, 21, 16, 5) };

        //red and blue candle
        public static Rectangle[] Candle = { new Rectangle(0, 0, 8, 16) };

        public static Rectangle[] Bomb = { new Rectangle(0, 0, 8, 14) };

        //boomerang and magical boomerang
        public static Rectangle[] Boomerang = { new Rectangle(0, 0, 5, 8) };

        public static Rectangle[] Clock = { new Rectangle(0, 0, 11, 16) };

        public static Rectangle[] Compass = { new Rectangle(0, 0, 11, 12) };

        public static Rectangle[] Fairy = { new Rectangle(0, 0, 8, 16) };

        public static Rectangle[] Food = { new Rectangle(0, 0, 8, 16) };

        public static Rectangle[] Heart = { new Rectangle(0, 0, 7, 8) };

        public static Rectangle[] HeartContainer = { new Rectangle(0, 0, 13, 13) };

        //used for both normal and magical keys
        public static Rectangle[] Key = { new Rectangle(0, 0, 8, 16) };

        public static Rectangle[] Letter = { new Rectangle(0, 0, 8, 16) };

        public static Rectangle[] LifePotion = { new Rectangle(0, 0, 0, 0) };

        public static Rectangle[] MagicalRod = { new Rectangle(0, 0, 4, 16) };

        public static Rectangle[] MagicalShield = { new Rectangle(0, 0, 8, 12) };

        public static Rectangle[] Map = { new Rectangle(0, 0, 8, 16) };

        public static Rectangle[] PowerBracelet = { new Rectangle(0, 0, 8, 14) };

        public static Rectangle[] Raft = { new Rectangle(0, 0, 14, 16) };

        public static Rectangle[] Recorder = { new Rectangle(0, 0, 3, 16) };

        //used for red and blue rings
        public static Rectangle[] Ring = { new Rectangle(0, 0, 7, 9) };

        //used for both Rupy and 5Rupy
        public static Rectangle[] Rupy = { new Rectangle(0, 0, 8, 16) };

        public static Rectangle[] Stepladder = { new Rectangle(0, 0, 16, 16) };

        //normal and white sword
        public static Rectangle[] Sword = { new Rectangle(0, 0, 7, 16) };

        public static Rectangle[] Triforce = { new Rectangle(0, 0, 10, 10) };
    }
}
