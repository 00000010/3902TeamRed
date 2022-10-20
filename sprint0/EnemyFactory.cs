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
}
