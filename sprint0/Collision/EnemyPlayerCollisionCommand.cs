using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    internal class EnemyPlayerCollisionCommand : ICommand
    {
        IObject enemy;
        IObject player;
        string intersectionLoc;
        GameObjectManager manager;
        public EnemyPlayerCollisionCommand(IObject player, IObject enemy, string intersectionLoc, GameObjectManager manager)
        {
            this.enemy = enemy;
            this.player = player;
            this.intersectionLoc = intersectionLoc;
            this.manager = manager;
        }

        public void Execute()
        {
            Enemy enemy = (Enemy)this.enemy;
            if (intersectionLoc.Contains("up"))
            {
                if (enemy.Velocity.Y > 0)  // if the velocity is directed towards the block
                {
                    enemy.Position -= new Vector2(0, 10);
                }
            }
            if (intersectionLoc.Contains("down"))
            {
                if (enemy.Velocity.Y < 0)
                {
                    enemy.Position += new Vector2(0, 10);
                }
            }
            if (intersectionLoc.Contains("left"))
            {
                if (enemy.Velocity.X < 0)
                {
                    enemy.Position -= new Vector2(10, 0);
                }
            }
            if (intersectionLoc.Contains("right"))
            {
                if (enemy.Velocity.X > 0)
                {
                    enemy.Position += new Vector2(10, 0);
                }
            }
        }
    }
}