using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    internal class PlayerItemCollisionCommand : ICommand
    {
        IObject player;
        IObject item;
        string intersectionLoc;
        GameObjectManager manager;
        public PlayerItemCollisionCommand(IObject player, IObject item, string intersectionLoc, GameObjectManager manager)
        {
            this.player = player;
            this.item = item;
            this.intersectionLoc = intersectionLoc;
            this.manager = manager;
        }

        public void Execute()
        {
            //link will have all items to start with, they wont pick up any items yet
            Type ItemType = item.GetType();
            string ItemName = ItemType.Name;
            if (ItemName == "ZeldaRupy")
            {
                manager.inventory.Coins++;
                manager.inventory.CoinTextSprite.Text = manager.inventory.Coins.ToString();
            }
            else if (ItemName == "ZeldaKey")
            {
                manager.inventory.Keys++;
                manager.inventory.KeyTextSprite.Text = manager.inventory.Keys.ToString();
            }
            else if (ItemName == "ZeldaBoomerang")
            {
                manager.inventory.Boomerangs++;
                manager.inventory.BoomerangTextSprite.Text = manager.inventory.Boomerangs.ToString();
            }
            else if (ItemName == "ZeldaBow")
            {
                
            }
        }
    }
}