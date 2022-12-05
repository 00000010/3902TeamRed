using System;
//using Microsoft.Xna.Framework;
//using System.Diagnostics;

namespace sprint0
{
    public class LoadRoomCommand : ICommand
    {
        private Game1 game;
        private LevelLoader loader;
        private Room nextRoom;
        private Direction direction;

        public LoadRoomCommand(Game1 game, Direction direction)
        {
            this.game = game;
            this.direction = direction;
        }

        public void Execute()
        {
            loader = game.loader;
            nextRoom = getRoom();
            loader.ChangeRooms(nextRoom, direction);
        }

        public Room getRoom()
        {
            loader = game.loader;

            //ToDo - data drive this switch
            switch (direction)
            {
                case Direction.LEFT:
                    nextRoom = loader.currentRoom.westRoomPtr;
                    break;
                case Direction.UP:
                    nextRoom = loader.currentRoom.northRoomPtr;
                    break;
                case Direction.RIGHT:
                    nextRoom = loader.currentRoom.eastRoomPtr;
                    break;
                case Direction.DOWN:
                    nextRoom = loader.currentRoom.southRoomPtr;
                    break;
            }
           
            return nextRoom;
        }
    }
}
