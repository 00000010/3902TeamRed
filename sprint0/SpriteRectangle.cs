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
        public enum Health { HEALTHY, DAMAGED };

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
            /* TODO: change Frames() description; should be frames per color */
            int colors = finalizedRectangle.Colors();
            int framesPerColor = finalizedRectangle.Frames() / colors;
            Rectangle[] frameCollection = new Rectangle[colors * framesPerColor];
            Console.WriteLine("colors: " + colors);
            Console.WriteLine("framesPerColor: " + framesPerColor);
            Console.WriteLine("frames: " + finalizedRectangle.Frames());
            Console.WriteLine("Size: " + (colors * framesPerColor));
            for (int color = 0; color < colors; color++)
            {
                for (int frame = 0; frame < framesPerColor; frame++)
                {
                    Console.WriteLine("i: " + ((framesPerColor * color) + frame));
                    Console.WriteLine("frame: " + frame);
                    frameCollection[(framesPerColor * color) + frame] = new Rectangle(
                        finalizedRectangle.SourceX() + (color * Constants.HORIZONTAL_SPACE_BETWEEN_STATES),
                        finalizedRectangle.SourceY() + (frame % framesPerColor) * Constants.LINK_HEIGHT,
                        Constants.LINK_WIDTH,
                        Constants.LINK_HEIGHT);
                    Console.WriteLine("X: " + (color * Constants.HORIZONTAL_SPACE_BETWEEN_STATES));
                    Console.WriteLine("Y: " + (finalizedRectangle.SourceY() + frame * Constants.LINK_HEIGHT));
                }
            }
            /*
             * Standing:         colors: 1 frames: 1 => 1 times
             * color: 0 frame: 0 [0]
             * Running:          colors: 1 frames: 2 => 2 times
             * color: 0 frame: 0 [0]
             * color: 0 frame: 1 [1]
             * Standing damaged: colors: 3 frames: 3 => 3 times
             * color: 0 frame: 0 [0]
             * color: 1 frame: 0 [1]
             * color: 2 frame: 0 [2]
             * Running damaged:  colors: 3 frames: 6 => 6 times
             * color: 0 frame: 0 [0]
             * color: 0 frame: 1 [1]
             * color: 1 frame: 0 [2]
             * color: 1 frame: 1 [3]
             * color: 2 frame: 0 [4]
             * color: 2 frame: 1 [5]
             * 
             */
            //Console.WriteLine("Official frames: " + frameCollection.Length);
            return frameCollection;
        }

        public static Rectangle[] arrowRight = { new Rectangle(210, 200, 16, 5) };
    }
}
