using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using System.Numerics;

namespace sprint0
{
    internal static class CollisionDetection
    {
        public static void HandleAllCollidables(IPlayer player, List<IProjectile> projectiles, List<IEnemy> enemies,
            List<IBlock> blocks, List<IItem> items, Dictionary<IProjectile, string> shooterOfProjectile, GameObjectManager manager)
        {
            IObject objectPlayer = (IObject)player;
            List<IObject> objectEnemies = new List<IObject>();
            foreach (IEnemy x in enemies) objectEnemies.Add((IObject)x);
            List<IObject> objectProjectiles = new List<IObject>();
            foreach (IProjectile x in projectiles) objectProjectiles.Add((IObject)x);
            List<IObject> objectBlocks = new List<IObject>();
            foreach (IBlock x in blocks) objectBlocks.Add((IObject)x);
            List<IObject> objectItems = new List<IObject>();
            foreach (IItem x in items) objectItems.Add((IObject)x);
            Dictionary<IObject, string> shooterOfProjectileObjects = new Dictionary<IObject, string>();
            foreach (KeyValuePair<IProjectile, string> entry in shooterOfProjectile) shooterOfProjectileObjects.Add((IObject)entry.Key, entry.Value);

            HandlePlayerAgainstProjectiles(objectPlayer, objectProjectiles, shooterOfProjectileObjects, manager);
            HandlePlayerAgainstEnemies(objectPlayer, objectEnemies, manager);
            HandlePlayerAgainstBlocks(objectPlayer, objectBlocks, manager);
            HandlePlayerAgainstItems(objectPlayer, objectItems, manager);
            HandleEnemiesAgainstProjectiles(objectEnemies, objectProjectiles, shooterOfProjectileObjects, manager);
            HandleEnemiesAgainstEnemies(objectEnemies, manager);
            HandleEnemiesAgainstBlocks(objectEnemies, objectBlocks, manager);
            HandleProjectilesAgainstBlocks(objectProjectiles, objectBlocks, manager);
        }

        private static void HandlePlayerAgainstProjectiles(IObject player, List<IObject> projectiles,
            Dictionary<IObject, string> shooterOfProjectile, GameObjectManager manager)
        {
            Rectangle playerRect = new Rectangle((int)player.Position.X,
                (int)player.Position.Y, player.Sprite.SourceRectangle[player.Sprite.Frame].Width,
                player.Sprite.SourceRectangle[player.Sprite.Frame].Height);
            for (int i = 0; i < projectiles.Count; i++)
            {
                IObject currProjectile = projectiles.ElementAt(i);
                if (shooterOfProjectile.GetValueOrDefault(currProjectile) == "player") continue;
                Rectangle projectileRect = new Rectangle((int)currProjectile.Position.X,
                (int)projectiles.ElementAt(i).Position.Y, currProjectile.Sprite.SourceRectangle[currProjectile.Sprite.Frame].Width,
                projectiles.ElementAt(i).Sprite.SourceRectangle[currProjectile.Sprite.Frame].Height);
                Rectangle intersect = Rectangle.Intersect(playerRect, projectileRect);
                if (!intersect.IsEmpty)
                {
                    CollisionResolution.CallCorrespondingCommand(player, currProjectile, manager, "");
                }
            }
        }

        private static void HandlePlayerAgainstEnemies(IObject player, List<IObject> enemies, GameObjectManager manager)
        {
            Rectangle playerRect = new Rectangle((int)player.Position.X,
                (int)player.Position.Y, player.Sprite.SourceRectangle[player.Sprite.Frame].Width,
                player.Sprite.SourceRectangle[player.Sprite.Frame].Height);
            for (int i = 0; i < enemies.Count; i++)
            {
                IObject currEnemy = enemies.ElementAt(i);
                Rectangle enemyRect = new Rectangle((int)currEnemy.Position.X,
                (int)currEnemy.Position.Y, currEnemy.Sprite.SourceRectangle[currEnemy.Sprite.Frame].Width,
                currEnemy.Sprite.SourceRectangle[currEnemy.Sprite.Frame].Height);
                Rectangle intersect = Rectangle.Intersect(playerRect, enemyRect);
                if (!intersect.IsEmpty)
                {
                    string intersectionLoc = GetIntersectionLocation(player.Sprite.SourceRectangle[player.Sprite.Frame], intersect);
                    CollisionResolution.CallCorrespondingCommand(player, currEnemy, manager, intersectionLoc);
                }
            }
        }

        private static void HandlePlayerAgainstBlocks(IObject player, List<IObject> blocks, GameObjectManager manager)
        {
            Rectangle playerRect = new Rectangle((int)player.Position.X,
                (int)player.Position.Y, player.Sprite.SourceRectangle[player.Sprite.Frame].Width / 2,
                player.Sprite.SourceRectangle[player.Sprite.Frame].Height);
            for (int i = 0; i < blocks.Count; i++)
            {
                IObject currBlock = blocks.ElementAt(i);
                Rectangle blockRect = new Rectangle((int)currBlock.Position.X,
                (int)currBlock.Position.Y, currBlock.Sprite.SourceRectangle[currBlock.Sprite.Frame].Width,
                currBlock.Sprite.SourceRectangle[currBlock.Sprite.Frame].Height);
                Rectangle intersect = Rectangle.Intersect(playerRect, blockRect);
                if (!intersect.IsEmpty)
                {
                    string intersectionLoc = GetIntersectionLocation(playerRect, intersect);
                    CollisionResolution.CallCorrespondingCommand(player, currBlock, manager, intersectionLoc);
                }
            }
        }

        private static void HandlePlayerAgainstItems(IObject player, List<IObject> items, GameObjectManager manager)
        {
            Rectangle playerRect = new Rectangle((int)player.Position.X,
                (int)player.Position.Y, player.Sprite.SourceRectangle[player.Sprite.Frame].Width,
                player.Sprite.SourceRectangle[player.Sprite.Frame].Height / 2);
            for (int i = 0; i < items.Count; i++)
            {
                IObject currItem = items.ElementAt(i);
                Rectangle itemRect = new Rectangle((int)currItem.Position.X, (int)currItem.Position.Y, 12, 12);
                Rectangle intersect = Rectangle.Intersect(playerRect, itemRect);
                if (!intersect.IsEmpty)
                {
                    CollisionResolution.CallCorrespondingCommand(player, currItem, manager, "");
                }
            }
        }

        private static void HandleEnemiesAgainstProjectiles(List<IObject> enemies, List<IObject> projectiles,
            Dictionary<IObject, string> shooterOfProjectile, GameObjectManager manager)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                IObject currEnemy = enemies.ElementAt(i);
                Rectangle enemyRect = new Rectangle((int)currEnemy.Position.X,
                    (int)currEnemy.Position.Y, currEnemy.Sprite.SourceRectangle[currEnemy.Sprite.Frame].Width,
                    currEnemy.Sprite.SourceRectangle[currEnemy.Sprite.Frame].Height);
                for (int j = 0; j < projectiles.Count; j++)
                {
                    IObject currProjectile = projectiles.ElementAt(j);
                    if (shooterOfProjectile.GetValueOrDefault(currProjectile) != "player") continue;
                    Rectangle projectileRect = new Rectangle((int)currProjectile.Position.X,
                    (int)currProjectile.Position.Y, currProjectile.Sprite.SourceRectangle[currProjectile.Sprite.Frame].Width,
                    currProjectile.Sprite.SourceRectangle[currProjectile.Sprite.Frame].Height);
                    Rectangle intersect = Rectangle.Intersect(enemyRect, projectileRect);
                    if (!intersect.IsEmpty)
                    {
                        CollisionResolution.CallCorrespondingCommand(currEnemy, currProjectile, manager, "");
                    }
                }
            }
        }

        private static void HandleEnemiesAgainstEnemies(List<IObject> enemies, GameObjectManager manager)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Rectangle enemyRect1 = new Rectangle((int)enemies.ElementAt(i).Position.X,
                    (int)enemies.ElementAt(i).Position.Y, enemies.ElementAt(i).Sprite.SourceRectangle[enemies.ElementAt(i).Sprite.Frame].Width,
                    enemies.ElementAt(i).Sprite.SourceRectangle[enemies.ElementAt(i).Sprite.Frame].Height);
                for (int j = i + 1; j < enemies.Count; j++)
                {
                    Rectangle enemyRect2 = new Rectangle((int)enemies.ElementAt(j).Position.X,
                    (int)enemies.ElementAt(j).Position.Y, enemies.ElementAt(j).Sprite.SourceRectangle[enemies.ElementAt(j).Sprite.Frame].Width,
                    enemies.ElementAt(j).Sprite.SourceRectangle[enemies.ElementAt(j).Sprite.Frame].Height);
                    Rectangle intersect = Rectangle.Intersect(enemyRect1, enemyRect2);
                    if (!intersect.IsEmpty)
                    {
                        string intersectionLoc = GetIntersectionLocation(enemyRect1, intersect);
                        CollisionResolution.CallCorrespondingCommand(enemies.ElementAt(i), enemies.ElementAt(j), manager, intersectionLoc);
                    }
                }
            }
        }

        private static void HandleEnemiesAgainstBlocks(List<IObject> enemies, List<IObject> blocks, GameObjectManager manager)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Rectangle enemyRect = new Rectangle((int)enemies.ElementAt(i).Position.X,
                    (int)enemies.ElementAt(i).Position.Y, enemies.ElementAt(i).Sprite.SourceRectangle[enemies.ElementAt(i).Sprite.Frame].Width,
                    enemies.ElementAt(i).Sprite.SourceRectangle[enemies.ElementAt(i).Sprite.Frame].Height);
                for (int j = 0; j < blocks.Count; j++)
                {
                    Rectangle blockRect = new Rectangle((int)blocks.ElementAt(j).Position.X,
                    (int)blocks.ElementAt(j).Position.Y, blocks.ElementAt(j).Sprite.SourceRectangle[blocks.ElementAt(j).Sprite.Frame].Width,
                    blocks.ElementAt(j).Sprite.SourceRectangle[blocks.ElementAt(j).Sprite.Frame].Height);
                    Rectangle intersect = Rectangle.Intersect(blockRect, enemyRect);
                    if (!intersect.IsEmpty)
                    {
                        string intersectionLoc = GetIntersectionLocation(enemyRect, intersect);
                        CollisionResolution.CallCorrespondingCommand(enemies.ElementAt(i), blocks.ElementAt(j), manager, intersectionLoc);
                    }
                }
            }
        }

        private static void HandleProjectilesAgainstBlocks(List<IObject> projectiles, List<IObject> blocks, GameObjectManager manager)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                Rectangle proejctileRect = new Rectangle((int)projectiles.ElementAt(i).Position.X,
                    (int)projectiles.ElementAt(i).Position.Y, projectiles.ElementAt(i).Sprite.SourceRectangle[projectiles.ElementAt(i).Sprite.Frame].Width,
                    projectiles.ElementAt(i).Sprite.SourceRectangle[projectiles.ElementAt(i).Sprite.Frame].Height);
                for (int j = 0; j < blocks.Count; j++)
                {
                    Rectangle blockRect = new Rectangle((int)blocks.ElementAt(j).Position.X,
                    (int)blocks.ElementAt(j).Position.Y, blocks.ElementAt(j).Sprite.SourceRectangle[blocks.ElementAt(j).Sprite.Frame].Width,
                    blocks.ElementAt(j).Sprite.SourceRectangle[blocks.ElementAt(j).Sprite.Frame].Height);
                    Rectangle intersect = Rectangle.Intersect(blockRect, proejctileRect);
                    if (!intersect.IsEmpty)
                    {
                        CollisionResolution.CallCorrespondingCommand(projectiles.ElementAt(i), blocks.ElementAt(j), manager, "");
                    }
                }
            }
        }

        private static string GetIntersectionLocation(Rectangle Moving, Rectangle intersect)
        {
            //if it returns left then the moving object collided with the left of the non moving object (or moving)
            if (intersect.Height > intersect.Width) //left-right collision
            {
                if (Moving.Right == intersect.Right)
                {
                    return "right";
                }
                return "left";
            }
            else
            {
                if (Moving.Top == intersect.Top)
                {
                    return "bottom";
                }
                return "top";
            }

        }
    }
}