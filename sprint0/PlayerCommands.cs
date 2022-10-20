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
            manager.UpdatePlayerSprite();
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
            player = manager.player;
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

            Vector2 oldVelocity = player.Velocity;
            player.Velocity = oldVelocity + newVelocity;

            manager.UpdatePlayerState();
            manager.UpdatePlayerSprite();
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
            manager.UpdatePlayerState();
            manager.UpdatePlayerSprite();
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
        }

        public void Execute()
        {
            player = manager.player;
            player.State = State.ATTACKING;
            player.Velocity = Vector2.Zero; // TODO: comment this line out to make Link attack and kind of keep running; causes weird bug where Link can somehow disappear...; need to decide whether to fix this or call it a feature
            manager.UpdatePlayerSprite();
        }
    }

    internal class PlayerDamageCommand : ICommand
    {
        private Game1 game;
        private IPlayer player;
        private GameObjectManager manager;

        public PlayerDamageCommand(Game1 game)
        {
            this.game = game;
            manager = game.manager;
        }

        public void Execute()
        {
            player = manager.player; // player must be set here; if set in constructor, player is null since it has not been added to the manager yet
            player.TakingDamage = !player.TakingDamage;
            manager.UpdatePlayerSprite();
        }
    }

    internal class PlayerArrowCommand : ICommand
    {
        private Game1 game;
        private IPlayer player;
        private GameObjectManager manager;

        public PlayerArrowCommand(Game1 game)
        {
            this.game = game;
            manager = game.manager;
        }

        public void Execute()
        {
            player = manager.player;
            Projectile arrow = ProjectileFactory.Instance.ZeldaArrow(player.Position, player.Direction);
            manager.AddObject(arrow);
        }
    }
}
