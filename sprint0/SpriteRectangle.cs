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
    public class SpriteRectangle
    {
        public static Rectangle[] LinkStandingForward =
        {
            new Rectangle(
                0,
                0,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT)
        };

        public static Rectangle[] LinkRunningForward()
        {
            Rectangle[] frameCollection = new Rectangle[Constants.MOVING_LINK_FRAMES];
            for (int i = 0; i < Constants.MOVING_LINK_FRAMES; i++)
            {
                frameCollection[i] = new Rectangle(Constants.FORWARD_RUNNING_LINK_X_1, Constants.FORWARD_RUNNING_BLUE_LINK_Y_1 * 2, Constants.LINK_WIDTH, Constants.LINK_HEIGHT);
            }
            return frameCollection;
        }

        public static Rectangle[] LinkStandingBackward() {
            Rectangle[] frameCollection = new Rectangle[1];
            frameCollection[0] = new Rectangle(
                Constants.BACKWARD_RUNNING_LINK_X_1,
                Constants.BACKWARD_RUNNING_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT);
            return frameCollection;
        }

        public static Rectangle[] LinkRunningBackward()
        {
            Rectangle [] frameCollection = new Rectangle[Constants.MOVING_LINK_FRAMES];
            for (int i = 0; i < Constants.MOVING_LINK_FRAMES; i++) {
                frameCollection[i] = new Rectangle(Constants.BACKWARD_RUNNING_LINK_X_1, Constants.BACKWARD_RUNNING_BLUE_LINK_Y_1 * 2, Constants.LINK_WIDTH, Constants.LINK_HEIGHT);
            }
            return frameCollection;
        }

        public static Rectangle[] LinkStandingLeft = {
            new Rectangle(
                Constants.LEFT_RUNNING_LINK_X_2,
                Constants.LEFT_RUNNING_LINK_Y_2,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT)
        };

        public static Rectangle[] LinkRunningLeft = {
            new Rectangle(
                Constants.LEFT_RUNNING_LINK_X_1,
                Constants.LEFT_RUNNING_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.LEFT_RUNNING_LINK_X_2,
                Constants.LEFT_RUNNING_LINK_Y_2,
                Constants.LINK_WIDTH,
                Constants.LINK_WIDTH)
        };

        public static Rectangle[] LinkStandingRight = {
            new Rectangle(
                Constants.RIGHT_RUNNING_LINK_X_1,
                Constants.RIGHT_RUNNING_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT)
        };

        public static Rectangle[] LinkRunningRight = {
            new Rectangle(
                Constants.RIGHT_RUNNING_LINK_X_1,
                Constants.RIGHT_RUNNING_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.RIGHT_RUNNING_LINK_X_2,
                Constants.RIGHT_RUNNING_LINK_Y_2,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT)
        };

        public static Rectangle[] LinkDamagedStandingForward =
        {
            new Rectangle(
                Constants.FORWARD_RUNNING_LINK_X_1,
                Constants.FORWARD_RUNNING_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.LEFT_RUNNING_BLUE_LINK_X_1,
                Constants.LEFT_RUNNING_BLUE_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.LEFT_RUNNING_RED_LINK_X_1,
                Constants.LEFT_RUNNING_RED_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
        };

        public static Rectangle[] LinkDamagedRunningForward =
        {
            new Rectangle(
                Constants.FORWARD_RUNNING_LINK_X_1,
                Constants.FORWARD_RUNNING_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.FORWARD_RUNNING_LINK_X_2,
                Constants.FORWARD_RUNNING_LINK_Y_2,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.LEFT_RUNNING_BLUE_LINK_X_1,
                Constants.LEFT_RUNNING_BLUE_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.LEFT_RUNNING_BLUE_LINK_X_2,
                Constants.LEFT_RUNNING_BLUE_LINK_Y_2,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.LEFT_RUNNING_RED_LINK_X_1,
                Constants.LEFT_RUNNING_RED_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.LEFT_RUNNING_RED_LINK_X_2,
                Constants.LEFT_RUNNING_RED_LINK_Y_2,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT)
        };

        public static Rectangle[] LinkDamagedStandingBackward =
        {
            new Rectangle(
                Constants.BACKWARD_RUNNING_LINK_X_1,
                Constants.BACKWARD_RUNNING_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.BACKWARD_RUNNING_BLUE_LINK_X_1,
                Constants.BACKWARD_RUNNING_BLUE_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.BACKWARD_RUNNING_RED_LINK_X_1,
                Constants.BACKWARD_RUNNING_RED_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
        };

        public static Rectangle[] LinkDamagedRunningBackward =
        {
            new Rectangle(
                Constants.BACKWARD_RUNNING_LINK_X_1,
                Constants.BACKWARD_RUNNING_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.BACKWARD_RUNNING_LINK_X_2,
                Constants.BACKWARD_RUNNING_LINK_Y_2,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.BACKWARD_RUNNING_BLUE_LINK_X_1,
                Constants.BACKWARD_RUNNING_BLUE_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.BACKWARD_RUNNING_BLUE_LINK_X_2,
                Constants.BACKWARD_RUNNING_BLUE_LINK_Y_2,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.BACKWARD_RUNNING_RED_LINK_X_1,
                Constants.BACKWARD_RUNNING_RED_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.BACKWARD_RUNNING_RED_LINK_X_2,
                Constants.BACKWARD_RUNNING_RED_LINK_Y_2,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT)
        };

        public static Rectangle[] LinkDamagedStandingLeft =
        {
            new Rectangle(
                Constants.LEFT_RUNNING_LINK_X_1,
                Constants.LEFT_RUNNING_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.LEFT_RUNNING_BLUE_LINK_X_1,
                Constants.LEFT_RUNNING_BLUE_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.LEFT_RUNNING_RED_LINK_X_1,
                Constants.LEFT_RUNNING_RED_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
        };

        public static Rectangle[] LinkDamagedRunningLeft =
        {
            new Rectangle(
                Constants.LEFT_RUNNING_LINK_X_1,
                Constants.LEFT_RUNNING_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.LEFT_RUNNING_LINK_X_2,
                Constants.LEFT_RUNNING_LINK_Y_2,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.LEFT_RUNNING_BLUE_LINK_X_1,
                Constants.LEFT_RUNNING_BLUE_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.LEFT_RUNNING_BLUE_LINK_X_2,
                Constants.LEFT_RUNNING_BLUE_LINK_Y_2,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.LEFT_RUNNING_RED_LINK_X_1,
                Constants.LEFT_RUNNING_RED_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.LEFT_RUNNING_RED_LINK_X_2,
                Constants.LEFT_RUNNING_RED_LINK_Y_2,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT)
        };

        public static Rectangle[] LinkDamagedStandingRight =
        {
            new Rectangle(
                Constants.RIGHT_RUNNING_LINK_X_1,
                Constants.RIGHT_RUNNING_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.RIGHT_RUNNING_BLUE_LINK_X_1,
                Constants.RIGHT_RUNNING_BLUE_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.RIGHT_RUNNING_RED_LINK_X_1,
                Constants.RIGHT_RUNNING_RED_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
        };

        public static Rectangle[] LinkDamagedRunningRight =
        {
            new Rectangle(
                Constants.RIGHT_RUNNING_LINK_X_1,
                Constants.RIGHT_RUNNING_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.RIGHT_RUNNING_LINK_X_2,
                Constants.RIGHT_RUNNING_LINK_Y_2,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.RIGHT_RUNNING_BLUE_LINK_X_1,
                Constants.RIGHT_RUNNING_BLUE_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.RIGHT_RUNNING_BLUE_LINK_X_2,
                Constants.RIGHT_RUNNING_BLUE_LINK_Y_2,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.RIGHT_RUNNING_RED_LINK_X_1,
                Constants.RIGHT_RUNNING_RED_LINK_Y_1,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT),
            new Rectangle(
                Constants.RIGHT_RUNNING_RED_LINK_X_2,
                Constants.RIGHT_RUNNING_RED_LINK_Y_2,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT)
        };
    }
}
