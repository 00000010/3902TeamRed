using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LevelCreator
    {
        LevelLoader loader;
        MouseController mouse;
        Game1 game;
        GameObjectManager manager;
        public Room gridRoom;

        public int numLevels = 1;

        //Dictionary of all the kind of objects that can be used to make a level with  their location
        public Dictionary<object, Vector2> itemList = new Dictionary<object, Vector2>();
        public List<object> textObjects = new List<object>();
        public object currentObject;

        public LevelCreator(Game1 game)
        {
            this.game = game;
        }

        public void loadLevelCreator()
        {
            loader = game.loader;
            mouse = game.mouse;
            manager = game.manager;

            loader.clearLoader();
            loader.LoadLevel("LevelCreator");
            gridRoom = loader.currentRoom;

            Room newRoom = new Room();
            
            //Adds neccessary elements to room
            newRoom.Add(SpriteFactory.Instance.Dungeon(new Vector2(Constants.DUNGEON_CORNER_X, Constants.DUNGEON_CORNER_Y)));
            newRoom.Add(BlockFactory.Instance.DungeonNorthWall(new Vector2(Constants.DUNGEON_NORTH_WALL_X, Constants.DUNGEON_NORTH_WALL_Y)));
            newRoom.Add(BlockFactory.Instance.DungeonEastWall(new Vector2(Constants.DUNGEON_EAST_WALL_X, Constants.DUNGEON_EAST_WALL_Y)));
            newRoom.Add(BlockFactory.Instance.DungeonSouthWall(new Vector2(Constants.DUNGEON_SOUTH_WALL_X, Constants.DUNGEON_SOUTH_WALL_Y)));
            newRoom.Add(BlockFactory.Instance.DungeonWestWall(new Vector2(Constants.DUNGEON_WEST_WALL_X, Constants.DUNGEON_WEST_WALL_Y)));

            newRoom.start = true;
            newRoom.name = "Room" + numLevels++;
            newRoom.coordinate = new Vector2(0, 0);
            loader.currentRoom = newRoom;

            //Text for each kind of object
            textObjects.Add(TextSpriteFactory.Instance.CustomText(new Vector2(0, 120), "Block"));
            textObjects.Add(TextSpriteFactory.Instance.CustomText(new Vector2(50, 120), "Enemy"));
            textObjects.Add(TextSpriteFactory.Instance.CustomText(new Vector2(100, 120), "Item"));
            textObjects.Add(TextSpriteFactory.Instance.CustomText(new Vector2(700, 120), "Door"));

            textObjects.Add(TextSpriteFactory.Instance.customBigText(new Vector2(50, 50), "Back"));
            textObjects.Add(TextSpriteFactory.Instance.customGoldText(new Vector2(300, 50), "Level Creator"));

            textObjects.Add(TextSpriteFactory.Instance.CustomText(new Vector2(665, 160), "North"));
            textObjects.Add(TextSpriteFactory.Instance.CustomText(new Vector2(665, 210), "South"));
            textObjects.Add(TextSpriteFactory.Instance.CustomText(new Vector2(665, 270), "East"));
            textObjects.Add(TextSpriteFactory.Instance.CustomText(new Vector2(665, 340), "West"));
            textObjects.Add(TextSpriteFactory.Instance.CustomText(new Vector2(665, 415), "Save"));

            foreach(object obj in textObjects)
            {
                manager.AddObject(obj);
            }

            //Names of the objects
            string[] blockNames = { "DungeonBlock", "WaterBlock", "ZeldaGreenBlock", "ZeldaBlackBlock", "ZeldaPurpleBlock" };
            string[] enemyNames = { "ZeldaOldMan", "Stalfos", "Keese", "Gel", "Octorok" };
            string[] itemNames = { "ZeldaFairy", "ZeldaHeart", "ZeldaHeartContainer", "ZeldaKey", "ZeldaTriforce", "ZeldaRupy" };
            string[] doorNames = { "DungeonDoorNorth", "DungeonDoorSouth", "DungeonDoorEast", "DungeonDoorWest" };

            createListOfType("Block", 0, 150, blockNames);
            createListOfType("Enemy", 50, 150, enemyNames);
            createListOfType("Item", 100, 150, itemNames);
            createListOfType("Door", 700, 150, doorNames);

            mouse.LoadLevelCreatorCommands(game, loader);
            loader.allRooms.Add(newRoom);
        }

        //Creates the list of all the things that can be made into the level
        public void createListOfType(string objectType, int X, int Y, string[] listOfStrings)
        {
            Object objectCreated = new object();
            Object objectClass = new object();
            MethodInfo method;
            int bufferSpace = Constants.BUFFER_SPACE;

            if(objectType.Equals("Door"))
            {
                bufferSpace = Constants.BUFFER_SPACE * 2;
            }

            Vector2 position;


            for (int i = 0; i < listOfStrings.Length; i++)
            {
                //ToDo, make this bit not so hardcoded. Currently makes the spacing of the doors look nice
                if(objectType.Equals("Door") && i == 3)
                {
                    bufferSpace = Constants.BUFFER_SPACE * 4 - 8;
                }

                position = new Vector2(X, Y + (i * Constants.BLOCK_SIZE) + (i * bufferSpace));

                object[] parameterArray = { position };

                //Creates a new object with the object type and name
                string factoryString = GetThisNamespace() + "." + objectType + "Factory"; // get type name
                Type type = Type.GetType(factoryString); // get type from name
                objectClass = type.InvokeMember("Instance", BindingFlags.GetProperty, null, null, null); // get class from type
                method = objectClass.GetType().GetMethod(listOfStrings[i]); // get method from class and method name
                objectCreated = method.Invoke(objectClass, parameterArray); // call method and get its object

                //Makes enemys have 0 velocity so they don't move when the user is creating
                if(objectType.Equals("Enemy"))
                {
                    Enemy newEnemy = (Enemy)objectCreated;
                    newEnemy.willUpdateVelocity = false;
                    manager.AddObject(newEnemy);
                    itemList.Add(newEnemy, position);
                }
                //Non enemy objects are passed in normally
                else
                {
                    manager.AddObject(objectCreated);
                    itemList.Add(objectCreated, position);
                }
                
                Console.WriteLine("Creating " + objectCreated.ToString() + " " + position.ToString());
            }

            Debug.WriteLine(itemList.ToString());
        }

        private string GetThisNamespace()
        {
            return GetType().Namespace;
        }

        public void unloadCreator()
        {
            foreach(KeyValuePair<object, Vector2> entry in itemList)
            {
                manager.RemoveObject(entry.Key);
            }
            foreach(object obj in textObjects)
            {
                manager.RemoveObject(obj);
            }
        }

    }
}