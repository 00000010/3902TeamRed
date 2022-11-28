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
            object objectToPlace = game.creator.currentObject;
    

            if (objectToPlace is IBlock)
            {
                IBlock tempBlock = (IBlock)objectToPlace;
                tempBlock.Position = location;
                manager.AddObject(tempBlock);
                currentRoom.Add(objectToPlace);
            }
            else if (objectToPlace is IItem)
            {
                IItem tempItem = (IItem)objectToPlace;
                Item newItem = (Item)tempItem;
                Item newerItem = newItem.Clone();

                manager.AddObject(newerItem);
                currentRoom.Add(newerItem);
            }

        }

    }
}