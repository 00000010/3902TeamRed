using System;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace sprint0
{
    public class SaveLevelCommand : ICommand
    {
        GameObjectManager manager;
        Game1 game;
        LevelLoader loader;


        public SaveLevelCommand(Game1 game, LevelLoader loader)
        {
            this.manager = game.manager;
            this.game = game;
            this.loader = loader;
        }

        public void Execute()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile;

            //Gets file location based on operating system
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                sFile = System.IO.Path.Combine(sCurrentDirectory, @$"../../../Content/Levels/TestSave.xml");
            }
            else
            {
                sFile = System.IO.Path.Combine(sCurrentDirectory, @$"..\..\..\Content\Levels\TestSave.xml");
            }
            XDocument level = new XDocument();

            foreach (ItemObject obj in loader.allItemObjects)
            {
                Console.WriteLine(obj.ToString());
            }
        }
    }
}

