using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    internal class PlayerDoorCollisionCommand : ICommand
    {
        Game1 game;
        LevelLoader loader;
        KeyboardController keyboard;
        private Room nextRoom;
        IObject player;
        IObject block;
        string intersectionLoc;
        ICommand command;
        Direction d;

        public PlayerDoorCollisionCommand(IObject player, IObject block, string intersectionLoc, GameObjectManager manager)
        {
            this.game = manager.game;
            this.player = player;
            this.block = block;
            this.intersectionLoc = intersectionLoc;
        }

        public void Execute()
        {
            Console.WriteLine("Player collided with door");
            Player player = (Player)this.player;
            this.loader = this.game.loader;

            //KeyboardController.DisableKeyboard();
            bool success = Enum.TryParse(intersectionLoc.ToUpper(), out Direction d);
            // TODO: data drive
            switch (d)
            {
                case Direction.RIGHT:
                    nextRoom = loader.currentRoom.westRoomPtr;
                    break;
                case Direction.DOWN:
                    nextRoom = loader.currentRoom.northRoomPtr;
                    break;
                case Direction.LEFT:
                    nextRoom = loader.currentRoom.eastRoomPtr;
                    break;
                case Direction.UP:
                    nextRoom = loader.currentRoom.southRoomPtr;
                    break;
            }
            game.loader.ChangeRooms(nextRoom);
            //KeyboardController.EnableKeyboard();
        }
    }
}