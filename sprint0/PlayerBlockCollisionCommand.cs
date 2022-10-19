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
            Player Player = (Player)player;
            if (intersectionLoc == "top")
            {
                if (Player.Velocity.Y > 0)  // if the velocity is directed towards the block
                {
                    Player.Velocity = Vector2.Zero;
                }
            }
            else if (intersectionLoc == "bottom")
            {
                if (Player.Velocity.Y < 0)
                {
                    Player.Velocity = Vector2.Zero;
                }
            }
            else if (intersectionLoc == "left")
            {
                if (Player.Velocity.X < 0)
                {
                    Player.Velocity = Vector2.Zero;
                }
            }
            else //right
            {
                if (Player.Velocity.X > 0)
                {
                    Player.Velocity = Vector2.Zero;
                }
            }
        }
    }
}