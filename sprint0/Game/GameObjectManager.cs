using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;

namespace sprint0
{
    public class GameObjectManager
    {
        public Game1 game;
        public IPlayer player;
        public TypeOfProj LinkProjectile = TypeOfProj.ARROW;
        public Inventory inventory;

        public List<IUpdateable> updateables = new List<IUpdateable>();
        public List<IDrawable> drawables = new List<IDrawable>();

        public List<IProjectile> projectilesInFlight = new List<IProjectile>();
        public List<IEnemy> enemies = new List<IEnemy>();
        public List<IBlock> blocks = new List<IBlock>();
        public List<IDoor> doors = new List<IDoor>();
        public List<IItem> items = new List<IItem>();

        public Dictionary<IProjectile, IShooter> shooterOfProjectile = new Dictionary<IProjectile, IShooter>();
        public Dictionary<Tuple<string, string>, Type[]> collisionResolutionDic = new Dictionary<Tuple<string, string>, Type[]>();
        public HashSet<string> setOfEnemyShooters = new HashSet<string>();

        public List<object> objectsToAdd = new List<object>();
        public List<object> objectsToRemove = new List<object>();

        private int attackingRotation = 0;
        private int damageRotation = 0;

        public GameObjectManager(Game1 game)
        {
            this.game = game;
            inventory = InventoryFactory.Instance.TopHUD(game);
            PopulateCollisionResolutionDic();
            PopulateEnemyShooters();
            AddHud();
        }

        private void PopulateCollisionResolutionDic()
        {
            collisionResolutionDic.Add(new Tuple<string, string>("Player", "Block"),
                new Type[] { Type.GetType("sprint0.PlayerBlockCollisionCommand") });
            collisionResolutionDic.Add(new Tuple<string, string>("Player", "Door"),
                new Type[] { Type.GetType("sprint0.PlayerDoorCollisionCommand") });
            collisionResolutionDic.Add(new Tuple<string, string>("Player", "Projectile"),
                new Type[] { Type.GetType("sprint0.PlayerProjectileCollisionCommand") });
            collisionResolutionDic.Add(new Tuple<string, string>("Player", "Item"),
                new Type[] { Type.GetType("sprint0.PlayerItemCollisionCommand") });
            collisionResolutionDic.Add(new Tuple<string, string>("Player", "Enemy"),
                new Type[] { Type.GetType("sprint0.PlayerEnemyCollisionCommand"), Type.GetType("sprint0.EnemyPlayerCollisionCommand") });
            collisionResolutionDic.Add(new Tuple<string, string>("Enemy", "Enemy"),
                new Type[] { Type.GetType("sprint0.EnemyEnemyCollisionCommand") });
            collisionResolutionDic.Add(new Tuple<string, string>("Enemy", "Projectile"),
                new Type[] { Type.GetType("sprint0.EnemyProjectileCollisionCommand") });
            collisionResolutionDic.Add(new Tuple<string, string>("Enemy", "Block"),
                new Type[] { Type.GetType("sprint0.EnemyBlockCollisionCommand") });
            collisionResolutionDic.Add(new Tuple<string, string>("Projectile", "Block"),
                new Type[] { Type.GetType("sprint0.ProjectileBlockCollisionCommand") });
        }

        private void PopulateEnemyShooters()
        {
            setOfEnemyShooters.Add("Goriya");
            setOfEnemyShooters.Add("Octorok");
            setOfEnemyShooters.Add("Dragon");
        }

        // TODO: refactor so it's addThing(object o) and uses reflection to add to the correct list
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

        public void addDoor(IDoor door)
        {
            doors.Add(door);
        }

        public void removeDoor(IDoor door)
        {
            doors.Remove(door);
        }

        public void addItem(IItem item)
        {
            items.Add(item);
        }

        public void removeItem(IItem item)
        {
            items.Remove(item);
        }

        /**
         * Add the object to the manager.
         * An object is not playable.
         */
        public void AddObject(object obj)
        {
            objectsToAdd.Add(obj);
        }
        public void RemoveObject(object obj)
        {
            objectsToRemove.Add(obj);
        }

        public void RemoveFromRoom(object obj)
        {
            game.loader.RemoveFromCurrRoom(obj);
            //Sometimes drop hearts after killing enemies
            Random randomGen = new Random();
            int shouldDrop = randomGen.Next(0, 20);
            if (shouldDrop == 0 && obj is Enemy)
            {
                IEnemy enemy = (Enemy)obj;
                AddObject(ItemFactory.Instance.ZeldaHeart(enemy.Position));
            }
            //Sometimes drop coins
            if (shouldDrop == 1 && obj is Enemy)
            {
                IEnemy enemy = (Enemy)obj;
                AddObject(ItemFactory.Instance.ZeldaRupy(enemy.Position));
            }
        }

        public void AddPlayer(object player)
        {
            this.player = (IPlayer)player;
            AddObject(player);
        }

        public void RemovePlayer()
        {
            drawables.Remove(player);
            updateables.Remove(player);
            //Stop gameplay
            HandleSpecialDisplays.Instance.GameOver = true;
        }

        public void Update(GameTime gameTime)
        {
            // Ensure Link does not keep attacking, but only with each press
            if (player.State == State.ATTACKING || player.State == State.THROWING)
            {
                if (attackingRotation == 7) // TODO: 7 is a magic number (it just seems to produce the cleanest attack)
                {
                    player.State = State.STANDING;
                    player.UpdatePlayerSprite(this);
                    attackingRotation = 0;
                }
                attackingRotation++;
            }
            if (player.TakingDamage)
            {
                if (damageRotation > (300 * ((double)player.Damaged / 10))) // TODO: magic numbers
                {
                    player.TakingDamage = !player.TakingDamage;
                    player.UpdatePlayerSprite(this);
                    damageRotation = 0;
                }
                damageRotation++;
            }

            //Removes all objects in objectsToRemove and adds all objects in objectsToAdd
            RemoveAllObjects();
            AddAllObjects();

            Projectile.UpdateProjectileMotion(gameTime, projectilesInFlight, this);
            Enemy.UpdateEnemyProjectiles(game, enemies);

            foreach (IUpdateable updateable in updateables)
            {
                updateable.Update(gameTime);
            }

            //Handling all different types of collision
            CollisionDetection.HandleAllCollidables(player, projectilesInFlight, enemies, blocks, doors, items, shooterOfProjectile, this);
        }

        public void Draw(GameTime gameTime)
        {
            foreach (IDrawable drawable in drawables)
            {
                //if (drawable.ToString() != "sprint0.Link")
                //{
                    drawable.Draw(gameTime);
                //}
            }
        }

        public static string TypeToString(Type type)
        {
            return type.BaseType.Name;
        }

        public static bool IsDesiredObject(IObject desiredObj, string expectedName)
        {
            //Use reflection to get type of projectile and notify shooter to update if projectile is boomerang
            Type typeOfProj = desiredObj.GetType();
            string projTypeName = typeOfProj.Name;
            return projTypeName.Equals(expectedName);
        }

        private void RemoveAllObjects()
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

                if (obj is IDoor)
                {
                    removeDoor((IDoor)obj);
                }
            }

            objectsToRemove.Clear();
        }

        public void AddAllObjects()
        {
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

                if (obj is IDoor)
                {
                    addDoor((IDoor)obj);
                }
            }

            objectsToAdd.Clear();
        }

        public void SetVictory()
        {
            HandleSpecialDisplays.Instance.Victory = true;
        }

        private void AddHud()
        {
            drawables.Add(inventory);
            updateables.Add(inventory);
        }
    }
}

