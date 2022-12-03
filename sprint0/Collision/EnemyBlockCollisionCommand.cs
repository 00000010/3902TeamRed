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
            Enemy enemy = (Enemy)this.enemy;
            if (intersectionLoc.Contains("up"))
            {
                enemy.Position -= new Vector2(0, 5);
            }
            if (intersectionLoc.Contains("down"))
            {
                enemy.Position += new Vector2(0, 5);
            }
            if (intersectionLoc.Contains("left"))
            {
                enemy.Position -= new Vector2(5, 0);
            }
            if (intersectionLoc.Contains("right"))
            {
                enemy.Position += new Vector2(5, 0);
            }
        }
    }
}