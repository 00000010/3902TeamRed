using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Rectangles
{
    public class ItemRectangle
    {
        //used for both arrow and silverarrow and bow
        public static Rectangle[] BowArrow = { new Rectangle(0, 0, 5, 16) };

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

        //letter and map
        public static Rectangle[] Letter = { new Rectangle(0, 0, 8, 16) };

        public static Rectangle[] Recorder = { new Rectangle(0, 0, 3,16) };

        public static Rectangle[] Raft = { new Rectangle(0, 0, 14, 16) };

        public static Rectangle[] PowerBracelet = { new Rectangle(0, 0, 8, 14) };
        
        //used for both rupy and 5rupy
        public static Rectangle[] Rupy = { new Rectangle(0, 0, 8, 16) };
        
        //used for both red and blue rings
        public static Rectangle[] Ring = { new Rectangle(0, 0, 8, 16) };

        //normal and white sword
        public static Rectangle[] Sword = { new Rectangle(0, 0, 7, 16) };

        public static Rectangle[] StepLadder = { new Rectangle(0, 0, 16, 16) };

        public static Rectangle[] Triforce = { new Rectangle(0, 0, 10, 10) };
    }
}
