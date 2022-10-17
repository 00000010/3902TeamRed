using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
//using System.Numerics;
using System.Diagnostics;

namespace sprint0
{
    public class GameObjectManager
    {
        private Game1 game;
        private IPlayer player;

        public List<IProjectile> projectilesInFlight = new List<IProjectile>();
        public List<IEnemy> enemies = new List<IEnemy>();
        public List<IBlock> blocks = new List<IBlock>();
        public List<IItem> items = new List<IItem>();
        public Dictionary<IProjectile, string> initDirectionOfFire = new Dictionary<IProjectile, string>();
        public Dictionary<IProjectile, string> shooterOfProjectile = new Dictionary<IProjectile, string>();
        public Dictionary<Tuple<Type, Type>, Type> collisionResolutionDic = new Dictionary<Tuple<Type, Type>, Type>();

        private List<object> objectsToAdd = new List<object>();
        private List<object> objectsToRemove = new List<object>();

        public GameObjectManager(Game1 game)
        {
            this.game = game;
            player = game.player;
            PopulateCollisionResolutionDic();
        }

        private void PopulateCollisionResolutionDic()
        {
            collisionResolutionDic.Add(new Tuple<Type, Type>(Type.GetType("sprint0.Enemy"), Type.GetType("sprint0.Block")),
                Type.GetType("sprint0.EnemyBlockCollisionCommand"));
            collisionResolutionDic.Add(new Tuple<Type, Type>(Type.GetType("sprint0.Enemy"), Type.GetType("sprint0.Enemy")),
                Type.GetType("sprint0.EnemyEnemyCollisionCommand"));
            collisionResolutionDic.Add(new Tuple<Type, Type>(Type.GetType("sprint0.Enemy"), Type.GetType("sprint0.Projectile")),
                Type.GetType("sprint0.EnemyProjectileCollisionCommand"));
            collisionResolutionDic.Add(new Tuple<Type, Type>(Type.GetType("sprint0.Player"), Type.GetType("sprint0.Block")),
                Type.GetType("sprint0.PlayerBlockCollisionCommand"));
            collisionResolutionDic.Add(new Tuple<Type, Type>(Type.GetType("sprint0.Player"), Type.GetType("sprint0.Enemy")),
                Type.GetType("sprint0.PlayerEnemyCollisionCommand"));
            collisionResolutionDic.Add(new Tuple<Type, Type>(Type.GetType("sprint0.Player"), Type.GetType("sprint0.Item")),
                Type.GetType("sprint0.PlayerItemCollisionCommand"));
            collisionResolutionDic.Add(new Tuple<Type, Type>(Type.GetType("sprint0.Player"),
                Type.GetType("sprint0.Projectile")), Type.GetType("PlayerProjectileCollisionCommand"));
            collisionResolutionDic.Add(new Tuple<Type, Type>(Type.GetType("sprint0.Projectile"), Type.GetType("sprint0.Block")),
                Type.GetType("sprint0.ProjectileBlockCollisionCommand"));
        }

        /*
         * Need to use this method for projectiles
         */
        //public void addProjectile(IProjectile projectile, string direction, string shooter)
        //{
        //    projectilesInFlight.Add(projectile);
        //    initDirectionOfFire.Add(projectile, direction);
        //    shooterOfProjectile.Add(projectile, shooter);
        //}

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
                    default:
                        break;
                }
            }
            player.Velocity = velocity;
        }


        public void AddObject(object obj)
        {
            objectsToAdd.Add(obj);
        }
        public void RemoveObject(object obj)
        {
            objectsToRemove.Add(obj);
        }

        public void Update(GameTime gameTime)
        {

            foreach (object obj in objectsToRemove)
            {
                if (obj is IDrawable)
                {
                    game.drawables.Remove((IDrawable)obj);
                }

                if (obj is IUpdateable)
                {
                    game.updateables.Remove((IUpdateable)obj);
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
                    game.drawables.Add((IDrawable)obj);
                }

                if (obj is IUpdateable)
                {
                    game.updateables.Add((IUpdateable)obj);
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

            /*
             * UpdateProjectileMotion(gameTime);
             */
            //Handling all different types of collision
            CollisionDetection.HandleAllCollidables(player, projectilesInFlight, enemies, blocks, items, shooterOfProjectile, this);

        }


        //public void UpdateProjectileMotion(GameTime gameTime)
        //{
        //    for (int i = 0; i < projectilesInFlight.Count; i++)
        //    {
        //        projectilesInFlight[i].Update(gameTime);
        //        //Issue is in ProjectileBackToShooter because it assumes shooter is enemy
        //        if (ProjectileOutOfBounds(projectilesInFlight[i]) || ProjectileBackToShooter(projectilesInFlight[i]))
        //        {
        //            game.currEnemy.projectileInMotion = false;
        //            i--;
        //        }
        //    }
        //}

        //private bool ProjectileOutOfBounds(ISprite projectile)
        //{
        //    if (projectile.Position.X > 800 || projectile.Position.X < 0 || projectile.Position.Y > 480 || projectile.Position.Y < 0)
        //    {
        //        removeProjectile(projectile);
        //        return true;
        //    }
        //    return false;
        //}

        //private bool ProjectileBackToShooter(ISprite projectile)
        //{
        //    //Ensures that nothing happens if shooter is player
        //    if (shooterOfProjectile.GetValueOrDefault(projectile).Equals("player"))
        //    {
        //        return HandleShootingProjectile(projectile, game.player);
        //    }
        //    return HandleShootingProjectile(projectile, game.currEnemy);
        //}

        //private bool HandleShootingProjectile(ISprite projectile, ISprite sprite)
        //{
        //    if (projectile is Projectile)
        //    {
        //        Projectile copyProj = (Projectile)projectile;
        //        if (copyProj.SourceRectangle != ProjectileRectangle.Boomerang) return false;
        //    }
        //    string initDirection = initDirectionOfFire.GetValueOrDefault(projectile);
        //    if (initDirection.Equals("right"))
        //    {
        //        return projectile.Position.X < sprite.Position.X;
        //    }
        //    else if (initDirection.Equals("left"))
        //    {
        //        return projectile.Position.X > sprite.Position.X;
        //    }
        //    else if (initDirection.Equals("up"))
        //    {
        //        return projectile.Position.Y > sprite.Position.Y;
        //    }
        //    return projectile.Position.Y < sprite.Position.Y;
        //}
    }
}

