using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    internal class PlayerRunningCommand : ICommand
    {
        private Game1 game;
        private GameObjectManager manager;
        private Direction direction;
        public PlayerRunningCommand(Game1 game, Direction direction)
        {
            this.game = game;
            this.direction = direction;
            manager = game.manager;
        }
        public void Execute()
        {
            manager.player.Direction = direction;
            manager.player.State = State.RUNNING;

            Vector2 newVelocity = Vector2.Zero;

            switch (direction)
            {
                case Direction.LEFT:
                    newVelocity.X -= 1;
                    break;
                case Direction.RIGHT:
                    newVelocity.X += 1;
                    break;
                case Direction.UP:
                    newVelocity.Y -= 1;
                    break;
                case Direction.DOWN:
                    newVelocity.Y += 1;
                    break;
                default:
                    break;
            }
            Vector2 oldVelocity = manager.player.Velocity;
            Debug.WriteLine(manager.player.Velocity);
            manager.player.Velocity = oldVelocity + newVelocity;
            Debug.WriteLine(manager.player.Velocity);
            manager.player.UpdatePlayerSprite(manager);
        }
    }

    internal class PlayerStandingCommand : ICommand
    {
        private Game1 game;
        private IPlayer player;
        private GameObjectManager manager;
        private Direction direction;

        public PlayerStandingCommand(Game1 game, Direction direction)
        {
            this.game = game;
            this.direction = direction;
            manager = game.manager;
        }

        public void Execute()
        {
            Vector2 newVelocity = Vector2.Zero;

            switch (direction)
            {
                case Direction.LEFT:
                    newVelocity.X += 1;
                    break;
                case Direction.RIGHT:
                    newVelocity.X -= 1;
                    break;
                case Direction.UP:
                    newVelocity.Y += 1;
                    break;
                case Direction.DOWN:
                    newVelocity.Y -= 1;
                    break;
                default:
                    break;
            }

            Vector2 oldVelocity = manager.player.Velocity;
            manager.player.Velocity = oldVelocity + newVelocity;

            player.UpdatePlayerState();
            player.UpdatePlayerSprite(manager);
        }
    }

    internal class PlayerStopRunningCommand : ICommand
    {
        private Game1 game;
        private IPlayer player;
        private GameObjectManager manager;
        private Direction direction;

        // Stop running in the CURRENT direction but keep running in other directions if key pressed
        public PlayerStopRunningCommand(Game1 game, Direction direction)
        {
            this.game = game;
            this.direction = direction;
            manager = game.manager;
            player = manager.player;
        }

        public void Execute()
        {
            Vector2 newVelocity = manager.player.Velocity;
            switch (direction)
            {
                case Direction.LEFT:
                case Direction.RIGHT:
                    newVelocity.X = 0;
                    break;
                case Direction.UP:
                case Direction.DOWN:
                    newVelocity.Y = 0;
                    break;
                default:
                    break;
            }
            manager.player.Velocity = newVelocity;
            manager.player.UpdatePlayerState();
            manager.player.UpdatePlayerSprite(manager);
        }
    }

    internal class PlayerAttackingCommand : ICommand
    {
        private Game1 game;
        private IPlayer player;
        private Direction direction;
        private GameObjectManager manager;

        public PlayerAttackingCommand(Game1 game)
        {
            this.game = game;
            manager = game.manager;
            player = manager.player;
        }

        public void Execute()
        {
            player = manager.player;
            player.State = State.ATTACKING;
            player.Velocity = Vector2.Zero;
            player.UpdatePlayerSprite(manager);
            SoundFactory.Instance.zeldaSword.Play();
        }
    }

    internal class PlayerProjCommand : ICommand
    {
        private Game1 game;
        private IPlayer player;
        private GameObjectManager manager;

        public PlayerProjCommand(Game1 game)
        {
            this.game = game;
            manager = game.manager;
            player = manager.player;
        }

        public void Execute()
        {
            player = manager.player;
            Projectile proj = ReturnProj();
            player.State = State.THROWING;
            manager.AddObject(proj);
            manager.shooterOfProjectile.Add(proj, (IShooter) player);
            player.UpdatePlayerSprite(manager);
            SoundFactory.Instance.zeldaArrowBoomerang.Play();
        }

        private Projectile ReturnProj()
        {
            //Want to data-drive this
            Projectile result;
            if (manager.LinkProjectile == TypeOfProj.ARROW)
            {
                result = ProjectileFactory.Instance.ZeldaArrow(player.Position, player.Direction);
            }
            else if (manager.LinkProjectile == TypeOfProj.BOOMERANG)
            {
                result = ProjectileFactory.Instance.ZeldaBoomerang(player.Position, player.Direction, "player");
            } 
            else
            {
                result = ProjectileFactory.Instance.ZeldaFire(player.Position, player.Direction);
            }
            return result;
        }
    }
}
