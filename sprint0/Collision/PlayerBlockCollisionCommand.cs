using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    internal class PlayerBlockCollisionCommand : ICommand
    {
        IObject player;
        IObject block;
        string intersectionLoc;
        public PlayerBlockCollisionCommand(IObject player, IObject block, string intersectionLoc, GameObjectManager manager)
        {
            this.player = player;
            this.block = block;
            this.intersectionLoc = intersectionLoc;
        }

        public void Execute()
        {
            Player player = (Player)this.player;
            if (intersectionLoc.Contains("up"))
            {
                if (player.Velocity.Y > 0)  // if the velocity is directed towards the block
                {
                    player.Position -= new Vector2(0, 2);
                }
            }
            if (intersectionLoc.Contains("down"))
            {
                if (player.Velocity.Y < 0)
                {
                    player.Position += new Vector2(0, 2);
                }
            }
            if (intersectionLoc.Contains("left"))
            {
                if (player.Velocity.X > 0)
                {
                    player.Position -= new Vector2(2, 0);
                }
            }
            if (intersectionLoc.Contains("right"))
            {
                if (player.Velocity.X < 0)
                {
                    player.Position += new Vector2(2, 0);
                }
            }
        }
    }
}