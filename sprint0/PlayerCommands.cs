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
        //private IPlayer player;
        private GameObjectManager manager;
        private Direction direction;
        public PlayerRunningCommand(Game1 game, Direction direction)
        {
            this.game = game;
            this.direction = direction;
            //player = game.player;
            manager = game.manager;
        }
        public void Execute()
        {
            //game.player.Direction = direction;
            //game.player.State = State.RUNNING;
            manager.player.Direction = direction;
            manager.player.State = State.RUNNING;

            Vector2 newVelocity = Vector2.Zero;

            switch (direction)
            {
                case Direction.LEFT:
                    newVelocity.X -= 1;
                    manager.player.Direction = Direction.LEFT;
                    break;
                case Direction.RIGHT:
                    newVelocity.X += 1;
                    manager.player.Direction = Direction.RIGHT;
                    break;
                case Direction.UP:
                    newVelocity.Y -= 1;
                    manager.player.Direction = Direction.UP;
                    break;
                case Direction.DOWN:
                    newVelocity.Y += 1;
                    manager.player.Direction = Direction.DOWN;
                    break;
                default:
                    break;
            }
            //Vector2 oldVelocity = game.player.Velocity;
            Vector2 oldVelocity = manager.player.Velocity;
            //Debug.WriteLine(game.player.Velocity);
            Debug.WriteLine(manager.player.Velocity);
            //game.player.Velocity = oldVelocity + newVelocity;
            manager.player.Velocity = oldVelocity + newVelocity;
            //Debug.WriteLine(game.player.Velocity);
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
            //player = game.player;
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

            //Vector2 oldVelocity = player.Velocity;
            Vector2 oldVelocity = manager.player.Velocity;
            //player.Velocity = oldVelocity + newVelocity;
            manager.player.Velocity = oldVelocity + newVelocity;

            manager.UpdatePlayerState();
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
            //player = game.player;
            player = manager.player;
        }

        public void Execute()
        {
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
            //player = game.player;
            manager = game.manager;
            player = manager.player;
        }

        public void Execute()
        {
            Projectile arrow = ProjectileFactory.Instance.ZeldaArrow(player.Position, player.Direction);
            manager.AddObject(arrow);
        }
    }
}
