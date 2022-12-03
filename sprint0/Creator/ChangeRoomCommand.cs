using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//I Think I accidentally wrote the load room command so probably just use that instead
namespace sprint0
{
    public class ChangeRoomCommand : ICommand
    {
        Game1 game;
        Direction direction;
        LevelLoader loader;
        Room currentRoom;
        public ChangeRoomCommand(Game1 game, Direction direction)
        {
            this.game = game;
            this.direction = direction;
        }

        public void Execute()
        {
            loader = game.loader;
            currentRoom = game.loader.currentRoom;

            switch(direction)
            {
                case Direction.UP:
                    loader.ChangeRooms(currentRoom.northRoomPtr);
                    break;
                case Direction.RIGHT:
                    loader.ChangeRooms(currentRoom.eastRoomPtr);
                    break;
                case Direction.DOWN:
                    loader.ChangeRooms(currentRoom.southRoomPtr);
                    break;
                case Direction.LEFT:
                    loader.ChangeRooms(currentRoom.westRoomPtr);
                    break;
                default: Debug.WriteLine("Cannot change to that room");
                    break;
            }
        }
    }
}
