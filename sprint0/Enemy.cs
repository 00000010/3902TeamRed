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
            if (Position.X > 800 || Position.X < 0)
            {
                Position = new Vector2(Position.X - Velocity.X, Position.Y);
            }
            if (Position.Y > 480 || Position.Y < 0)
            {
                Position = new Vector2(Position.X, Position.Y - Velocity.Y);
            }
        }

        /**
         * Handling the frame updates for the enemies
         */
        protected override void UpdateFrame()
        {
            int frame = Frame;
            EnemyFrame.UpdateFrame(SourceRectangle, ref frame, Velocity);
            Frame = frame;
        }
    }
}
