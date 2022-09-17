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
    internal static class EnemyVelocity
    {
        private static float elapsedTime = 0;
        private static Random randomGen = new Random();
        public static void UpdateVelocity(GameTime gameTime, Rectangle[] sourceRectangle, ref Vector2 Velocity)
        {
            //Grouping enemies based on movement
            if (sourceRectangle == EnemyRectangle.Gel || sourceRectangle == EnemyRectangle.Stalfos
                || sourceRectangle == EnemyRectangle.Goriya)
            {
                UpdateUniMovement(gameTime, ref Velocity);
            }
            else if (sourceRectangle == EnemyRectangle.Keese)
            {
                UpdateKeeseMovement(gameTime, ref Velocity);
            }
            else if (sourceRectangle == EnemyRectangle.Octorok)
            {
                UpdateOctorokMovement(gameTime, ref Velocity);
            }
        }

        public static void UpdateUniMovement(GameTime gameTime, ref Vector2 Velocity)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Let each character stay in the same direction for 2 seconds
            if (elapsedTime < 1)
            {
                return;
            }
            else
            {
                //Restart counter
                elapsedTime = 0;
            }

            int randomDirection = randomGen.Next(0, 2);
            int randomSpeed = randomGen.Next(-1, 2);
            while (randomSpeed == 0)
            {
                randomSpeed = randomGen.Next(-1, 2);
            }

            //Update X
            if (randomDirection == 0)
            {
                Velocity = new Vector2(randomSpeed, 0);

            }
            else
            {
                Velocity = new Vector2(0, randomSpeed);
            }
        }
        public static void UpdateKeeseMovement(GameTime gameTime, ref Vector2 Velocity)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Let each character stay in the same direction for 2 seconds
            if (elapsedTime < 1)
            {
                return;
            }
            else
            {
                //Restart counter
                elapsedTime = 0;
            }

            //Randomize both x and y
            int randomSpeedX = randomGen.Next(-1, 2);
            int randomSpeedY = randomGen.Next(-1, 2);

            Velocity = new Vector2(randomSpeedX, randomSpeedY);
        }

        public static void UpdateOctorokMovement(GameTime gameTime, ref Vector2 Velocity)
        {
            Velocity = new Vector2(0, 0);
        }
    }
}
