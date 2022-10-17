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
        ISprite player;
        ISprite item;
        string intersectionLoc;
        GameObjectManager manager;
        public PlayerItemCollisionCommand(ISprite player, ISprite item, string intersectionLoc, GameObjectManager manager)
        {
            this.player = player;
            this.item = item;
            this.intersectionLoc = intersectionLoc;
            this.manager = manager;
        }

        public void Execute()
        {
            //link will have all items to start with, they wont pick up any items yet
        }
    }
}