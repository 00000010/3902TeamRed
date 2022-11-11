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
//using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class LevelLoader
    {
        public Game1 game;
        public GameObjectManager gameObjectManager;
        public int pixelLength = Constants.BLOCK_SIZE;

        public ItemObject background;


        public List<Room> allRooms = new List<Room>();
        public Room currentRoom { get; set; }

        public LevelLoader(Game1 game)
        {
            this.game = game;
            this.gameObjectManager = game.manager;
            currentRoom = new Room();
        }

        public string[] getFilePaths(string levelName)
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile;

            Console.WriteLine("Loading " + levelName);

            //Gets file location based on operating system
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                sFile = System.IO.Path.Combine(sCurrentDirectory, @$"..\..\..\Levels\{levelName}");
            }
            else
            {
                sFile = System.IO.Path.Combine(sCurrentDirectory, @$"../../../Levels/{levelName}");
            }
            string sFilePath = Path.GetFullPath(sFile);
            string[] files = Directory.GetFiles(sFilePath);

            return files;
        }

        /*
         * Loads in all the room files from a folder and creates a list of 
         * all the rooms the exist and how they relate to each other
         * 
         */
        public void LoadLevel(string levelName)
        {
            // Unload anything that may be previously loaded.
            //UnloadRoom();

            string[] files = getFilePaths(levelName);

            foreach (string filePath in files)
            {
                Room room = new Room();
                allRooms.Add(room);

                XDocument level = XDocument.Load(filePath);
                //Whole XML element
                XElement tree = level.Root;

                XElement meta = tree.Element("Meta");
                XElement roomName = meta.Element("Name");
                room.name = roomName.Value;
                XElement pointers = tree.Element("Pointers");
                IEnumerable<XElement> elms = pointers.Elements();
                room.ParsePointers(elms);
                //Inside the asset element
                XElement asset = tree.Element("Asset");

                IEnumerable<XElement> items = asset.Elements("Item");

                foreach (XElement item in items)
                {
                    ItemObject itemObj = new ItemObject();
                    IEnumerable<XElement> attributes = item.Elements();
                    itemObj.parseData(attributes);

                    room.Add(itemObj);

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

                            room.Add(thing);
                            itemObj.PosX = itemObj.PosX + pixelLength;
                        }
                        itemObj.PosX = orgX;
                        itemObj.PosY = itemObj.PosY + pixelLength;
                    }
                }
            }

            //Gets starting room
            foreach (Room room in allRooms)
            {
                if (room.name == "Room1")
                {
                    currentRoom = room;
                }
            }
            pointPointers();
            LoadRoom();
            gameObjectManager.AddPlayer(game.player);
        }

         
        //Points the rooms to each other so rooms know whats adjecent
        //Todo - Make this not a double for loop
        public void pointPointers()
        {
            foreach (Room roomX in allRooms)
            {
                foreach (Room roomY in allRooms)
                {
                    if (roomX.WestRoom == (roomY.name))
                    {
                        roomX.westRoomPtr = roomY;
                    }

                    else if (roomX.NorthRoom == (roomY.name))
                    {
                        roomX.northRoomPtr = roomY;
                    }

                    else if (roomX.EastRoom == (roomY.name))
                    {
                        roomX.eastRoomPtr = roomY;
                    }

                    else if (roomX.SouthRoom == (roomY.name))
                    {
                        roomX.southRoomPtr = roomY;
                    }
                }
            }
        }

        //Changes rooms from the currrent to the specified
        public void ChangeRooms(Room room)
        {
            if (room != null)
            {
                UnloadRoom();
                currentRoom = room;
                LoadRoom();
            }

            if (currentRoom.name.Equals("Room10"))
            {
                HandleSpecialDisplays.Instance.Room10 = true;
            }
            else
            {
                HandleSpecialDisplays.Instance.Room10 = false;
            }
        }

        //Prints the contents of the level
        public override string ToString()
        {
            string fullString = "All Items\n";
            foreach (ItemObject item in currentRoom.roomItemObjects)
            {
                fullString += "\n" + item.ToString();
            }
            fullString += $"\n{currentRoom.ToString()}\n";
            return fullString;
        }

        //Unloads the current room
        public void UnloadRoom()
        {
            foreach (object item in currentRoom.roomObjects)
            {
                gameObjectManager.RemoveObject(item);
            }
        }

        //Loads the current room 
        public void LoadRoom()
        {
            foreach (object obj in currentRoom.roomObjects)
            {
                gameObjectManager.AddObject(obj);
            }
        }

        public void RemoveFromCurrRoom(object obj)
        {
            currentRoom.RemoveObject(obj);
            //Drop a key in Room3 once all enemies are dead
            if (currentRoom.name.Equals("Room3") && currentRoom.roomEnemies.Count == 0)
            {
                IEnemy enemy = (Enemy)obj;
                gameObjectManager.AddObject(ItemFactory.Instance.ZeldaBoomerang(enemy.Position));
            }
        }

        private string GetThisNamespace()
        {
            return GetType().Namespace;
        }
    }
}
