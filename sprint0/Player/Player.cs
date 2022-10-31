using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    internal class Player : IPlayer, IObject, IShooter
    {
        public Sprite Sprite { get; set; }
        public Vector2 Position { get { return Sprite.Position; } set { Sprite.Position = value; } }
        public Vector2 Velocity { get { return Sprite.Velocity; } set { Sprite.Velocity = value; } }
        public Direction Direction { get; set; }
        public State State { get; set; }
        public bool TakingDamage { get; set; }
        public string TypeOfObject { get; set; }
        public bool ShotBoomerang { get; set; }
        public GameTime LastDamaged { get; set; }
        public int Health { get; set; }
        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public int Damaged { get; set; }

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        
        public Player() {}
        public virtual void Draw(GameTime gameTime)
        {
            Sprite.Draw(gameTime);
        }

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Position += Velocity;
            Sprite.Update(gameTime);
        }

        public void UpdatePlayerSprite(GameObjectManager manager)
        {
            Vector2 velocity = Velocity;
            if (velocity.X == 0)
            {
                if (velocity.Y < 0)
                {
                    Direction = Direction.UP;
                }
                else if (velocity.Y > 0)
                {
                    Direction = Direction.DOWN;
                }
            }

            if (velocity.Y == 0)
            {
                if (velocity.X < 0)
                {
                    Direction = Direction.LEFT;
                }
                else if (velocity.X > 0)
                {
                    Direction = Direction.RIGHT;
                }
            }

            if (TakingDamage)
            {
                switch (State)
                {
                    case State.RUNNING:
                        switch (Direction)
                        {
                            case Direction.UP:
                                Sprite = SpriteFactory.Instance.LinkRunningUpDamaged(Position);
                                break;
                            case Direction.DOWN:
                                Sprite = SpriteFactory.Instance.LinkRunningDownDamaged(Position);
                                break;
                            case Direction.LEFT:
                                Sprite = SpriteFactory.Instance.LinkRunningLeftDamaged(Position);
                                break;
                            case Direction.RIGHT:
                                Sprite = SpriteFactory.Instance.LinkRunningRightDamaged(Position);
                                break;
                            default:
                                break;
                        }
                        break;
                    case State.STANDING:
                        switch (Direction)
                        {
                            case Direction.UP:
                                Sprite = SpriteFactory.Instance.LinkStandingUpDamaged(Position);
                                break;
                            case Direction.DOWN:
                                Sprite = SpriteFactory.Instance.LinkStandingDownDamaged(Position);
                                break;
                            case Direction.LEFT:
                                Sprite = SpriteFactory.Instance.LinkStandingLeftDamaged(Position);
                                break;
                            case Direction.RIGHT:
                                Sprite = SpriteFactory.Instance.LinkStandingRightDamaged(Position);
                                break;
                            default:
                                break;
                        }
                        break;
                    case State.ATTACKING:
                        switch (Direction)
                        {
                            case Direction.UP:
                                Sprite = SpriteFactory.Instance.LinkAttackingUpDamaged(Position);
                                break;
                            case Direction.DOWN:
                                Sprite = SpriteFactory.Instance.LinkAttackingDownDamaged(Position);
                                break;
                            case Direction.LEFT:
                                Sprite = SpriteFactory.Instance.LinkAttackingLeftDamaged(Position);
                                break;
                            case Direction.RIGHT:
                                Sprite = SpriteFactory.Instance.LinkAttackingRightDamaged(Position);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                Health -= Damaged;
                if (Health <= 0)
                {
                    manager.RemovePlayer();
                    SoundFactory.Instance.zeldaLinkDie.Play();
                }
            }
            else
            {
                switch (State)
                {
                    case State.RUNNING:
                        switch (Direction)
                        {
                            case Direction.UP:
                                Sprite = SpriteFactory.Instance.LinkRunningUp(Position);
                                break;
                            case Direction.DOWN:
                                Sprite = SpriteFactory.Instance.LinkRunningDown(Position);
                                break;
                            case Direction.LEFT:
                                Sprite = SpriteFactory.Instance.LinkRunningLeft(Position);
                                break;
                            case Direction.RIGHT:
                                Sprite = SpriteFactory.Instance.LinkRunningRight(Position);
                                break;
                            default:
                                break;
                        }
                        break;
                    case State.STANDING:
                        switch (Direction)
                        {
                            case Direction.UP:
                                Sprite = SpriteFactory.Instance.LinkStandingUp(Position);
                                break;
                            case Direction.DOWN:
                                Sprite = SpriteFactory.Instance.LinkStandingDown(Position);
                                break;
                            case Direction.LEFT:
                                Sprite = SpriteFactory.Instance.LinkStandingLeft(Position);
                                break;
                            case Direction.RIGHT:
                                Sprite = SpriteFactory.Instance.LinkStandingRight(Position);
                                break;
                            default:
                                break;
                        }
                        break;
                    case State.ATTACKING:
                        switch (Direction)
                        {
                            case Direction.UP:
                                Sprite = SpriteFactory.Instance.LinkAttackingUp(Position);
                                break;
                            case Direction.DOWN:
                                Sprite = SpriteFactory.Instance.LinkAttackingDown(Position);
                                break;
                            case Direction.LEFT:
                                Sprite = SpriteFactory.Instance.LinkAttackingLeft(Position);
                                break;
                            case Direction.RIGHT:
                                Sprite = SpriteFactory.Instance.LinkAttackingRight(Position);
                                break;
                            default:
                                break;
                        }
                        break;
                    case State.THROWING:
                        switch (Direction)
                        {
                            case Direction.UP:
                                Sprite = SpriteFactory.Instance.LinkThrowingUp(Position);
                                break;
                            case Direction.DOWN:
                                Sprite = SpriteFactory.Instance.LinkThrowingDown(Position);
                                break;
                            case Direction.LEFT:
                                Sprite = SpriteFactory.Instance.LinkThrowingLeft(Position);
                                break;
                            case Direction.RIGHT:
                                Sprite = SpriteFactory.Instance.LinkThrowingRight(Position);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            Velocity = velocity;
        }
    }
}
