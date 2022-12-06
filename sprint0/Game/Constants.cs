using System;
using System.IO;
using System.Threading.Channels;

namespace sprint0
{
    public class Constants
    {
        private Constants() { }

        public const int BLOCK_SIZE = 16 * SCALING_FACTOR;

        // Position of room (depends on SCALING_FACTOR)
        public const int ROOM_X = 150;
        public const int ROOM_Y = 120;

        // Room (not including HUD or outside black space) width and height
        public const int ROOM_WIDTH = 256;
        public const int ROOM_HEIGHT = 176;
        public const int SCALED_ROOM_WIDTH = 256 * SCALING_FACTOR;
        public const int SCALED_ROOM_HEIGHT = 176 * SCALING_FACTOR;

        /// <summary>
        /// Size of Link sprite. Link is 16x16 pixels wide, but there is 6
        /// pixels of space per side to account for Link's sword. Place sprite
        /// carefully.
        /// </summary>
        public const int LINK_WIDTH = 40 * SCALING_FACTOR;
        public const int LINK_HEIGHT = 40 * SCALING_FACTOR;

        public const int FROM_DOWN_LINK_POSITION_X = 366;
        public const int FROM_DOWN_LINK_POSITION_Y = 352;
        public const int FROM_UP_LINK_POSITION_X = 366;
        public const int FROM_UP_LINK_POSITION_Y = 160;
        public const int FROM_LEFT_LINK_POSITION_X = 190;
        public const int FROM_LEFT_LINK_POSITION_Y = 256;
        public const int FROM_RIGHT_LINK_POSITION_X = 540;
        public const int FROM_RIGHT_LINK_POSITION_Y = 256;

        public const int DOOR_NORTH_POSITION_X = 374;
        public const int DOOR_NORTH_POSITION_Y = 144;

        public const int DOOR_EAST_POSITION_X = 598;
        public const int DOOR_EAST_POSITION_Y = 264;

        public const int DOOR_SOUTH_POSITION_X = 374;
        public const int DOOR_SOUTH_POSITION_Y = 408;

        public const int DOOR_WEST_POSITION_X = 174;
        public const int DOOR_WEST_POSITION_Y = 264;

        public const int DUNGEON_CORNER_X = 150;
        public const int DUNGEON_CORNER_Y = 120;

        public const int DUNGEON_NORTH_WALL_X = 150;
        public const int DUNGEON_NORTH_WALL_Y = 120;

        public const int DUNGEON_EAST_WALL_X = 598;
        public const int DUNGEON_EAST_WALL_Y = 120;

        public const int DUNGEON_SOUTH_WALL_X = 150;
        public const int DUNGEON_SOUTH_WALL_Y = 408;

        public const int DUNGEON_WEST_WALL_X = 150;
        public const int DUNGEON_WEST_WALL_Y = 120;

        public const int SAVE_ICON_X = 700;
        public const int SAVE_ICON_Y = 400;

        public const int BACK_BUTTON_X = 650;
        public const int BACK_BUTTON_Y = 50;

        public const int MAP_ORIGIN_X = 230;
        public const int MAP_ORIGIN_Y = 100;
        public const int MAP_TEXT_X = 100;
        public const int MAP_TEXT_Y = 30;
        public const int CENTER_VECTOR_X = 4;
        public const int CENTER_VECTOR_Y = 2;

        public const int MAP_BUFFER_MULT = 7;

        public const int NUM_OF_LEVELS = 18;

        public const string LEVEL_FILE_PREFIX = "Level";

        public const float BACKGROUND_LAYER_DEPTH = 0.0f;
        public const float BACKGROUND_BLOCK_LAYER_DEPTH = 0.1f;
        public const float BLOCK_LAYER_DEPTH = 0.2f;
        public const float DOOR_LAYER_DEPTH = 0.3f;
        public const float ITEM_LAYER_DEPTH = 0.6f;
        public const float PROJECTILE_LAYER_DEPTH = 0.7f;
        public const float ENEMY_LAYER_DEPTH = 0.8f;
        public const float PLAYER_LAYER_DEPTH = 0.9f;
        public const float TEXT_LAYER_DEPTH = 0.99f;

        public const int NUM_AVAILABLE_PROJECTILES = 3;

        public const int SCALING_FACTOR = 2;

        public const int IMPOSSIBLE_VALUE = -SCALED_ROOM_WIDTH - 1;
        public const int CAMERA_SPEED = 4;

        public const int BUFFER_SPACE = BLOCK_SIZE / 4;
    }
}

