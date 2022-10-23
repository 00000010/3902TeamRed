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

        // Position should be the player position starting at top left, not including empty space.
        public Projectile ZeldaArrow(Vector2 position, Direction direction)
        {
            return new ZeldaArrow(position, direction);
        }

        public Projectile ZeldaBoomerang(Vector2 position, Direction direction)
        {
            return new ZeldaBoom(position, direction);
        }

        public Projectile ZeldaRock(Vector2 position, Direction direction)
        {
            return new ZeldaRock(position, direction);
        }
    }

    internal class ZeldaArrow : Projectile
    {
        public ZeldaArrow(Vector2 position, Direction direction)
        {
            Vector2 velocity = Vector2.Zero;
            Vector2 arrowThrowPosition = Vector2.Zero;

            // TODO: data-drive
            // TODO: magic numbers
            switch (direction)
            {
                case Direction.LEFT:
                    arrowThrowPosition = new Vector2(position.X + 11, position.Y + 20);
                    Sprite = SpriteFactory.Instance.ZeldaArrowLeft(arrowThrowPosition);
                    velocity.X -= 5;
                    InitPosition = arrowThrowPosition;
                    break;
                case Direction.RIGHT:
                    arrowThrowPosition = new Vector2(position.X + 22, position.Y + 20);
                    Sprite = SpriteFactory.Instance.ZeldaArrowRight(arrowThrowPosition);
                    velocity.X += 5;
                    InitPosition = new Vector2(850,-100);
                    break;
                case Direction.UP:
                    arrowThrowPosition = new Vector2(position.X + 13, position.Y + 14);
                    Sprite = SpriteFactory.Instance.ZeldaArrowUp(arrowThrowPosition);
                    velocity.Y -= 5;
                    InitPosition = arrowThrowPosition;
                    break;
                case Direction.DOWN:
                    arrowThrowPosition = new Vector2(position.X + 22, position.Y + 22);
                    Sprite = SpriteFactory.Instance.ZeldaArrowDown(arrowThrowPosition);
                    velocity.Y += 5;
                    InitPosition = arrowThrowPosition;
                    break;
                default:
                    break;
            }

            Velocity = velocity;
        }
    }

    internal class ZeldaBoom : Projectile
    {
        public ZeldaBoom(Vector2 position, Direction direction)
        {
            Vector2 velocity = Vector2.Zero;
            Sprite = SpriteFactory.Instance.ZeldaBoomerang(position);

            // TODO: data-drive
            // TODO: magic numbers
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
            InitPosition = position;
        }
    }

    internal class ZeldaRock : Projectile
    {
        public ZeldaRock(Vector2 position, Direction direction)
        {
            Vector2 velocity = Vector2.Zero;
            Sprite = SpriteFactory.Instance.ZeldaRock(position);

            // TODO: data-drive
            // TODO: magic numbers
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
            InitPosition = position;
        }
    }
}
