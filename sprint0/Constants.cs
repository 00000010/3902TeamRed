using System;
using System.Threading.Channels;

namespace sprint0
{
    public class Constants
    {
        private Constants() { }

        /* TODO: Clean this class up by photoshopping the spritesheet so frames
         * are next to each other. May want to make separate spritesheets (one
         * for Link, one for explosions, and one for items, for example) */

        /// <summary>
        /// Number of frames for the Link sprite running or attacking.
        /// </summary>
        public const int MOVING_LINK_FRAMES = 2;

        /// <summary>
        /// Size of Link sprite. Link is 16x16 pixels wide, but there is 6
        /// pixels of space per side to account for Link's sword. Place sprite
        /// carefully.
        /// </summary>
        public const int LINK_WIDTH = 40;
        public const int LINK_HEIGHT = 40;

        public const int NUM_OF_DIRECTIONS = 4;
        public const int NUM_OF_COLORS = 3;

        // TODO: LINK_ROWS and LINK_SHEET_HEIGHT necessary?
        public const int LINK_ROWS = 5;
        public const int LINK_COLUMNS = 12;
        public const int LINK_SHEET_WIDTH = LINK_WIDTH * NUM_OF_DIRECTIONS * NUM_OF_COLORS;
        public const int LINK_SHEET_HEIGHT = LINK_HEIGHT * NUM_OF_DIRECTIONS * NUM_OF_COLORS;

        public const int HORIZONTAL_SPACE_BETWEEN_STATES = LINK_WIDTH * NUM_OF_DIRECTIONS;

        // TODO: Delete constants?
        /// <summary>
        /// Top left corner coordinates to capture the Link sprite facing
        /// forward, backward, left, right from the sprite sheet.Units are in
        /// pixels.Last number indicates the frame.
        /// </summary>
        public const int FORWARD_RUNNING_LINK_X_1 = 0;
        public const int FORWARD_RUNNING_LINK_Y_1 = 0;

        public const int FORWARD_RUNNING_LINK_X_2 = 0;
        public const int FORWARD_RUNNING_LINK_Y_2 = 30;

        public const int BACKWARD_RUNNING_LINK_X_1 = 62;
        public const int BACKWARD_RUNNING_LINK_Y_1 = 0;

        public const int BACKWARD_RUNNING_LINK_X_2 = 62;
        public const int BACKWARD_RUNNING_LINK_Y_2 = 30;

        public const int LEFT_RUNNING_LINK_X_1 = 30;
        public const int LEFT_RUNNING_LINK_Y_1 = 0;

        public const int LEFT_RUNNING_LINK_X_2 = 30;
        public const int LEFT_RUNNING_LINK_Y_2 = 30;

        public const int RIGHT_RUNNING_LINK_X_1 = 89;
        public const int RIGHT_RUNNING_LINK_Y_1 = 0;

        public const int RIGHT_RUNNING_LINK_X_2 = 89;
        public const int RIGHT_RUNNING_LINK_Y_2 = 30;

        /// <summary>
        /// Top left corner coordinates to capture the DAMAGED Link sprite facing
        /// forward, backward, left, right from the sprite sheet.Link will
        /// change colors when damaged between regular green, blue, and red.
        /// Units are in pixels.Last number indicates the frame.
        /// </summary>
        public const int FORWARD_RUNNING_BLUE_LINK_X_1 = 120;
        public const int FORWARD_RUNNING_BLUE_LINK_Y_1 = 0;

        public const int FORWARD_RUNNING_BLUE_LINK_X_2 = 120;
        public const int FORWARD_RUNNING_BLUE_LINK_Y_2 = 30;

        public const int FORWARD_RUNNING_RED_LINK_X_1 = 240;
        public const int FORWARD_RUNNING_RED_LINK_Y_1 = 0;

        public const int FORWARD_RUNNING_RED_LINK_X_2 = 240;
        public const int FORWARD_RUNNING_RED_LINK_Y_2 = 30;

        public const int BACKWARD_RUNNING_BLUE_LINK_X_1 = 181;
        public const int BACKWARD_RUNNING_BLUE_LINK_Y_1 = 0;

        public const int BACKWARD_RUNNING_BLUE_LINK_X_2 = 181;
        public const int BACKWARD_RUNNING_BLUE_LINK_Y_2 = 30;

        public const int BACKWARD_RUNNING_RED_LINK_X_1 = 300;
        public const int BACKWARD_RUNNING_RED_LINK_Y_1 = 0;

        public const int BACKWARD_RUNNING_RED_LINK_X_2 = 300;
        public const int BACKWARD_RUNNING_RED_LINK_Y_2 = 30;

        public const int LEFT_RUNNING_BLUE_LINK_X_1 = 150;
        public const int LEFT_RUNNING_BLUE_LINK_Y_1 = 0;

        public const int LEFT_RUNNING_BLUE_LINK_X_2 = 150;
        public const int LEFT_RUNNING_BLUE_LINK_Y_2 = 30;

        public const int LEFT_RUNNING_RED_LINK_X_1 = 270;
        public const int LEFT_RUNNING_RED_LINK_Y_1 = 0;

        public const int LEFT_RUNNING_RED_LINK_X_2 = 270;
        public const int LEFT_RUNNING_RED_LINK_Y_2 = 30;

        public const int RIGHT_RUNNING_BLUE_LINK_X_1 = 210;
        public const int RIGHT_RUNNING_BLUE_LINK_Y_1 = 0;

        public const int RIGHT_RUNNING_BLUE_LINK_X_2 = 210;
        public const int RIGHT_RUNNING_BLUE_LINK_Y_2 = 30;

        public const int RIGHT_RUNNING_RED_LINK_X_1 = 330;
        public const int RIGHT_RUNNING_RED_LINK_Y_1 = 0;

        public const int RIGHT_RUNNING_RED_LINK_X_2 = 330;
        public const int RIGHT_RUNNING_RED_LINK_Y_2 = 30;
    }
}

