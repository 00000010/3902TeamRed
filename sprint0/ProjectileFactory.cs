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

            Vector2 velocity = Vector2.Zero;

            switch (direction)
            {
                case Direction.LEFT:
                    Sprite = SpriteFactory.Instance.ZeldaArrowLeft(position);
                    velocity.X -= 5;
                    break;
                case Direction.RIGHT:
                    Sprite = SpriteFactory.Instance.ZeldaArrowRight(position);
                    velocity.X += 5;
                    break;
                case Direction.UP:
                    Sprite = SpriteFactory.Instance.ZeldaArrowUp(position);
                    velocity.Y -= 5;
                    break;
                case Direction.DOWN:
                    Sprite = SpriteFactory.Instance.ZeldaArrowDown(position);
                    velocity.Y += 5;
                    break;
                default:
                    break;
            }

            Velocity = velocity;
        }
    }
}
