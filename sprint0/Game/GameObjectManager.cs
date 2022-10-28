﻿using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace sprint0
{
    public class GameObjectManager
    {
        private Game1 game;
        public IPlayer player;

        public List<IUpdateable> updateables = new List<IUpdateable>();
        public List<IDrawable> drawables = new List<IDrawable>();

        public List<IProjectile> projectilesInFlight = new List<IProjectile>();
        public List<IEnemy> enemies = new List<IEnemy>();
        public List<IBlock> blocks = new List<IBlock>();
        public List<IItem> items = new List<IItem>();
        public Dictionary<IProjectile, IShooter> shooterOfProjectile = new Dictionary<IProjectile, IShooter>();
        public Dictionary<Tuple<string, string>, Type> collisionResolutionDic = new Dictionary<Tuple<string, string>, Type>();
        public HashSet<string> setOfEnemyShooters = new HashSet<string>();

        public List<object> objectsToAdd = new List<object>();
        public List<object> objectsToRemove = new List<object>();

        private int attackingRotation = 0;
        private int damageRotation = 0;

        public GameObjectManager(Game1 game)
        {
            this.game = game;
            PopulateCollisionResolutionDic();
            PopulateEnemyShooters();
        }

        private void PopulateCollisionResolutionDic()
        {
            collisionResolutionDic.Add(new Tuple<string, string>("Player", "Block"),
                Type.GetType("sprint0.PlayerBlockCollisionCommand"));
            collisionResolutionDic.Add(new Tuple<string, string>("Player", "Projectile"),
                Type.GetType("sprint0.PlayerProjectileCollisionCommand"));
            collisionResolutionDic.Add(new Tuple<string, string>("Player", "Item"),
                Type.GetType("sprint0.PlayerItemCollisionCommand"));
            collisionResolutionDic.Add(new Tuple<string, string>("Player", "Enemy"),
                Type.GetType("sprint0.PlayerEnemyCollisionCommand"));
            collisionResolutionDic.Add(new Tuple<string, string>("Enemy", "Enemy"),
                Type.GetType("sprint0.EnemyEnemyCollisionCommand"));
            collisionResolutionDic.Add(new Tuple<string, string>("Enemy", "Projectile"),
                Type.GetType("sprint0.EnemyProjectileCollisionCommand"));
            collisionResolutionDic.Add(new Tuple<string, string>("Enemy", "Block"),
                Type.GetType("sprint0.EnemyBlockCollisionCommand"));
            collisionResolutionDic.Add(new Tuple<string, string>("Projectile", "Block"),
                Type.GetType("sprint0.ProjectileBlockCollisionCommand"));
        }

        private void PopulateEnemyShooters()
        {
            setOfEnemyShooters.Add("Goriya");
            setOfEnemyShooters.Add("Octorok");
        }

        public void addProjectile(IProjectile projectile)
        {
            projectilesInFlight.Add(projectile);
        }

        public void removeProjectile(IProjectile projectile)
        {
            projectilesInFlight.Remove(projectile);
        }

        public void addEnemy(IEnemy enemy)
        {
            enemies.Add(enemy);
        }

        public void removeEnemy(IEnemy enemy)
        {
            enemies.Remove(enemy);
        }

        public void addBlock(IBlock block)
        {
            blocks.Add(block);
        }

        public void removeBlock(IBlock block)
        {
            blocks.Remove(block);
        }

        public void addItem(IItem item)
        {
            items.Add(item);
        }

        public void removeItem(IItem item)
        {
            items.Remove(item);
        }

        public void UpdatePlayerState()
        {
            if (player.Velocity == Vector2.Zero)
            {
                player.State = State.STANDING;
            }
        }

        public void UpdatePlayerSprite()
        {
            Vector2 velocity = player.Velocity;
            if (velocity.X == 0)
            {
                if (velocity.Y < 0)
                {
                    player.Direction = Direction.UP;
                }
                else if (velocity.Y > 0)
                {
                    player.Direction = Direction.DOWN;
                }
            }

            if (velocity.Y == 0)
            {
                if (velocity.X < 0)
                {
                    player.Direction = Direction.LEFT;
                }
                else if (velocity.X > 0)
                {
                    player.Direction = Direction.RIGHT;
                }
            }

            if (player.TakingDamage)
            {
                switch (player.State)
                {
                    case State.RUNNING:
                        switch (player.Direction)
                        {
                            case Direction.UP:
                                player.Sprite = SpriteFactory.Instance.LinkRunningUpDamaged(player.Position);
                                break;
                            case Direction.DOWN:
                                player.Sprite = SpriteFactory.Instance.LinkRunningDownDamaged(player.Position);
                                break;
                            case Direction.LEFT:
                                player.Sprite = SpriteFactory.Instance.LinkRunningLeftDamaged(player.Position);
                                break;
                            case Direction.RIGHT:
                                player.Sprite = SpriteFactory.Instance.LinkRunningRightDamaged(player.Position);
                                break;
                            default:
                                break;
                        }
                        break;
                    case State.STANDING:
                        switch (player.Direction)
                        {
                            case Direction.UP:
                                player.Sprite = SpriteFactory.Instance.LinkStandingUpDamaged(player.Position);
                                break;
                            case Direction.DOWN:
                                player.Sprite = SpriteFactory.Instance.LinkStandingDownDamaged(player.Position);
                                break;
                            case Direction.LEFT:
                                player.Sprite = SpriteFactory.Instance.LinkStandingLeftDamaged(player.Position);
                                break;
                            case Direction.RIGHT:
                                player.Sprite = SpriteFactory.Instance.LinkStandingRightDamaged(player.Position);
                                break;
                            default:
                                break;
                        }
                        break;
                    case State.ATTACKING:
                        switch (player.Direction)
                        {
                            case Direction.UP:
                                player.Sprite = SpriteFactory.Instance.LinkAttackingUpDamaged(player.Position);
                                break;
                            case Direction.DOWN:
                                player.Sprite = SpriteFactory.Instance.LinkAttackingDownDamaged(player.Position);
                                break;
                            case Direction.LEFT:
                                player.Sprite = SpriteFactory.Instance.LinkAttackingLeftDamaged(player.Position);
                                break;
                            case Direction.RIGHT:
                                player.Sprite = SpriteFactory.Instance.LinkAttackingRightDamaged(player.Position);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (player.State)
                {
                    case State.RUNNING:
                        switch (player.Direction)
                        {
                            case Direction.UP:
                                player.Sprite = SpriteFactory.Instance.LinkRunningUp(player.Position);
                                break;
                            case Direction.DOWN:
                                player.Sprite = SpriteFactory.Instance.LinkRunningDown(player.Position);
                                break;
                            case Direction.LEFT:
                                player.Sprite = SpriteFactory.Instance.LinkRunningLeft(player.Position);
                                break;
                            case Direction.RIGHT:
                                player.Sprite = SpriteFactory.Instance.LinkRunningRight(player.Position);
                                break;
                            default:
                                break;
                        }
                        break;
                    case State.STANDING:
                        switch (player.Direction)
                        {
                            case Direction.UP:
                                player.Sprite = SpriteFactory.Instance.LinkStandingUp(player.Position);
                                break;
                            case Direction.DOWN:
                                player.Sprite = SpriteFactory.Instance.LinkStandingDown(player.Position);
                                break;
                            case Direction.LEFT:
                                player.Sprite = SpriteFactory.Instance.LinkStandingLeft(player.Position);
                                break;
                            case Direction.RIGHT:
                                player.Sprite = SpriteFactory.Instance.LinkStandingRight(player.Position);
                                break;
                            default:
                                break;
                        }
                        break;
                    case State.ATTACKING:
                        switch (player.Direction)
                        {
                            case Direction.UP:
                                player.Sprite = SpriteFactory.Instance.LinkAttackingUp(player.Position);
                                break;
                            case Direction.DOWN:
                                player.Sprite = SpriteFactory.Instance.LinkAttackingDown(player.Position);
                                break;
                            case Direction.LEFT:
                                player.Sprite = SpriteFactory.Instance.LinkAttackingLeft(player.Position);
                                break;
                            case Direction.RIGHT:
                                player.Sprite = SpriteFactory.Instance.LinkAttackingRight(player.Position);
                                break;
                            default:
                                break;
                        }
                        break;
                    case State.THROWING:
                        switch (player.Direction)
                        {
                            case Direction.UP:
                                player.Sprite = SpriteFactory.Instance.LinkThrowingUp(player.Position);
                                break;
                            case Direction.DOWN:
                                player.Sprite = SpriteFactory.Instance.LinkThrowingDown(player.Position);
                                break;
                            case Direction.LEFT:
                                player.Sprite = SpriteFactory.Instance.LinkThrowingLeft(player.Position);
                                break;
                            case Direction.RIGHT:
                                player.Sprite = SpriteFactory.Instance.LinkThrowingRight(player.Position);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            player.Velocity = velocity;
        }

        /**
         * Add the object to the manager.
         * An object is not playable.
         */
        public void AddObject(object obj)
        {
            objectsToAdd.Add(obj);
        }

        public void AddPlayer(object player)
        {
            this.player = (IPlayer)player;
            AddObject(player);
        }

        public void RemoveObject(object obj)
        {
            objectsToRemove.Add(obj);
        }

        public void Update(GameTime gameTime)
        {
            // Ensure Link does not keep attacking, but only with each press
            if (player.State == State.ATTACKING || player.State == State.THROWING)
            {
                if (attackingRotation == 7) // TODO: 7 is a magic number (it just seems to produce the cleanest attack)
                {
                    player.State = State.STANDING;
                    UpdatePlayerSprite();
                    attackingRotation = 0;
                }
                attackingRotation++;
            }

            if (player.TakingDamage)
            {
                if (damageRotation > (300 * ((double)player.Damaged / 10))) // TODO: magic numbers
                {
                    player.TakingDamage = !player.TakingDamage;
                    UpdatePlayerSprite();
                    damageRotation = 0;
                }
                damageRotation++;
            }

            foreach (object obj in objectsToRemove)
            {
                if (obj is IDrawable)
                {
                    drawables.Remove((IDrawable)obj);
                }

                if (obj is IUpdateable)
                {
                    updateables.Remove((IUpdateable)obj);
                }

                if (obj is IProjectile)
                {
                    removeProjectile((IProjectile)obj);
                }

                if (obj is IEnemy)
                {
                    removeEnemy((IEnemy)obj);
                }

                if (obj is IItem)
                {
                    removeItem((IItem)obj);
                }

                if (obj is IBlock)
                {
                    removeBlock((IBlock)obj);
                }
            }

            objectsToRemove.Clear();

            foreach (object obj in objectsToAdd)
            {
                if (obj is IDrawable)
                {
                    drawables.Add((IDrawable)obj);
                }

                if (obj is IUpdateable)
                {
                    updateables.Add((IUpdateable)obj);
                }

                if (obj is IProjectile)
                {
                    addProjectile((IProjectile)obj);
                }

                if (obj is IBlock)
                {
                    addBlock((IBlock)obj);
                }

                if (obj is IItem)
                {
                    addItem((IItem)obj);
                }

                if (obj is IEnemy)
                {
                    addEnemy((IEnemy)obj);
                }
            }

            objectsToAdd.Clear();

            Projectile.UpdateProjectileMotion(gameTime, projectilesInFlight, this);
            Enemy.UpdateEnemyProjectiles(game, enemies);

            foreach (IUpdateable updateable in updateables)
            {
                updateable.Update(gameTime);
            }

            //Handling all different types of collision
            CollisionDetection.HandleAllCollidables(player, projectilesInFlight, enemies, blocks, items, shooterOfProjectile, this);
        }

        public void Draw(GameTime gameTime)
        {
            foreach (IDrawable drawable in drawables)
            {
                drawable.Draw(gameTime);
            }
        }
    }
}

