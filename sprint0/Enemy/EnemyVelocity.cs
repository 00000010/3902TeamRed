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
        public static void UpdateVelocity(GameTime gameTime, Rectangle[] sourceRectangle, ref Vector2 Velocity, ref Sprite testSprite)
        {
            //Grouping enemies based on movement
            if (sourceRectangle == EnemyRectangle.Gel || sourceRectangle == EnemyRectangle.Stalfos || 
                sourceRectangle == EnemyRectangle.GoriyaLeft || sourceRectangle == EnemyRectangle.GoriyaRight
                || sourceRectangle == EnemyRectangle.GoriyaUp || sourceRectangle == EnemyRectangle.GoriyaDown)
            {
                UpdateUniMovement(gameTime, ref Velocity, ref testSprite, sourceRectangle);
            }
            else if (sourceRectangle == EnemyRectangle.Keese)
            {
                UpdateKeeseMovement(gameTime, ref Velocity);
            }
        }

        public static void UpdateGoriyaFrame(Vector2 velocity, ref Sprite testSprite)
        {
            if (velocity.X > 0)
            {
                testSprite = SpriteFactory.Instance.GoriyaRight(testSprite.Position);
            }
            else if (velocity.X < 0)
            {
                testSprite = SpriteFactory.Instance.GoriyaLeft(testSprite.Position);
            }
            else if (velocity.Y < 0)
            {
                testSprite = SpriteFactory.Instance.GoriyaUp(testSprite.Position);
            }
            else
            {
                testSprite = SpriteFactory.Instance.GoriyaDown(testSprite.Position);
            }

            testSprite.Velocity = velocity;
        }

        public static void UpdateUniMovement(GameTime gameTime, ref Vector2 Velocity, ref Sprite testSprite, Rectangle[] sourceRectangle)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Let each character stay in the same direction for 1 second
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

            if (sourceRectangle != EnemyRectangle.Gel && sourceRectangle != EnemyRectangle.Stalfos) UpdateGoriyaFrame(Velocity, ref testSprite);
        }
        public static void UpdateKeeseMovement(GameTime gameTime, ref Vector2 Velocity)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Let each character stay in the same direction for 1 seconds
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
    }
}
