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
            mouse.LoadLevelCreatorCommands(game, loader);

            manager.AddObject(TextSpriteFactory.Instance.CustomText(new Vector2(0, 120), "Block"));
            manager.AddObject(TextSpriteFactory.Instance.CustomText(new Vector2(0, 120), "Enemy"));
            manager.AddObject(TextSpriteFactory.Instance.CustomText(new Vector2(0, 120), "Block"));

            string[] blockNames = { "DungeonBlock", "DungeonSand", "DungeonStairs", "WaterBlock", "ZeldaGreen", "ZeldaBlack", "ZeldaPurple" };
            string[] enemyNames = { "ZeldaOldMan", "Stalfos", "Keese", "GoriyaDown", "Gel", "Octorok" };
            string[] itemNames = { "ZeldaFairy", "ZeldaHeart", "ZeldaHeartContainer", "ZeldaKey", "ZeldaTriforce" };

            createListOfType("Sprite", 0, 150, blockNames);
            createListOfType("Sprite", 50, 150, enemyNames);
            createListOfType("Sprite", 100, 150, itemNames);
        }

        //Creates the list of all the things that can be made into the level
        public void createListOfType(string objectType, int X, int Y, string[] listOfStrings)
        {
            Object objectCreated = new object();
            Object objectClass = new object();
            MethodInfo method;
            int bufferSpace = Constants.BLOCK_SIZE / 4;


            for (int i = 0; i < listOfStrings.Length; i++)
            {
                    object[] parameterArray = { new Vector2(X, Y + (i * Constants.BLOCK_SIZE) + (i * bufferSpace)) };

                    string factoryString = GetThisNamespace() + "." + objectType + "Factory"; // get type name
                    Type type = Type.GetType(factoryString); // get type from name
                    objectClass = type.InvokeMember("Instance", BindingFlags.GetProperty, null, null, null); // get class from type
                    method = objectClass.GetType().GetMethod(listOfStrings[i]); // get method from class and method name
                    objectCreated = method.Invoke(objectClass, parameterArray); // call method and get its object
                    manager.AddObject(objectCreated);
            }
        }

        private string GetThisNamespace()
        {
            return GetType().Namespace;
        }

    }
}