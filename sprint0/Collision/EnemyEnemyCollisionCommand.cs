using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0
{
    internal class EnemyEnemyCollisionCommand : ICommand
    {
        IObject enemy1;
        IObject enemy2;
        string intersectionLoc;
        GameObjectManager manager;
        public EnemyEnemyCollisionCommand(IObject enemy1, IObject enemy2, string intersectionLoc, GameObjectManager manager)
        {
            this.enemy1 = enemy1;
            this.enemy2 = enemy2;
            this.intersectionLoc = intersectionLoc;
            this.manager = manager;
        }

        public void Execute()
        {
            Enemy Enemy1 = (Enemy)enemy1;
            Enemy Enemy2 = (Enemy)enemy2;
            if (intersectionLoc.Contains("up"))
            {
                if (Enemy1.Velocity.Y > 0 || Enemy2.Velocity.Y < 0)  // if the enemy1 is directed towards enemy2 OR enemy2 moving towards enemy1
                {
                    Enemy1.Position -= new Vector2(0, 1);
                }
            }
            if (intersectionLoc.Contains("down"))
            {
                if (Enemy1.Velocity.Y < 0 || Enemy2.Velocity.Y > 0)
                {
                    Enemy1.Position += new Vector2(0, 1);
                }
            }
            if (intersectionLoc.Contains("left"))
            {
                if (Enemy1.Velocity.X > 0 || Enemy2.Velocity.X < 0)
                {
                    Enemy1.Position -= new Vector2(1, 0);
                }
            }
            if (intersectionLoc.Contains("right"))
            {
                if (Enemy1.Velocity.X < 0 || Enemy2.Velocity.X > 0)
                {
                    Enemy1.Position -= new Vector2(-1, 0);
                }
            }
        }
    }
}