using System;
using System.Threading.Channels;

namespace sprint0
{
    public class Constants
    {
        private Constants() { }

        public const int BLOCK_SIZE = 16 * SCALING_FACTOR;

        // TODO: SCALING_FACTOR should affect these
        // Position of room
        public const int ROOM_X = 150;
        public const int ROOM_Y = 120;

        // Room (not including HUD or outside black space) width and height
        public const int ROOM_WIDTH = 256;
        public const int ROOM_HEIGHT = 176;
        public const int SCALED_ROOM_WIDTH = 256 * SCALING_FACTOR;
        public const int SCALED_ROOM_HEIGHT = 176 * SCALING_FACTOR;

        /// <summary>
        /// Number of frames for the Link sprite running or attacking.
        /// </summary>
        public const int MOVING_LINK_FRAMES = 2;

        /// <summary>
        /// Size of Link sprite. Link is 16x16 pixels wide, but there is 6
        /// pixels of space per side to account for Link's sword. Place sprite
        /// carefully.
        /// </summary>
        public const int LINK_WIDTH = 40 * SCALING_FACTOR;
        public const int LINK_HEIGHT = 40 * SCALING_FACTOR;

        public const int NUM_OF_DIRECTIONS = 4;
        public const int NUM_OF_COLORS = 3;

        // TODO: LINK_ROWS and LINK_SHEET_HEIGHT necessary?
        public const int LINK_ROWS = 5;
        public const int LINK_COLUMNS = 12;
        public const int LINK_SHEET_WIDTH = LINK_WIDTH * NUM_OF_DIRECTIONS * NUM_OF_COLORS;
        public const int LINK_SHEET_HEIGHT = LINK_HEIGHT * NUM_OF_DIRECTIONS * NUM_OF_COLORS;

        public const int HORIZONTAL_SPACE_BETWEEN_STATES = LINK_WIDTH * NUM_OF_DIRECTIONS;

        public const int FROM_DOWN_LINK_POSITION_X = 366;
        public const int FROM_DOWN_LINK_POSITION_Y = 352;
        public const int FROM_UP_LINK_POSITION_X = 366;
        public const int FROM_UP_LINK_POSITION_Y = 160;
        public const int FROM_LEFT_LINK_POSITION_X = 190;
        public const int FROM_LEFT_LINK_POSITION_Y = 256;
        public const int FROM_RIGHT_LINK_POSITION_X = 540;
        public const int FROM_RIGHT_LINK_POSITION_Y = 256;

        public const int NUM_OF_LEVELS = 18; // TODO: set to correct number

        public const string LEVEL_FILE_PREFIX = "Level";

        public const float BACKGROUND_LAYER_DEPTH = 0.0f;
        public const float BACKGROUND_BLOCK_LAYER_DEPTH = 0.1f;
        public const float BLOCK_LAYER_DEPTH = 0.2f;
        public const float DOOR_LAYER_DEPTH = 0.3f;
        public const float ITEM_LAYER_DEPTH = 0.6f;
        public const float PROJECTILE_LAYER_DEPTH = 0.7f;
        public const float ENEMY_LAYER_DEPTH = 0.8f;
        public const float PLAYER_LAYER_DEPTH = 0.9f;
        public const float TEXT_LAYER_DEPTH = 1.0f;

        public const int NUM_AVAILABLE_PROJECTILES = 3;

        public const int SCALING_FACTOR = 2;

        public const int IMPOSSIBLE_VALUE = -SCALED_ROOM_WIDTH - 1;
        public const int CAMERA_SPEED = 4;
    }
}

