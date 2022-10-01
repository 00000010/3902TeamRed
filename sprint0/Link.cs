using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Link : Player
    {
        public enum STATE { STANDING, RUNNING, ATTACKING };
        public enum DIRECTION { LEFT, RIGHT, UP, DOWN };
        public enum HEALTH { HEALTHY, DAMAGED };
        public enum COLORS { GREEN, BLUE, RED };

        private STATE state = STATE.STANDING;
        private HEALTH health = HEALTH.HEALTHY;
        private COLORS colors = COLORS.GREEN;

        private STATE prevState = STATE.STANDING;
        private DIRECTION prevDirection = DIRECTION.DOWN;

        private int timer = 10;

        public Link(Texture2D texture, Rectangle[] sourceRectangle, SpriteBatch spriteBatch, Vector2 position)
            : base(texture, sourceRectangle, spriteBatch, position)
        {
            if (sourceRectangle[0].X == 0)
            {
                prevDirection = DIRECTION.DOWN;
            }
            else if (sourceRectangle[0].X == Constants.LINK_WIDTH)
            {
                prevDirection = DIRECTION.LEFT;
            }
            else if (sourceRectangle[0].X == Constants.LINK_WIDTH * 2)
            {
                prevDirection = DIRECTION.UP;
            }
            else
            {
                prevDirection = DIRECTION.RIGHT;
            }
        }

        public override void Update(GameTime gameTime)
        {
            UpdateVelocity(gameTime);
            UpdateFrames(gameTime);
            UpdatePosition(gameTime);
        }

        private void UpdateFrames(GameTime gameTime)
        {
            Frame++;
            /* If Link is damaged or the timer is counting */
            if (health == HEALTH.DAMAGED && timer > 0)
            {
                /* Continue damaging Link */
                timer--;
            } else if (timer <= 0)
            {
                /* Link is or is now healthy - stop damage */
                timer = 10;
                UnDamage(gameTime);
            }

            /* Wrap around to first frame if on last frame */
            if (Frame == SourceRectangle.Length)
            {
                Frame = 0;
            }
        }

        private void UpdateVelocity(GameTime gameTime)
        {
            //no-op
            return;
        }

        private void UpdatePosition(GameTime gameTime)
        {
            Position += Velocity;

            // wrap around screen
            if (Position.X > 800)
            {
                this.Position = new Vector2(0 - SourceRectangle[Frame].Width * 10, Position.Y);
            }

            if (Position.Y > 480)
            {
                this.Position = new Vector2(Position.X, 0 - SourceRectangle[Frame].Height * 10);
            }
        }

        /* Make Link undamaged (if healthy, does nothing) */
        private void UnDamage(GameTime gameTime)
        {
            if (health == HEALTH.DAMAGED)
            {
                health = HEALTH.HEALTHY;
                SpriteRectangle sR = new LinkRectangle(
                    SourceRectangle[0].X,
                    SourceRectangle[0].Y,
                    SourceRectangle.Length);
                SourceRectangle = sR.SourceRectangle(sR);
                Frame = 0;
            }
        }
    }
}

