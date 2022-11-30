using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class ChangeCurrentObjectCommand : ICommand
    {
        Game1 game;
        object obj;
        public ChangeCurrentObjectCommand(Game1 game, object obj)
        {
            this.game = game;
            this.obj = obj;
        }

        public void Execute()
        {
            Debug.WriteLine("Testing for a block change");

            if (obj is Door)
            {
                IDoor tempDoor = (IDoor)obj;
                Debug.WriteLine(tempDoor.GetType() + " HI");

                string doorType = tempDoor.GetType().ToString();
                string kindOnly = doorType.Substring(doorType.LastIndexOf('.') + 1);

                object newBlock = createNewObj("Door", kindOnly, getDoorPosition(kindOnly));

                //Can only make a door if one already doesn't exist
                if (canPlaceDoor(kindOnly))
                {
                    Debug.WriteLine("Placing Door");
                    game.manager.AddObject(newBlock);
                    game.loader.currentRoom.Add(newBlock);
                    createNewRoom(kindOnly);
                }
            }
            else //Changes the block tpye if it isn't a door
            {
                game.creator.currentObject = obj;
            }
        }

        //Creates a new object from parameters
        public object createNewObj(string stringType, string objName, Vector2 position)
        {
            Object objectCreated = new object();
            Object objectClass = new object();
            MethodInfo method;

            object[] parameterArray = { position };

            string factoryString = GetThisNamespace() + "." + stringType + "Factory"; // get type name
            Type type = Type.GetType(factoryString); // get type from name
            objectClass = type.InvokeMember("Instance", BindingFlags.GetProperty, null, null, null); // get class from type
            method = objectClass.GetType().GetMethod(objName); // get method from class and method name
            objectCreated = method.Invoke(objectClass, parameterArray); // call method and get its object

            return objectCreated;
        }

        private string GetThisNamespace()
        {
            return GetType().Namespace;
        }

        //Gets the position of the door according to the name
        public Vector2 getDoorPosition(string doorName)
        {
            Vector2 position;

            if(doorName.Equals("DungeonDoorNorth"))
            {
                position = new Vector2(Constants.DOOR_NORTH_POSITION_X, Constants.DOOR_NORTH_POSITION_Y);
            }
            else if(doorName.Equals("DungeonDoorEast"))
            {
                position = new Vector2(Constants.DOOR_EAST_POSITION_X, Constants.DOOR_EAST_POSITION_Y);
            }
            else if(doorName.Equals("DungeonDoorSouth"))
            {
                position = new Vector2(Constants.DOOR_SOUTH_POSITION_X, Constants.DOOR_SOUTH_POSITION_Y);
            }
            else //West Door
            {
                position = new Vector2(Constants.DOOR_WEST_POSITION_X, Constants.DOOR_WEST_POSITION_Y);
            }

            return position;
        }

        //Checks if the door already exists
        public bool canPlaceDoor(string doorName)
        {
            bool canPlace = true;

            if (doorName.Equals("DungeonDoorNorth"))
            {
                canPlace = game.loader.currentRoom.northRoomPtr == null;
            }
            else if (doorName.Equals("DungeonDoorEast"))
            {
                canPlace = game.loader.currentRoom.eastRoomPtr == null;
            }
            else if (doorName.Equals("DungeonDoorSouth"))
            {
                canPlace = game.loader.currentRoom.southRoomPtr == null;
            }
            else //West Door
            {
                canPlace = game.loader.currentRoom.westRoomPtr == null;
            }

            return canPlace;
        }

        //Creates a new room based on the door position
        public void createNewRoom(string doorName)
        {
            Room currentRoom = game.loader.currentRoom;

            Room newRoom = new Room();
            newRoom.name = "Room" + game.creator.numLevels;
            game.creator.numLevels++;
            newRoom.start = false;

            //Adds all base layer objects
            newRoom.Add(SpriteFactory.Instance.Dungeon(new Vector2(Constants.DUNGEON_CORNER_X, Constants.DUNGEON_CORNER_Y)));
            newRoom.Add(BlockFactory.Instance.DungeonNorthWall(new Vector2(Constants.DUNGEON_NORTH_WALL_X, Constants.DUNGEON_NORTH_WALL_Y)));
            newRoom.Add(BlockFactory.Instance.DungeonEastWall(new Vector2(Constants.DUNGEON_EAST_WALL_X, Constants.DUNGEON_EAST_WALL_Y)));
            newRoom.Add(BlockFactory.Instance.DungeonSouthWall(new Vector2(Constants.DUNGEON_SOUTH_WALL_X, Constants.DUNGEON_SOUTH_WALL_Y)));
            newRoom.Add(BlockFactory.Instance.DungeonWestWall(new Vector2(Constants.DUNGEON_WEST_WALL_X, Constants.DUNGEON_WEST_WALL_Y)));

            game.loader.allRooms.Add(newRoom);



            if (doorName.Equals("DungeonDoorNorth"))
            {
                currentRoom.northRoomPtr = newRoom;
                newRoom.southRoomPtr = currentRoom;
                newRoom.Add(DoorFactory.Instance.DungeonDoorSouth(new Vector2(Constants.DOOR_SOUTH_POSITION_X, Constants.DOOR_SOUTH_POSITION_Y)));
            }
            else if (doorName.Equals("DungeonDoorEast"))
            {
                currentRoom.eastRoomPtr = newRoom;
                newRoom.westRoomPtr = currentRoom;
                newRoom.Add(DoorFactory.Instance.DungeonDoorWest(new Vector2(Constants.DOOR_WEST_POSITION_X, Constants.DOOR_WEST_POSITION_Y)));
            }
            else if (doorName.Equals("DungeonDoorSouth"))
            {
                currentRoom.southRoomPtr = newRoom;
                newRoom.northRoomPtr = currentRoom;
                newRoom.Add(DoorFactory.Instance.DungeonDoorNorth(new Vector2(Constants.DOOR_NORTH_POSITION_X, Constants.DOOR_NORTH_POSITION_Y)));
            }
            else //West Door
            {
                currentRoom.westRoomPtr = newRoom;
                newRoom.eastRoomPtr = currentRoom;
                newRoom.Add(DoorFactory.Instance.DungeonDoorEast(new Vector2(Constants.DOOR_EAST_POSITION_X, Constants.DOOR_EAST_POSITION_Y)));
            }
        }
    }
}
