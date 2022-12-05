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

        public static Rectangle[] Background = { new Rectangle(0, 0, Constants.ROOM_WIDTH, Constants.ROOM_HEIGHT) };

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

        public static Rectangle[] LinkThrowingUp =
        {
            new Rectangle(80, 80, 40, 40)
        };

        public static Rectangle[] LinkThrowingDown =
        {
            new Rectangle(0, 80, 40, 40)
        };

        public static Rectangle[] LinkThrowingLeft =
        {
            new Rectangle(40, 80, 40, 40)
        };

        public static Rectangle[] LinkThrowingRight =
        {
            new Rectangle(120, 80, 40, 40)
        };

        public static Rectangle[] ProjectileEffect =
        {
            new Rectangle(149, 238, 20, 20),
            new Rectangle(178, 283, 20, 20)
        };


        /*
         * HUD
         */
        public static Rectangle[] ZeldaCurrProjectile =
        {
            new Rectangle(16, 34, 100, 65)
        };

        public static Rectangle[] ZeldaAvailProjectiles =
        {
            new Rectangle(123, 53, 100, 45)
        };

        public static Rectangle[] ZeldaMapAndCompassHUD =
        {
            new Rectangle(280, 116, 60, 60)
        };

        public static Rectangle[] ZeldaMapHUD =
        {
            new Rectangle(354, 113, 130, 83)
        };

        public static Rectangle[] ZeldaOrangeBlockHUD =
        {
            new Rectangle(355, 117, 30, 70)
        };

        public static Rectangle[] ZeldaInventoryHUD =
        {
            new Rectangle(343, 25, 150, 40)
        };

        public static Rectangle[] ZeldaLevelHUD =
        {
            new Rectangle(585, 1, 45, 7)
        };

        public static Rectangle[] ZeldaNumOneHUD =
        {
            new Rectangle(537, 117, 8, 7)
        };

        public static Rectangle[] ZeldaDoubleBlueHUD =
        {
            new Rectangle(681, 108, 7, 7)
        };

        public static Rectangle[] ZeldaBlueMapHUD =
        {
            new Rectangle(112, 167, 60, 35)
        };

        public static Rectangle[] ZeldaOrangeMapHUD =
        {
            new Rectangle(0, 0, 80, 70)
        };

        public static Rectangle[] Logo =
        {
            new Rectangle(0, 0, 256, 120)
        };

        public static Rectangle[] ZeldaBlueBox =
        {
            new Rectangle(60, 53, 26, 26)
        };

        public static Rectangle[] BluePixels =
        {
            new Rectangle(0, 0, 5, 4)
        };

        public static Rectangle[] GreenPixel =
        {
            new Rectangle(1, 4, 1, 2)
        };

        public static Rectangle[] RedPixel =
        {
            new Rectangle(3, 4, 1, 2)
        };
    }
}
