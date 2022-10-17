using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    /// <summary>
    /// Class <c>SpriteRectangle</c> creates the frames for sprites.
    /// </summary>
    public abstract class SpriteRectangle
    {
        // TODO: Enums needed?
        //public enum Character { LINK };
        //public enum State { STANDING, RUNNING, ATTACKING };
        //public enum Direction { LEFT, RIGHT, UP, DOWN };
        //public enum Color { GREEN, BLUE, RED };
        //public enum Health { HEALTHY, DAMAGED };

        //Character character = Character.LINK;
        //State state = State.STANDING;
        //Direction direction = Direction.LEFT;
        //Color color = Color.GREEN;
        //Health health = Health.HEALTHY;

        /// <summary>
        /// Top left corner x-coordinate of rectangle containing sprites.
        /// </summary>
        /// <returns>The x-coordinate in pixels.</returns>
        public abstract int SourceX();
        /// <summary>
        /// Top left corner y-coordinate of rectangle containing sprites.
        /// </summary>
        /// <returns>The y-coordinate in pixels.</returns>
        public abstract int SourceY();
        /// <summary>
        /// The width of the rectangle containing the sprites.
        /// </summary>
        /// <returns>The width of the rectangle in pixels.</returns>
        public abstract int SourceWidth();
        /// <summary>
        /// The height of the rectangle containing the sprites.
        /// </summary>
        /// <returns>The height of the rectangle in pixels.</returns>
        public abstract int SourceHeight();
        /// <summary>
        /// The number of frames total for the sprite.
        /// </summary>
        /// <returns>The number of frames in the animation.</returns>
        public abstract int Frames();
        /// <summary>
        /// The number of colors the sprite will have.
        /// </summary>
        /// <returns>The number of colors the sprite will assume.</returns>
        public abstract int Colors();

        /// <summary>
        /// Create an array of rectangles, with each rectangle containing one frame of the sprite.
        /// </summary>
        /// <param name="finalizedRectangle"></param>
        /// <returns></returns>
        public Rectangle[] SourceRectangle(SpriteRectangle finalizedRectangle)
        {
            int colors = finalizedRectangle.Colors();
            int framesPerColor = finalizedRectangle.Frames() / colors;
            Rectangle[] frameCollection = new Rectangle[colors * framesPerColor];

            for (int color = 0; color < colors; color++)
            {
                for (int frame = 0; frame < framesPerColor; frame++)
                {
                    frameCollection[(framesPerColor * color) + frame] = new Rectangle(
                        finalizedRectangle.SourceX() + (color * Constants.HORIZONTAL_SPACE_BETWEEN_STATES),
                        finalizedRectangle.SourceY() + (frame % framesPerColor) * Constants.LINK_HEIGHT,
                        Constants.LINK_WIDTH,
                        Constants.LINK_HEIGHT);
                }
            }
            return frameCollection;
        }

        public static Rectangle[] Background = { new Rectangle(0, 0, Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT) };

        //Right, up, left, down is the order
        public static Rectangle[] arrow = { new Rectangle(210, 200, 16, 5), new Rectangle(123, 194, 10, 20),
            new Rectangle(150, 200, 16, 5), new Rectangle(186, 196, 10, 20)};

        public static Rectangle[] Empty =
        {
            new Rectangle(0, 0, 0, 0)
        };

        public static Rectangle[] LinkRunningRight =
        {
            new Rectangle(130, 10, 18, 18),
            new Rectangle(130, 50, 18, 18)
        };

        public static Rectangle[] LinkRunningLeft =
        {
            new Rectangle(50, 10, 18, 18),
            new Rectangle(50, 50, 18, 18)
        };

        public static Rectangle[] LinkRunningDown =
        {
            new Rectangle(10, 10, 18, 18),
            new Rectangle(10, 50, 18, 18)
        };

        public static Rectangle[] LinkRunningUp =
        {
            new Rectangle(90, 10, 18, 18),
            new Rectangle(90, 50, 18, 18)
        };

        public static Rectangle[] LinkStandingRight =
        {
            new Rectangle(130, 10, 18, 18)
        };

        public static Rectangle[] LinkStandingLeft =
        {
            new Rectangle(50, 10, 18, 18)
        };

        public static Rectangle[] LinkStandingDown =
        {
            new Rectangle(10, 10, 18, 18)
        };

        public static Rectangle[] LinkStandingUp =
        {
            new Rectangle(90, 10, 18, 18)
        };

        public static Rectangle[] LinkRunningRightDamaged =
{
            new Rectangle(130, 10, 18, 18),
            new Rectangle(130, 50, 18, 18),
            new Rectangle(291, 10, 18, 18),
            new Rectangle(291, 50, 18, 18)
        };

        public static Rectangle[] LinkRunningLeftDamaged =
        {
            new Rectangle(50, 10, 18, 18),
            new Rectangle(50, 50, 18, 18),
            new Rectangle(211, 10, 18, 18),
            new Rectangle(211, 50, 18, 18)
        };

        public static Rectangle[] LinkRunningDownDamaged =
        {
            new Rectangle(10, 10, 18, 18),
            new Rectangle(10, 50, 18, 18),
            new Rectangle(171, 10, 18, 18),
            new Rectangle(171, 50, 18, 18)
        };

        public static Rectangle[] LinkRunningUpDamaged =
        {
            new Rectangle(90, 10, 18, 18),
            new Rectangle(90, 50, 18, 18),
            new Rectangle(251, 10, 18, 18),
            new Rectangle(251, 50, 18, 18)
        };

        public static Rectangle[] LinkStandingRightDamaged =
        {
            new Rectangle(130, 10, 18, 18),
            new Rectangle(291, 10, 18, 18)
        };

        public static Rectangle[] LinkStandingLeftDamaged =
        {
            new Rectangle(50, 10, 18, 18),
            new Rectangle(211, 10, 18, 18)
        };

        public static Rectangle[] LinkStandingDownDamaged =
        {
            new Rectangle(10, 10, 18, 18),
            new Rectangle(171, 10, 18, 18)
        };

        public static Rectangle[] LinkStandingUpDamaged =
        {
            new Rectangle(90, 10, 18, 18),
            new Rectangle(251, 10, 18, 18)
        };
    }
}
