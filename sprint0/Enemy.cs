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
    internal class Enemy : Sprite
    {

        //Constructor gets inherited from Sprite
        public Enemy(Texture2D texture, Rectangle[] sourceRectangle, SpriteBatch spriteBatch, Vector2 position, Vector2 velocity) 
            : base(texture, sourceRectangle, spriteBatch, position, velocity)
        {
        }

        /**
         * Handling the velocities of the different enemies
         */
        protected override void UpdateVelocity(GameTime gameTime)
        {
            //Setting the velocity's value too low to figure out if it changed
            Vector2 currVelocity = new Vector2(-100);
            EnemyVelocity.UpdateVelocity(gameTime, SourceRectangle, ref currVelocity);
            
            if (currVelocity.X != -100)
            {
                Velocity = currVelocity;
            }
        }

        /**
         * Handling the position of the enemies
         */
        protected override void UpdatePosition()
        {
            Position += Velocity;
        }

        /**
         * Handling the frame updates for the enemies
         */
        protected override void UpdateFrame()
        {
            //Waits for 4 updates to occur before doing another update
            if (NumUpdates < 4)
            {
                NumUpdates++;
                return;
            }
            NumUpdates = 0;

            //Updates frame
            Frame++;
            if (Frame >= SourceRectangle.Length)
            {
                Frame = 0;
            }
        }
    }
}
