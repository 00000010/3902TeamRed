using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class PlaceBlockCommand : ICommand
    {

        Vector2 location;
        Game1 game;

        public PlaceBlockCommand(Game1 game, Vector2 location)
        {
            this.location = location;
            this.game = game;
        }

        public void Execute()
        {
            Room currentRoom = game.loader.currentRoom;
            GameObjectManager manager = game.manager;

            Debug.WriteLine("TEST " + location);
            Block block = BlockFactory.Instance.ZeldaGreenBlock(location);
            if(!currentRoom.existsInLocation(location))
            {
                Debug.WriteLine("PlaceBlock");
                manager.AddObject(block);
                currentRoom.Add(block);
            }
            
        }

    }
}