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

namespace sprint0
{ 

    public class LevelLoader
    {

        public Game1 game;
        public GameObjectManager gameObjectManager;

        public List<ItemObject> itemObjList = new List<ItemObject>();

        public LevelLoader(Game1 game)
        {
            this.game = game;
            this.gameObjectManager = game.manager;
        }


        public void printOut(String levelName)
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile;

            //Gets file location based on operating system
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                sFile = System.IO.Path.Combine(sCurrentDirectory, @$"../../../Content/Levels/{levelName}.xml");
            }
            else
            {
                sFile = System.IO.Path.Combine(sCurrentDirectory, @$"..\..\..\Content\Levels\{levelName}.xml");
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

                itemObjList.Add(itemObj);
            }
        }

    }
}

