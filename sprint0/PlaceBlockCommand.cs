using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
	public class PlaceBlockCommand : ICommand
	{

		Vector2 location;
		GameObjectManager manager;
		LevelLoader loader;

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
			ToXML();
        }

		public void ToXML()
        {
			ItemObject newItem = new ItemObject("Block", "ZeldaBlackBlock", "1 1", location);
			loader.allItemObjects.Add(newItem);
        }
	}
}

