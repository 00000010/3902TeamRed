using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    internal class PlayerDoorCollisionCommand : ICommand
    {
        Game1 game;
        GameObjectManager manager;
        LevelLoader loader;
        KeyboardController keyboard;
        private Room nextRoom;
        IPlayer player;
        IObject block;
        string intersectionLoc;
        ICommand command;
        Direction d;

        public PlayerDoorCollisionCommand(IObject player, IObject block, string intersectionLoc, GameObjectManager manager)
        {
            this.game = manager.game;
            this.manager = manager;
            this.block = block;
            this.intersectionLoc = intersectionLoc;
        }

        public void Execute()
        {
            //Player player = (Player)this.player;
            player = manager.player;
            this.loader = this.game.loader;
            
            Enum.TryParse(intersectionLoc.ToUpper(), out Direction d);

            switch (d)
            {
                case Direction.RIGHT:
                    player.Position = new Vector2(Constants.FROM_RIGHT_LINK_POSITION_X, Constants.FROM_RIGHT_LINK_POSITION_Y);
                    nextRoom = loader.currentRoom.westRoomPtr;
                    d = Direction.LEFT;
                    break;
                case Direction.DOWN:
                    player.Position = new Vector2(Constants.FROM_DOWN_LINK_POSITION_X, Constants.FROM_DOWN_LINK_POSITION_Y);
                    nextRoom = loader.currentRoom.northRoomPtr;
                    d = Direction.UP;
                    break;
                case Direction.LEFT:
                    player.Position = new Vector2(Constants.FROM_LEFT_LINK_POSITION_X, Constants.FROM_LEFT_LINK_POSITION_Y);
                    nextRoom = loader.currentRoom.eastRoomPtr;
                    d = Direction.RIGHT;
                    break;
                case Direction.UP:
                    player.Position = new Vector2(Constants.FROM_UP_LINK_POSITION_X, Constants.FROM_UP_LINK_POSITION_Y);
                    nextRoom = loader.currentRoom.southRoomPtr;
                    d = Direction.DOWN;
                    break;
            }
            game.loader.ChangeRooms(nextRoom, d);
        }
    }
}