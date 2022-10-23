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
//using System.Reflection.Emit;

namespace sprint0
{
    public class LevelLoader
    {
        private Game1 game;
        private GameObjectManager gameObjectManager;

        private int pixelLength = 16;
        private int levelNum = 0;

        // List of all Objects made using factory.
        private static List<Object> allItems = new List<Object>();
        // List of XML things (Not real objects).
        private static List<ItemObject> allItemObjects = new List<ItemObject>();

        public LevelLoader(Game1 game)
        {
            this.game = game;
            this.gameObjectManager = game.manager;
            levelNum = game.level;
        }

        /// <summary>
        /// Load the next room as dictated by the level number. Uses circular
        /// loading so if on the last room, go to the first room.
        /// </summary>
        public void LoadNextLevel()
        {
            // Unload previous level's objects.
            UnloadLevel();

            // Get the next level number.
            if (levelNum >= Constants.NUM_OF_LEVELS)
            {
                levelNum = 0;
            }
            levelNum++;

            // Get the filepath of the room's XML file.
            string levelName = Constants.LEVEL_FILE_PREFIX + levelNum.ToString();
            string sFile = GetLevelFile(levelName);
            Console.WriteLine("Loading " + levelName);

            // Load the room from an XML document format.
            string sFilePath = Path.GetFullPath(sFile);
            XDocument level = XDocument.Load(sFilePath);

            string namespaceString = GetThisNamespace();

            // Get all items from the XML.
            IEnumerable<XElement> items = GetItemsFromDocument(level);

            // Add all items to the GameObjectManager.
            AddObjects(items, namespaceString);

            Console.WriteLine(this.ToString());
        }

        /// <summary>
        /// Add objects to the game object manager.
        /// </summary>
        /// <param name="objects"></param>
        private void AddObjects(IEnumerable<XElement> objects, string namespaceString)
        {
            foreach (XElement item in objects)
            {
                ItemObject itemObj = new ItemObject();
                IEnumerable<XElement> attributes = item.Elements();
                itemObj.parseData(attributes);

                allItemObjects.Add(itemObj);

                int orgX = itemObj.PosX;
                int orgY = itemObj.PosY;

                // Double for creates the dimensions possible.
                for (int i = 0; i < itemObj.NumY; i++)
                {
                    for (int j = 0; j < itemObj.NumX; j++)
                    {
                        //Creates vector for the final position
                        Vector2 position = new Vector2(itemObj.PosX, itemObj.PosY);
                        object[] parameterArray = new object[] { position };

                        Object thing = GetObjectFromItemObject(itemObj, namespaceString, parameterArray);

                        if (itemObj.ObjectType == "Player")
                        {
                            gameObjectManager.AddPlayer(thing);
                        }
                        else
                        {
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

        /// <summary>
        /// Get the elements labeled "Item" from the provided document.
        /// </summary>
        /// <param name="document"></param>
        /// <returns>An enumerable of all items from the document.</returns>
        private IEnumerable<XElement> GetItemsFromDocument(XDocument document)
        {
            // Whole XML element.
            XElement root = document.Root;
            // Inside the asset element.
            XElement asset = root.Element("Asset");

            return asset.Elements("Item");
        }

        /// <summary>
        /// Returns an object instance invoked using the itemObj's type and name.
        /// </summary>
        /// <param name="itemObj"></param>
        /// <returns>An instance of the object.</returns>
        private object GetObjectFromItemObject(ItemObject itemObj, string namespaceString, object[] paramArray) // TODO: namespaceString should not need to be passed in here
        {
            Object thing = new object();
            Object classThing = new object();
            MethodInfo method;

            // Takes in the item type, finds the correct constuctor method then
            // invokes it. That means the objectName must match the correct
            // method in the factories.
            string factoryString = namespaceString + "." + itemObj.ObjectType + "Factory"; // get type name
            Type type = Type.GetType(factoryString); // get type from name
            classThing = type.InvokeMember("Instance", BindingFlags.GetProperty, null, null, null); // get class from type
            method = classThing.GetType().GetMethod(itemObj.ObjectName); // get method from class and method name
            thing = method.Invoke(classThing, paramArray); // call method and get its object

            return thing;
        }

        /// <summary>
        /// Get the file path of the XML level file based on the level name.
        /// </summary>
        /// <param name="levelName"></param>
        /// <returns>The file path.</returns>
        private string GetLevelFile(string levelName)
        {
            string file = "";
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Get the filepath string based on the OS. Windows is the odd one
            // out here.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                file = System.IO.Path.Combine(currentDirectory, @$"..\..\..\Levels\{levelName}.xml");
            }
            else
            {
                file = System.IO.Path.Combine(currentDirectory, @$"../../../Levels/{levelName}.xml");
            }
            return file;
        }

        /// <summary>
        /// Resets level number to the previous'.
        /// </summary>
        public void ResetLevelNum()
        {
            levelNum--;
        }

        /// <summary>
        /// Gets the formatted string of all items currently in the level. 
        /// </summary>
        /// <returns>The formatted item list.</returns>
        public override string ToString()
        {
            string fullString = "All Items\n";
            foreach (ItemObject item in allItemObjects)
            {
                fullString += "\n" + item.ToString();
            }
            return fullString;
        }

        /// <summary>
        /// Unload all objects in the current level.
        /// </summary>
        public void UnloadLevel()
        {
            foreach (object item in allItems)
            {
                gameObjectManager.RemoveObject(item);
            }
            allItemObjects.Clear();
        }

        /// <summary>
        /// Gets the current namespace of the solution.
        /// </summary>
        /// <returns>The namespace.</returns>
        private string GetThisNamespace()
        {
            return GetType().Namespace;
        }
    }
}

