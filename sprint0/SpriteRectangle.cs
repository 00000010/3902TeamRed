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
        // Top left corner x-coordinate of rectangle containing sprites.
        public abstract int SourceX();

        // Top left corner y-coordinate of rectangle containing sprites.
        public abstract int SourceY();

        // The width of the rectangle containing the sprites.
        public abstract int SourceWidth();

        // The height of the rectangle containing the sprites.
        public abstract int SourceHeight();

        // The number of frames total for the sprite.
        public abstract int Frames();

        // The number of colors the sprite will have.
        public abstract int Colors();

        // Create an array of rectangles, with each rectangle containing one frame of the sprite.
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
            new Rectangle(120, 0, 40, 40),
            new Rectangle(120, 40, 40, 40)
        };

        public static Rectangle[] LinkRunningLeft =
        {
            new Rectangle(40, 0, 40, 40),
            new Rectangle(40, 40, 40, 40)
        };

        public static Rectangle[] LinkRunningDown =
        {
            new Rectangle(0, 0, 40, 40),
            new Rectangle(0, 40, 40, 40)
        };

        public static Rectangle[] LinkRunningUp =
        {
            new Rectangle(80, 0, 40, 40),
            new Rectangle(80, 40, 40, 40)
        };

        public static Rectangle[] LinkStandingRight =
        {
            new Rectangle(120, 0, 40, 40)
        };

        public static Rectangle[] LinkStandingLeft =
        {
            new Rectangle(40, 0, 40, 40)
        };

        public static Rectangle[] LinkStandingDown =
        {
            new Rectangle(0, 0, 40, 40)
        };

        public static Rectangle[] LinkStandingUp =
        {
            new Rectangle(80, 0, 40, 40)
        };

        public static Rectangle[] LinkRunningRightDamaged =
{
            new Rectangle(120, 0, 40, 40),
            new Rectangle(120, 40, 40, 40),
            new Rectangle(280, 0, 40, 40),
            new Rectangle(280, 40, 40, 40)
        };

        public static Rectangle[] LinkRunningLeftDamaged =
        {
            new Rectangle(40, 0, 40, 40),
            new Rectangle(40, 40, 40, 40),
            new Rectangle(200, 0, 40, 40),
            new Rectangle(200, 40, 40, 40)
        };

        // TODO: looks weird
        public static Rectangle[] LinkRunningDownDamaged =
        {
            new Rectangle(0, 0, 40, 40),
            new Rectangle(0, 40, 40, 40),
            new Rectangle(160, 0, 40, 40),
            new Rectangle(160, 40, 40, 40)
        };

        public static Rectangle[] LinkRunningUpDamaged =
        {
            new Rectangle(80, 0, 40, 40),
            new Rectangle(80, 40, 40, 40),
            new Rectangle(240, 0, 40, 40),
            new Rectangle(240, 40, 40, 40)
        };

        public static Rectangle[] LinkStandingRightDamaged =
        {
            new Rectangle(120, 0, 40, 40),
            new Rectangle(280, 0, 40, 40)
        };

        public static Rectangle[] LinkStandingLeftDamaged =
        {
            new Rectangle(40, 0, 40, 40),
            new Rectangle(200, 0, 40, 40)
        };

        public static Rectangle[] LinkStandingDownDamaged =
        {
            new Rectangle(0, 0, 40, 40),
            new Rectangle(160, 40, 40, 40)
        };

        public static Rectangle[] LinkStandingUpDamaged =
        {
            new Rectangle(80, 0, 40, 40),
            new Rectangle(240, 40, 40, 40)
        };

        public static Rectangle[] LinkAttackingRight =
        {
            new Rectangle(120, 80, 40, 40),
            new Rectangle(120, 120, 40, 40),
            new Rectangle(120, 120, 40, 40),
            new Rectangle(120, 120, 40, 40),
            new Rectangle(120, 120, 40, 40),
            new Rectangle(120, 120, 40, 40),
            new Rectangle(120, 120, 40, 40),
            new Rectangle(120, 120, 40, 40)
        };

        public static Rectangle[] LinkAttackingLeft =
        {
            new Rectangle(40, 80, 40, 40),
            new Rectangle(40, 120, 40, 40),
            new Rectangle(40, 120, 40, 40),
            new Rectangle(40, 120, 40, 40),
            new Rectangle(40, 120, 40, 40),
            new Rectangle(40, 120, 40, 40),
            new Rectangle(40, 120, 40, 40),
            new Rectangle(40, 120, 40, 40)
        };

        public static Rectangle[] LinkAttackingDown =
        {
            new Rectangle(0, 80, 40, 40),
            new Rectangle(0, 120, 40, 40),
            new Rectangle(0, 120, 40, 40),
            new Rectangle(0, 120, 40, 40),
            new Rectangle(0, 120, 40, 40),
            new Rectangle(0, 120, 40, 40),
            new Rectangle(0, 120, 40, 40),
            new Rectangle(0, 120, 40, 40)
        };

        public static Rectangle[] LinkAttackingUp =
        {
            new Rectangle(80, 80, 40, 40),
            new Rectangle(80, 120, 40, 40),
            new Rectangle(80, 120, 40, 40),
            new Rectangle(80, 120, 40, 40),
            new Rectangle(80, 120, 40, 40),
            new Rectangle(80, 120, 40, 40),
            new Rectangle(80, 120, 40, 40),
            new Rectangle(80, 120, 40, 40)
        };

        public static Rectangle[] LinkAttackingRightDamaged =
        {
            new Rectangle(120, 80, 40, 40),
            new Rectangle(280, 120, 40, 40),
            new Rectangle(120, 120, 40, 40),
            new Rectangle(280, 120, 40, 40),
            new Rectangle(120, 120, 40, 40),
            new Rectangle(280, 120, 40, 40),
            new Rectangle(120, 120, 40, 40),
            new Rectangle(280, 120, 40, 40)
        };

        public static Rectangle[] LinkAttackingLeftDamaged =
        {
            new Rectangle(40, 80, 40, 40),
            new Rectangle(200, 120, 40, 40),
            new Rectangle(40, 120, 40, 40),
            new Rectangle(200, 120, 40, 40),
            new Rectangle(40, 120, 40, 40),
            new Rectangle(200, 120, 40, 40),
            new Rectangle(40, 120, 40, 40),
            new Rectangle(200, 120, 40, 40)
        };

        public static Rectangle[] LinkAttackingDownDamaged =
        {
            new Rectangle(0, 80, 40, 40),
            new Rectangle(160, 120, 40, 40),
            new Rectangle(0, 120, 40, 40),
            new Rectangle(160, 120, 40, 40),
            new Rectangle(0, 120, 40, 40),
            new Rectangle(160, 120, 40, 40),
            new Rectangle(0, 120, 40, 40),
            new Rectangle(160, 120, 40, 40)
        };

        public static Rectangle[] LinkAttackingUpDamaged =
        {
            new Rectangle(80, 80, 40, 40),
            new Rectangle(240, 120, 40, 40),
            new Rectangle(80, 120, 40, 40),
            new Rectangle(240, 120, 40, 40),
            new Rectangle(80, 120, 40, 40),
            new Rectangle(240, 120, 40, 40),
            new Rectangle(80, 120, 40, 40),
            new Rectangle(240, 120, 40, 40)
        };
    }
}
