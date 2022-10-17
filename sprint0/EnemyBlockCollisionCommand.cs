using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    internal class EnemyBlockCollisionCommand : ICommand
    {
        IObject enemy;
        IObject block;
        string intersectionLoc;
        GameObjectManager manager;
        public EnemyBlockCollisionCommand(IObject enemy, IObject block, string intersectionLoc, GameObjectManager manager)
        {
            this.enemy = enemy;
            this.block = block;
            this.intersectionLoc = intersectionLoc;
            this.manager = manager;
        }

        public void Execute()
        {
            Enemy Enemy = (Enemy)enemy;
            if (intersectionLoc == "top")
            {
                if (Enemy.Velocity.Y > 0)  // if the velocity is directed towards the block
                {
                    Enemy.Velocity = Vector2.Zero;
                }
            }
            else if (intersectionLoc == "bottom")
            {
                if (Enemy.Velocity.Y < 0)
                {
                    Enemy.Velocity = Vector2.Zero;
                }
            }
            else if (intersectionLoc == "left")
            {
                if (Enemy.Velocity.X < 0)
                {
                    Enemy.Velocity = Vector2.Zero;
                }
            }
            else //right
            {
                if (Enemy.Velocity.X > 0)
                {
                    Enemy.Velocity = Vector2.Zero;
                }
            }
        }
    }
}