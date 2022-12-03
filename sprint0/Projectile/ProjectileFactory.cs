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

        //Trying to make the sword do damage
        //public Projectile ZeldaSword(Vector2 position, Direction direction)
        //{
        //    return new ZeldaSword(position, direction);
        //}

        public Projectile ZeldaBoomerang(Vector2 position, Direction direction, string shooter = "")
        {
            return new ZeldaBoom(position, direction, shooter);
        }

        public Projectile ZeldaRock(Vector2 position, Direction direction)
        {
            return new ZeldaRock(position, direction);
        }

        public Projectile ZeldaFire(Vector2 position, Direction direction)
        {
            return new ZeldaFire(position, direction);
        }

        public Projectile ZeldaDragonProj(Vector2 position, Vector2 velocity)
        {
            return new ZeldaDragonProj(position, velocity);
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
                    arrowThrowPosition = new Vector2(position.X + 11, position.Y + 36);
                    Sprite = SpriteFactory.Instance.ZeldaArrowLeft(arrowThrowPosition);
                    velocity.X -= 5;
                    InitPosition = arrowThrowPosition;
                    break;
                case Direction.RIGHT:
                    arrowThrowPosition = new Vector2(position.X + 22, position.Y + 36);
                    Sprite = SpriteFactory.Instance.ZeldaArrowRight(arrowThrowPosition);
                    velocity.X += 5;
                    InitPosition = new Vector2(850, -100);
                    break;
                case Direction.UP:
                    arrowThrowPosition = new Vector2(position.X + 36, position.Y + 0);
                    Sprite = SpriteFactory.Instance.ZeldaArrowUp(arrowThrowPosition);
                    velocity.Y -= 5;
                    InitPosition = arrowThrowPosition;
                    break;
                case Direction.DOWN:
                    arrowThrowPosition = new Vector2(position.X + 36, position.Y + 22);
                    Sprite = SpriteFactory.Instance.ZeldaArrowDown(arrowThrowPosition);
                    velocity.Y += 5;
                    InitPosition = arrowThrowPosition;
                    break;
                default:
                    break;
            }

            Velocity = velocity;
            CollideDamage = 3;
        }
    }

    internal class ZeldaFire : Projectile
    {
        public ZeldaFire(Vector2 position, Direction direction)
        {
            Vector2 velocity = Vector2.Zero;
            Vector2 arrowThrowPosition = Vector2.Zero;
            // TODO: data-drive
            // TODO: magic numbers
            switch (direction)
            {
                case Direction.LEFT:
                    arrowThrowPosition = new Vector2(position.X + 11, position.Y + 20);
                    Sprite = SpriteFactory.Instance.ZeldaFire(arrowThrowPosition);
                    velocity.X -= 5;
                    break;
                case Direction.RIGHT:
                    arrowThrowPosition = new Vector2(position.X + 22, position.Y + 20);
                    Sprite = SpriteFactory.Instance.ZeldaFire(arrowThrowPosition);
                    velocity.X += 5;
                    break;
                case Direction.UP:
                    arrowThrowPosition = new Vector2(position.X + 13, position.Y + 14);
                    Sprite = SpriteFactory.Instance.ZeldaFire(arrowThrowPosition);
                    velocity.Y -= 5;
                    break;
                case Direction.DOWN:
                    arrowThrowPosition = new Vector2(position.X + 22, position.Y + 22);
                    Sprite = SpriteFactory.Instance.ZeldaFire(arrowThrowPosition);
                    velocity.Y += 5;
                    break;
                default:
                    break;
            }
            InitPosition = arrowThrowPosition;
            Velocity = velocity;
            CollideDamage = 5;
        }
    }

    internal class ZeldaBoom : Projectile
    {
        public ZeldaBoom(Vector2 position, Direction direction, string shooter)
        {
            Vector2 velocity = Vector2.Zero;
            Sprite = SpriteFactory.Instance.ZeldaBoomerang(position);
            Vector2 arrowThrowPosition = position;
            InitPosition = position;

            // TODO: data-drive
            // TODO: magic numbers
            switch (direction)
            {
                case Direction.LEFT:
                    if (shooter.Equals("player"))
                    {
                        arrowThrowPosition = new Vector2(position.X + 11, position.Y + 20);
                        Sprite = SpriteFactory.Instance.ZeldaBoomerang(arrowThrowPosition);
                        InitPosition = arrowThrowPosition;
                        Direction = Direction.LEFT;
                    }
                    velocity.X -= 7;
                    break;
                case Direction.RIGHT:
                    if (shooter.Equals("player"))
                    {
                        arrowThrowPosition = new Vector2(position.X + 22, position.Y + 20);
                        Sprite = SpriteFactory.Instance.ZeldaBoomerang(arrowThrowPosition);
                        InitPosition = arrowThrowPosition;
                        Direction = Direction.RIGHT;
                    }
                    velocity.X += 7;
                    break;
                case Direction.UP:
                    if (shooter.Equals("player"))
                    {
                        arrowThrowPosition = new Vector2(position.X + 13, position.Y + 14);
                        Sprite = SpriteFactory.Instance.ZeldaBoomerang(arrowThrowPosition);
                        InitPosition = arrowThrowPosition;
                        Direction = Direction.UP;
                    }
                    velocity.Y -= 7;
                    break;
                case Direction.DOWN:
                    if (shooter.Equals("player"))
                    {
                        arrowThrowPosition = new Vector2(position.X + 22, position.Y + 22);
                        Sprite = SpriteFactory.Instance.ZeldaBoomerang(arrowThrowPosition);
                        InitPosition = arrowThrowPosition;
                        Direction = Direction.DOWN;
                    }
                    velocity.Y += 7;
                    break;
                default:
                    break;
            }

            Velocity = velocity;
            CollideDamage = 5;
        }
    }

    //Trying for sword damage
    //internal class ZeldaSword : Projectile
    //{
    //    public ZeldaSword(Vector2 position, Direction direction)
    //    {
    //        Vector2 velocity = Vector2.Zero;
    //        switch (direction)
    //        {
    //            case Direction.LEFT:
    //                Sprite = SpriteFactory.Instance.LinkAttackingLeft(position);
    //                break;
    //            case Direction.RIGHT:
    //                Sprite = SpriteFactory.Instance.LinkAttackingRight(position);
    //                break;
    //            case Direction.UP:
    //                Sprite = SpriteFactory.Instance.LinkAttackingUp(position);
    //                break;
    //            case Direction.DOWN:
    //                Sprite = SpriteFactory.Instance.LinkAttackingDown(position);
    //                break;
    //            default:
    //                break;
    //        }
    //        Velocity = velocity;
    //        InitPosition = position;
    //        CollideDamage = 10;
    //    }
    //}

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
            CollideDamage = 5;
        }
    }

    internal class ZeldaDragonProj : Projectile
    {
        public ZeldaDragonProj(Vector2 position, Vector2 velocity)
        {
            Sprite = SpriteFactory.Instance.ZeldaDragonProj(position);
            Velocity = velocity;
            InitPosition = position;
            CollideDamage = 5;
        }
    }
}
