using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class DisplayInventoryCommand : ICommand
    {
        private Game1 game;
        private string request;
        private static Room callerRoom;
        public DisplayInventoryCommand(Game1 game, string request)
        {
            this.game = game;
            this.request = request;
        }
        public void Execute()
        {
            if (request.Equals("Display"))
            {
                HandleDisplay();
            } 
            else
            {
                HandleRemoveDisplay();
            }
            
        }

        private void HandleDisplay()
        {
            if (game.loader.currentRoom.name.Equals("RoomInventory"))
            {
                return;
            }

            callerRoom = game.loader.currentRoom;
            for (int i = 0; i < game.loader.allRooms.Count; i++)
            {
                string nameOfRoom = game.loader.allRooms[i].name;
                if (nameOfRoom.Equals("RoomInventory"))
                {
                    game.loader.ChangeRooms(game.loader.allRooms[i]);
                    break;
                }
            }
        }

        private void HandleRemoveDisplay()
        {
            if (!game.loader.currentRoom.name.Equals("RoomInventory"))
            {
                return;
            }

            game.loader.ChangeRooms(callerRoom);
            callerRoom = null;
        }
    }
}
