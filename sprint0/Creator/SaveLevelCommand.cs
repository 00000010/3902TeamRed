using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Linq;

namespace sprint0
{
    public class SaveLevelCommand : ICommand
    {
        GameObjectManager manager;
        Game1 game;
        LevelLoader loader;


        public SaveLevelCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            manager = game.manager;
            loader = game.loader;

            Debug.WriteLine("Doing Something");

            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sDirectory;
            string sFile;

            string folderName = "CustomLevel";

            //Gets file location based on operating system
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                sDirectory = System.IO.Path.Combine(sCurrentDirectory, @$"../../../Levels/{folderName}");
                sFile = System.IO.Path.Combine(sCurrentDirectory, @$"../../../Levels/{folderName}/");
            }
            else
            {
                sDirectory = System.IO.Path.Combine(sCurrentDirectory, @$"..\..\..\Levels\{folderName}");
                sFile = System.IO.Path.Combine(sCurrentDirectory, @$"..\..\..\Levels\{folderName}\");
            }

            Debug.WriteLine(sDirectory);
            Debug.WriteLine("\nExists? " + System.IO.Directory.Exists(sDirectory));
            System.IO.Directory.CreateDirectory(sDirectory);

            //Deletes existing files so saves overwrite
            string[] files = Directory.GetFiles(sDirectory);
            foreach (string file in files)
            {
                File.Delete(file);
                Console.WriteLine($"{file} is deleted.");
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;


            foreach (Room room in loader.allRooms)
            {
                if (!room.name.Equals("LevelCreatorGrid"))
                {
                    string roomFileName = sFile + room.name + ".xml";
                    using (XmlWriter xw = XmlWriter.Create(roomFileName, settings))
                    {
                        XDocument roomDoc = new XDocument(
                            new XElement("XnaContent",
                            createPointerXml(room),
                            createMetaXml(room),
                            createAssetXml(room)));

                        roomDoc.Save(xw);
                    }
                }

            }

        }

        //Creates the pointers for each room
        public XElement createPointerXml(Room room)
        {
            XElement pointers = new XElement("Pointers");
            if (room.northRoomPtr != null)
            {
                pointers.Add(new XElement("NorthRoom", room.northRoomPtr.name));
            }
            if (room.southRoomPtr != null)
            {
                pointers.Add(new XElement("SouthRoom", room.southRoomPtr.name));
            }
            if (room.eastRoomPtr != null)
            {
                pointers.Add(new XElement("EastRoom", room.eastRoomPtr.name));
            }
            if (room.westRoomPtr != null)
            {
                pointers.Add(new XElement("WestRoom", room.westRoomPtr.name));
            }
            return pointers;
        }

        //Creates the meta element of each room
        public XElement createMetaXml(Room room)
        {
            XElement meta = new XElement("Meta", new XElement("Name", room.name)
                ,new XElement("Start", room.start.ToString()));

            return meta;
        }

        //Creates the asset element of each room
        public XElement createAssetXml(Room room)
        {
            XElement asset = new XElement("Asset");
            room.deleteCreatorSprite();
            foreach(object obj in room.roomObjects)
            {
                asset.Add(createItemXml(obj));
            }
            return asset;
        }

        //Creates an item element
        public XElement createItemXml(object obj)
        {
            XElement item = new XElement("Item");

            string objectType;
            string objectName;
            string location;

            //Info for Blocks
            if(obj is Block)
            {
                Block tempBlock = (Block)obj;
                objectType = "Block";

                string blockType = tempBlock.GetType().ToString();
                objectName = blockType.Substring(blockType.LastIndexOf('.') + 1);

                location = tempBlock.Position.X + " " + tempBlock.Position.Y;
            }
            //Gets info for Doors
            else if (obj is Door)
            {
                Door tempDoor = (Door)obj;
                objectType = "Door";

                string blockType = tempDoor.GetType().ToString();
                objectName = blockType.Substring(blockType.LastIndexOf('.') + 1);

                location = tempDoor.Position.X + " " + tempDoor.Position.Y;
            }
            //Info for Items
            else if (obj is Item)
            {
                Item tempItem = (Item)obj;
                objectType = "Item";

                string blockType = tempItem.GetType().ToString();
                objectName = blockType.Substring(blockType.LastIndexOf('.') + 1);

                location = tempItem.Position.X + " " + tempItem.Position.Y;
            }
            //Info for enemys
            else if (obj is Enemy)
            {
                Enemy tempEnemy = (Enemy)obj;
                objectType = "Enemy";

                string blockType = tempEnemy.GetType().ToString();
                objectName = blockType.Substring(blockType.LastIndexOf('.') + 1);

                location = tempEnemy.Position.X + " " + tempEnemy.Position.Y;
            }
            //Info for sprites
            else
            {
                Sprite tempSprite = (Sprite)obj;
                objectType = "Sprite";

                string spriteType = tempSprite.GetType().ToString();
                Console.WriteLine(spriteType);
                objectName = tempSprite.objectKind;

                location = tempSprite.Position.X + " " + tempSprite.Position.Y;
            }

            //Finishes creating the XML object
            item.Add(new XElement("ObjectType", objectType));
            item.Add(new XElement("ObjectName", objectName));
            item.Add(new XElement("Location", location));

            return item;
        }
    }
}
