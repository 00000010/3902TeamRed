using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class PlaceBlockCommand : ICommand
    {

        Vector2 location;
        GameObjectManager manager;
        LevelLoader loader;
        LevelCreator creator;

        public PlaceBlockCommand(Game1 game, Vector2 location, LevelLoader loader)
        {
            this.location = location;
            this.manager = game.manager;
            this.loader = loader;
        }

        public void Execute()
        {
            Block block = BlockFactory.Instance.ZeldaBlackBlock(location);
            manager.AddObject(block);
            //ToXML(block);
        }

        //public void ToXML(Object block)
        //{
        //    ItemObject newItem = new ItemObject();
        //    newItem.ObjectType = block.GetType;
        //    newItem.ObjectName = "DungeonSand";
        //    newItem.Locati
        //    creator.XmlObjs.Add(newItem.toXmlElement());
        //}
    }
}