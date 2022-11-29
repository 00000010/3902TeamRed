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

        int numLevels = 1;

        //Dictionary of all the kind of objects that can be used to make a level with  their location
        public Dictionary<object, Vector2> itemList = new Dictionary<object, Vector2>();
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

            loader.LoadLevel("LevelCreator");

            loader.currentRoom.name = "Room" + numLevels++;

            //Text for each kind of object
            manager.AddObject(TextSpriteFactory.Instance.CustomText(new Vector2(0, 120), "Block"));
            manager.AddObject(TextSpriteFactory.Instance.CustomText(new Vector2(50, 120), "Enemy"));
            manager.AddObject(TextSpriteFactory.Instance.CustomText(new Vector2(100, 120), "Item"));
            manager.AddObject(TextSpriteFactory.Instance.CustomText(new Vector2(700, 120), "Door"));

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
                

                Debug.WriteLine("Creating " + objectCreated.ToString() + " " + position.ToString());

                

                
            }

            Debug.WriteLine(itemList.ToString());
        }

        private string GetThisNamespace()
        {
            return GetType().Namespace;
        }

    }
}