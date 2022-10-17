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

        public IPlayer player;

        public List<Projectile> projectilesInFlight = new List<Projectile>();
        public Dictionary<ISprite, string> initDirectionOfFire = new Dictionary<ISprite, string>();
        public Dictionary<ISprite, string> shooterOfProjectile = new Dictionary<ISprite, string>();

        public List<IUpdateable> updateables = new List<IUpdateable>();
        public List<IDrawable> drawables = new List<IDrawable>();

        private List<object> objectsToAdd = new List<object>();
        private List<object> objectsToRemove = new List<object>();

        public GameObjectManager(Game1 game)
        {
            this.game = game;
            //player = game.player;
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

        /**
         * Add the object to the manager. If preference is set, the object will be drawn first. Preference should only be set for one object added (TODO: this is a bad restriction).
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

        //public void addProjectile(Projectile projectile, string direction, string shooter)
        //{
        //    projectilesInFlight.Add(projectile);
        //    initDirectionOfFire.Add(projectile, direction);
        //    shooterOfProjectile.Add(projectile, shooter);
        //}

        //public void removeProjectile(Projectile projectile)
        //{
        //    projectilesInFlight.Remove(projectile);
        //}

        //public void Draw(GameTime gameTime)
        //{
        //    foreach (Sprite projectile in projectilesInFlight)
        //    {
        //        projectile.Draw(gameTime);
        //    }
        //}

        public void Update(GameTime gameTime)
        {
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
            }
            objectsToAdd.Clear();

            foreach(IUpdateable updateable in updateables)
            {
                updateable.Update(gameTime);
            }
            //for (int i = 0; i < projectilesInFlight.Count; i++)
            //{
            //    projectilesInFlight[i].Update(gameTime);
            //    //Issue is in ProjectileBackToShooter because it assumes shooter is enemy
            //    if (ProjectileOutOfBounds(projectilesInFlight[i]) || ProjectileBackToShooter(projectilesInFlight[i]))
            //    {
            //        //game.currEnemy.projectileInMotion = false;
            //        i--;
            //    }
            //}
        }

        public void Draw(GameTime gameTime)
        {
            foreach (IDrawable drawable in drawables)
            {
                drawable.Draw(gameTime);
            }
        }

        //private bool ProjectileOutOfBounds(Projectile projectile)
        //{
        //    if (projectile.Position.X > 800 || projectile.Position.X < 0 || projectile.Position.Y > 480 || projectile.Position.Y < 0)
        //    {   
        //        removeProjectile(projectile);
        //        return true;
        //    }
        //    return false;
        //}

        //private bool ProjectileBackToShooter(Projectile projectile)
        //{
        //    //Ensures that nothing happens if shooter is player
        //    if (shooterOfProjectile.GetValueOrDefault(projectile).Equals("player"))
        //    {
        //        return HandleShootingProjectile(projectile, game.player);
        //    }
        //    //return HandleShootingProjectile(projectile, game.currEnemy);
        //    return false;
        //}

        //    private bool HandleShootingProjectile(Projectile projectile, IPlayer sprite)
        //    {
        //        if (projectile is Projectile)
        //        {
        //            Projectile copyProj = (Projectile)projectile;
        //            if (copyProj.SourceRectangle != ProjectileRectangle.Boomerang) return false;
        //        }
        //        string initDirection = initDirectionOfFire.GetValueOrDefault(projectile);
        //        if (initDirection.Equals("right"))
        //        {
        //            return projectile.Position.X < sprite.Position.X;
        //        }
        //        else if (initDirection.Equals("left"))
        //        {
        //            return projectile.Position.X > sprite.Position.X;
        //        }
        //        else if (initDirection.Equals("up"))
        //        {
        //            return projectile.Position.Y > sprite.Position.Y;
        //        }
        //        return projectile.Position.Y < sprite.Position.Y;
        //    }
    }
}

