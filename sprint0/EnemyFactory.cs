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
            return new Stalfos(position);
        }

        public Enemy Keese(Vector2 position)
        {
            return new Keese(position);
        }

        public Enemy Gel(Vector2 position)
        {
            return new Gel(position);
        }

        public Enemy Goriya(Vector2 position)
        {
            return new Goriya(position);
        }

        public Enemy Octorok(Vector2 position)
        {
            return new Octorok(position);
        }

        public Enemy DungeonMonster1(Vector2 position)
        {
            return new DungeonMonster1(position);
        }

        public Enemy DungeonMonster2(Vector2 position)
        {
            return new DungeonMonster2(position);
        }

        public Enemy DungeonMonster1Faded(Vector2 position)
        {
            return new DungeonMonster1Faded(position);
        }

        public Enemy DungeonMonster2Faded(Vector2 position)
        {
            return new DungeonMonster2Faded(position);
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
        }
    }

    internal class Octorok : Enemy
    {
        public Octorok(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.Octorok(position);
            Direction = Direction.DOWN;
            Velocity = Vector2.Zero;
        }
    }

    internal class DungeonMonster1 : Enemy
    {
        public DungeonMonster1(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonMonster1(position);
            Velocity = Vector2.Zero;
        }
    }

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
