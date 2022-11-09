using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    internal class PlayerDoorCollisionCommand : ICommand
    {
        IObject player;
        IObject block;
        string intersectionLoc;
        public PlayerDoorCollisionCommand(IObject player, IObject block, string intersectionLoc, GameObjectManager manager)
        {
            this.player = player;
            this.block = block;
            this.intersectionLoc = intersectionLoc;
        }

        public void Execute()
        {
            Player player = (Player)this.player;
            if (intersectionLoc == "top")
            {
                if (player.Velocity.Y > 0)  // if the velocity is directed towards the block
                {
                    player.Position -= new Vector2(0, 2);
                }
            }
            else if (intersectionLoc == "bottom")
            {
                if (player.Velocity.Y < 0)
                {
                    player.Position += new Vector2(0, 2);
                }
            }
            else if (intersectionLoc == "left")
            {
                if (player.Velocity.X < 0)
                {
                    player.Position += new Vector2(2, 0);
                }
            }
            else //right
            {
                if (player.Velocity.X > 0)
                {
                    player.Position -= new Vector2(2, 0);
                }
            }
        }
    }
}