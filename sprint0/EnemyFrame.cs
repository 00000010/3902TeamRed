using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    internal static class EnemyFrame
    {
        private static int numUpdates = 0;
        public static void UpdateFrame(Rectangle[] sourceRectangle, ref int frame, Vector2 velocity)
        {
            if (sourceRectangle == EnemyRectangle.Goriya)
            {
                UpdateGoriyaFrame(ref frame, velocity);
            }
            else
            {
                UpdateRestFrame(sourceRectangle, ref frame);
            }
        }

        public static void UpdateRestFrame(Rectangle[] sourceRectangle, ref int frame)
        {
            //Waits for 4 updates to occur before doing another update
            if (numUpdates < 4)
            {
                numUpdates++;
                return;
            }
            numUpdates = 0;

            //Updates frame
            frame++;
            if (frame >= sourceRectangle.Length)
            {
                frame = 0;
            }
        }

        public static void UpdateGoriyaFrame(ref int frame, Vector2 velocity)
        {
            //Waits for 4 updates to occur before doing another update
            if (numUpdates < 4)
            {
                numUpdates++;
                return;
            }
            numUpdates = 0;

            if (velocity.X > 0 && frame == 0)
            {
                frame = 1;
            }
            else if (velocity.X > 0)
            {
                frame = 0;
            }
            else if (velocity.X < 0 && frame == 4)
            {
                frame = 5;
            }
            else if (velocity.X < 0)
            {
                frame = 4;
            }
            else if (velocity.Y > 0 && frame == 6)
            {
                frame = 7;
            }
            else if (velocity.Y > 0)
            {
                frame = 6;
            }
            else if (velocity.Y < 0 && frame == 2)
            {
                frame = 3;
            }
            else
            {
                frame = 2;
            }
        }
    }
}
