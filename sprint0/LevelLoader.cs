using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Reflection;

namespace sprint0
{
    public class LevelLoader
    {
        public Game1 game;
        public GameObjectManager gameObjectManager;
        public int pixelLength = 16;

        public ItemObject background;

        private int levelNum = 0;

        //List of all Objects made using factory
        public List<Object> allItems = new List<Object>();
        //List of XML things (Not real objects)
        public List<ItemObject> allItemObjects = new List<ItemObject>();

        public LevelLoader(Game1 game)
        {
            this.game = game;
            this.gameObjectManager = game.manager;
            levelNum = game.level;
        }

        /*
         * Loads the next room level as dictated by the level reported by Game.
         * 
         * If on the last level, this method goes to the first level.
         */
        public void LoadNextLevel()
        {
            if (levelNum >= Constants.NUM_OF_LEVELS)
            {
                levelNum = 0;
            }
            levelNum++;

            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile;
            string levelName = "Level" + levelNum.ToString();

            Console.WriteLine("Loading " + levelName);

            //Gets file location based on operating system
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                sFile = System.IO.Path.Combine(sCurrentDirectory, @$"..\..\..\Content\Levels\{levelName}.xml");
            }
            else
            {
                sFile = System.IO.Path.Combine(sCurrentDirectory, @$"../../../Content/Levels/{levelName}.xml");
            }
            string sFilePath = Path.GetFullPath(sFile);
            XDocument level = XDocument.Load(sFilePath);
            //Whole XML element
            XElement tree = level.Root;
            //Inside the asset element
            XElement asset = tree.Element("Asset");

            IEnumerable<XElement> items = asset.Elements("Item");

            foreach (XElement item in items)
            {
                ItemObject itemObj = new ItemObject();
                IEnumerable<XElement> attributes = item.Elements();
                itemObj.parseData(attributes);

                allItemObjects.Add(itemObj);

                int orgX = itemObj.PosX;
                int orgY = itemObj.PosY;

                //Double for creates the dimensions possible.
                for (int i = 0; i < itemObj.NumY; i++)
                {
                    for (int j = 0; j < itemObj.NumX; j++)
                    {
                        //Creates vector for the final position
                        Vector2 position = new Vector2(itemObj.PosX, itemObj.PosY);
                        object[] parameterArray = new object[] { position };

                        Object thing = new object();
                        Object classThing = new object();
                        MethodInfo method;

                        /*
                         * Takes in the item type, finds the correct
                         * constuctor method, than invokes it. That means the objectName
                         * must match the correct method in the factories
                         */
                        string factoryString = GetThisNamespace() + "." + itemObj.ObjectType + "Factory"; // get type name
                        Type type = Type.GetType(factoryString); // get type from name
                        classThing = type.InvokeMember("Instance", BindingFlags.GetProperty, null, null, null); // get class from type
                        method = classThing.GetType().GetMethod(itemObj.ObjectName); // get method from class and method name
                        thing = method.Invoke(classThing, parameterArray); // call method and get its object

                        if (itemObj.ObjectType == "Player")
                        {
                            gameObjectManager.AddPlayer(thing);
                        } else 
                        {
                            if (itemObj.ObjectType == "Sprite")
                            {
                                
                            }
                            gameObjectManager.AddObject(thing);
                        }
                        allItems.Add(thing);
                        itemObj.PosX = itemObj.PosX + pixelLength;
                    }
                    itemObj.PosX = orgX;
                    itemObj.PosY = itemObj.PosY + pixelLength;
                }
            }
        }

        //Prints the contents of the level
        public override string ToString()
        {
            string fullString = "All Items\n";
            foreach (ItemObject item in allItemObjects)
            {
                fullString += "\n" + item.ToString();
            }
            return fullString;
        }

        //Unloads all objects from a level
        public void UnloadLevel()
        {
            foreach (object item in allItems)
            {
                gameObjectManager.RemoveObject(item);
            }
            allItemObjects.Clear();
        }

        private string GetThisNamespace()
        {
            return GetType().Namespace;
        }
    }
}

