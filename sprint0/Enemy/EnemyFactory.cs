using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class EnemyFactory
    {
        private static EnemyFactory instance = new EnemyFactory();

        public static EnemyFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private EnemyFactory() { }

        public Enemy Stalfos(Vector2 position)
        {
            Enemy enemy = new Stalfos(position);
            enemy.CollideDamage = 2;
            enemy.Health = 20;
            return enemy;
        }

        public Enemy Keese(Vector2 position)
        {
            Enemy enemy = new Keese(position);
            enemy.CollideDamage = 2;
            enemy.Health = 5;
            return enemy;
        }

        public Enemy Gel(Vector2 position)
        {
            Enemy enemy = new Gel(position);
            enemy.CollideDamage = 2;
            enemy.Health = 5;
            return enemy;
        }

        public Enemy Goriya(Vector2 position)
        {
            Enemy enemy = new Goriya(position);
            enemy.CollideDamage = 0;
            enemy.Health = 20;
            return enemy;
        }

        public Enemy Octorok(Vector2 position)
        {
            Enemy enemy = new Octorok(position);
            enemy.CollideDamage = 3;
            enemy.Health = 20;
            return enemy;
        }

        public Enemy Dragon(Vector2 position)
        {
            Enemy enemy = new Dragon(position);
            enemy.CollideDamage = 5;
            enemy.Health = 100;
            return enemy;
        }
        public Enemy ZeldaOldMan(Vector2 position)
        {
            Enemy enemy = new ZeldaOldMan(position);
            return enemy;
        }

        //public Enemy DungeonMonster1(Vector2 position)
        //{
        //    Enemy enemy = new DungeonMonster1(position);
        //    enemy.CollideDamage = 0;
        //    return enemy;
        //}

        public Enemy DungeonMonster2(Vector2 position)
        {
            Enemy enemy = new DungeonMonster2(position);
            enemy.CollideDamage = 0;
            return enemy;
        }

        public Enemy DungeonMonster1Faded(Vector2 position)
        {
            Enemy enemy = new DungeonMonster1Faded(position);
            enemy.CollideDamage = 0;
            return enemy;
        }

        public Enemy DungeonMonster2Faded(Vector2 position)
        {
            Enemy enemy = new DungeonMonster2Faded(position);
            enemy.CollideDamage = 0;
            return enemy;
        }
    }

    internal class Stalfos : Enemy
    {
        public Stalfos(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.Stalfos(position);
        }
    }

    internal class Keese : Enemy
    {
        public Keese(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.Keese(position);
        }
    }

    internal class Gel : Enemy
    {
        public Gel(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.Gel(position);
        }
    }

    internal class Goriya : Enemy
    {
        public Goriya(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.GoriyaLeft(position);
            Velocity = new Vector2(-1, 0);
            Direction = Direction.LEFT;
            State = State.RUNNING;
            TypeOfObject = "Enemy";
        }
    }

    internal class Octorok : Enemy
    {
        public Octorok(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.Octorok(position);
            Direction = Direction.DOWN;
            Velocity = Vector2.Zero;
            TypeOfObject = "Enemy";
        }
    }

    internal class Dragon : Enemy
    {
        public Dragon(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaDragon(position);
            Direction = Direction.LEFT;
            Velocity = new Vector2(-1, 0);
            TypeOfObject = "Enemy";
        }
    }

    internal class ZeldaOldMan : Enemy
    {
        public ZeldaOldMan(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaOldMan(position);
            TypeOfObject = "Enemy";
        }
    }

    //internal class DungeonMonster1 : Enemy
    //{
    //    public DungeonMonster1(Vector2 position)
    //    {
    //        Sprite = SpriteFactory.Instance.DungeonMonster1(position);
    //        Velocity = Vector2.Zero;
    //    }
    //}

    internal class DungeonMonster2 : Enemy
    {
        public DungeonMonster2(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonMonster2(position);
            Direction = Direction.DOWN;
            Velocity = Vector2.Zero;
        }
    }

    internal class DungeonMonster1Faded : Enemy
    {
        public DungeonMonster1Faded(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonMonster1Faded(position);
            Direction = Direction.DOWN;
            Velocity = Vector2.Zero;
        }
    }

    internal class DungeonMonster2Faded : Enemy
    {
        public DungeonMonster2Faded(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonMonster2Faded(position);
            Direction = Direction.DOWN;
            Velocity = Vector2.Zero;
        }
    }
}
