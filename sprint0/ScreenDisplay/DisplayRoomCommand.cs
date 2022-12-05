using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class DisplayRoomCommand : ICommand
    {
        private Game1 game;
        private string request;
        private string roomName;
        private static Room callerRoom;

        public DisplayRoomCommand(Game1 game, string request, string roomName)

        {
            this.game = game;
            this.request = request;
            this.roomName = roomName;
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
            if (game.loader.currentRoom.name.Equals(roomName))
            {
                return;
            }

            callerRoom = game.loader.currentRoom;
            for (int i = 0; i < game.loader.allRooms.Count; i++)
            {
                string nameOfRoom = game.loader.allRooms[i].name;
                if (nameOfRoom.Equals(roomName))
                {
                    game.loader.ChangeRooms(game.loader.allRooms[i], Direction.UP, false);
                    break;
                }
            }

            if (roomName.Equals("RoomControls"))
            {
                game.keyboard.DisableKeyboard();
                game.controlsKeyboard.EnableControlsKeyboard();
            }

            game.map.UnloadMap();
            game.player.OldPosition = game.player.Position;
            game.player.Position = new Vector2(-180, -120);
            game.manager.player.Position = new Vector2(-180, -120);
        }

        private void HandleRemoveDisplay()
        {
            if (!game.loader.currentRoom.name.Equals(roomName))
            {
                return;
            }

            game.loader.ChangeRooms(callerRoom, Direction.DOWN, false);
            callerRoom = null;

            if (roomName.Equals("RoomControls"))
            {
                game.keyboard.EnableKeyboard();
                game.controlsKeyboard.DisableControlsKeyboard();
            }

            game.map.LoadMap(game.map.mapTitle);
            game.player.Position = game.player.OldPosition;
            game.manager.player.Position = game.player.OldPosition;
        }
    }
}
