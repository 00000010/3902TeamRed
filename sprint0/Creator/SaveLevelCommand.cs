using System;
using System.Diagnostics;
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

            //Gets file location based on operating system
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                sDirectory = System.IO.Path.Combine(sCurrentDirectory, @$"../../../Levels/TestSave");
                sFile = System.IO.Path.Combine(sCurrentDirectory, @$"../../../Levels/TestSave/");
            }
            else
            {
                sDirectory = System.IO.Path.Combine(sCurrentDirectory, @$"..\..\..\Levels\TestSave");
                sFile = System.IO.Path.Combine(sCurrentDirectory, @$"..\..\..\Levels\TestSave\");
            }

            Debug.WriteLine(sDirectory);
            Debug.WriteLine("\nExists? " + System.IO.Directory.Exists(sDirectory));
            System.IO.Directory.CreateDirectory(sDirectory);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;

            foreach (Room room in loader.allRooms)
                {
                sFile = sFile + room.name + ".xml";
                using (XmlWriter xw = XmlWriter.Create(sFile, settings))
                    {
                        XDocument roomDoc = new XDocument(
                            new XElement("XnaContent",
                            getPointers(room)));

                        roomDoc.Save(xw);
                    }
                }

        }

        public XElement getPointers(Room room)
        {
            XElement pointers = new XElement("Pointers");
            if (room.northRoomPtr != null)
            {
                pointers.Add("NorthRoom", room.northRoomPtr.name);
            }
            if (room.southRoomPtr != null)
            {
                pointers.Add("SouthRoom", room.southRoomPtr.name);
            }
            if (room.eastRoomPtr != null)
            {
                pointers.Add("EastRoom", room.eastRoomPtr.name);
            }
            if (room.westRoomPtr != null)
            {
                pointers.Add("WestRoom", room.westRoomPtr.name);
            }
            return pointers;
        }

        public XElement getMeta(Room room)
        {
            XElement meta = new XElement("Meta");

            return meta;
        }
    }
}
