using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class RemoveBlockCommand : ICommand
    {

        Vector2 location;
        Game1 game;

        public RemoveBlockCommand(Game1 game, Vector2 location)
        {
            this.location = location;
            this.game = game;
        }

        public void Execute()
        {
            Room currentRoom = game.loader.currentRoom;
            GameObjectManager manager = game.manager;

            Debug.WriteLine("TEST " + location);
            object obj = currentRoom.getFromLocation(location);
            if (obj != null)
            {
                Debug.WriteLine("RemovingBlock");
                manager.RemoveObject(obj);
                currentRoom.RemoveObject(obj);
            }

        }

    }
}