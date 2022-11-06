using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            manager.RemoveObject(item);
        }
    }
}