using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    internal class ProjectileFactory
    {
        private static ProjectileFactory instance = new ProjectileFactory();
        public static ProjectileFactory Instance { get { return instance; } }

        private ProjectileFactory() { }

        public Projectile ZeldaArrow(Vector2 position, Direction direction)
        {
            return new ZeldaArrow(position, direction);
        }
    }

    internal class ZeldaArrow : Projectile
    {
        public ZeldaArrow(Vector2 position, Direction direction)
        {
            Sprite = SpriteFactory.Instance.ZeldaArrow(position);

            Vector2 velocity = Vector2.Zero;

            switch (direction)
            {
                case Direction.LEFT:
                    velocity.X -= 5;
                    break;
                case Direction.RIGHT:
                    velocity.X += 5;
                    break;
                case Direction.UP:
                    velocity.Y -= 5;
                    break;
                case Direction.DOWN:
                    velocity.Y += 5;
                    break;
                default:
                    break;
            }

            Velocity = velocity;
        }
    }
}
