﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
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
                if (enemy.Velocity.Y > 0)  // if the velocity is directed towards the block
                {
                    enemy.Position -= new Vector2(0, 5);
                }
            }
            if (intersectionLoc.Contains("down"))
            {
                if (enemy.Velocity.Y < 0)
                {
                    enemy.Position += new Vector2(0, 5);
                }
            }
            if (intersectionLoc.Contains("left"))
            {
                if (enemy.Velocity.X > 0)
                {
                    enemy.Position -= new Vector2(5, 0);
                }
            }
            if (intersectionLoc.Contains("right"))
            {
                if (enemy.Velocity.X < 0)
                {
                    enemy.Position += new Vector2(5, 0);
                }
            }
        }
    }
}