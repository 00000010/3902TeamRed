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

            manager.AddObject(TextSpriteFactory.Instance.CustomText(new Vector2(0, 120), "Block"));
            manager.AddObject(TextSpriteFactory.Instance.CustomText(new Vector2(0, 120), "Enemy"));
            manager.AddObject(TextSpriteFactory.Instance.CustomText(new Vector2(0, 120), "Block"));

            string[] blockNames = { "DungeonBlock", "WaterBlock", "ZeldaGreenBlock", "ZeldaBlackBlock", "ZeldaPurpleBlock" };
            string[] enemyNames = { "ZeldaOldMan", "Stalfos", "Keese", "Goriya", "Gel", "Octorok" };
            string[] itemNames = { "ZeldaFairy", "ZeldaHeart", "ZeldaHeartContainer", "ZeldaKey", "ZeldaTriforce", "ZeldaRupy" };

            createListOfType("Block", 0, 150, blockNames);
            createListOfType("Item", 100, 150, itemNames);

            mouse.LoadLevelCreatorCommands(game, loader);
        }

        //Creates the list of all the things that can be made into the level
        public void createListOfType(string objectType, int X, int Y, string[] listOfStrings)
        {
            Object objectCreated = new object();
            Object objectClass = new object();
            MethodInfo method;
            int bufferSpace = Constants.BUFFER_SPACE;
            Vector2 position;


            for (int i = 0; i < listOfStrings.Length; i++)
            {


                position = new Vector2(X, Y + (i * Constants.BLOCK_SIZE) + (i * bufferSpace));

                object[] parameterArray = { position };

                string factoryString = GetThisNamespace() + "." + objectType + "Factory"; // get type name
                Type type = Type.GetType(factoryString); // get type from name
                objectClass = type.InvokeMember("Instance", BindingFlags.GetProperty, null, null, null); // get class from type
                method = objectClass.GetType().GetMethod(listOfStrings[i]); // get method from class and method name
                objectCreated = method.Invoke(objectClass, parameterArray); // call method and get its object
                manager.AddObject(objectCreated);

                Debug.WriteLine("Creating " + objectCreated.ToString() + " " + position.ToString());
                itemList.Add(objectCreated, position);
            }

            Debug.WriteLine(itemList.ToString());
        }

        private string GetThisNamespace()
        {
            return GetType().Namespace;
        }

    }
}