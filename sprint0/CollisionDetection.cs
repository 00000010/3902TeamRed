using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Rectangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;
using System.Numerics;

namespace sprint0
{
    internal static class CollisionDetection
    {
        public static void HandleAllCollidables(ISprite player, List<ISprite> projectiles, List<ISprite> enemies,
            List<ISprite> blocks, List<ISprite> items, Dictionary<ISprite, string> shooterOfProjectile, GameObjectManager manager)
        {
            HandlePlayerAgainstProjectiles(player, projectiles, shooterOfProjectile, manager);
            HandlePlayerAgainstEnemies(player, enemies);
            HandlePlayerAgainstBlocks(player, blocks);
            HandlePlayerAgainstItems(player, items);
            HandleEnemiesAgainstProjectiles(enemies, projectiles, shooterOfProjectile, manager);
            HandleEnemiesAgainstEnemies(enemies);
            HandleEnemiesAgainstBlocks(enemies, blocks);
            HandleProjectilesAgainstBlocks(projectiles, blocks, manager);
        }

        private static void HandlePlayerAgainstProjectiles(ISprite player, List<ISprite> projectiles,
            Dictionary<ISprite, string> shooterOfProjectile, GameObjectManager manager)
        {
            Rectangle playerRect = new Rectangle((int)player.Position.X,
                (int)player.Position.Y, player.SourceRectangle[0].Width / 2,
                player.SourceRectangle[0].Height / 2);
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (shooterOfProjectile.GetValueOrDefault(projectiles.ElementAt(i)) == "player") continue;
                Rectangle projectileRect = new Rectangle((int)projectiles.ElementAt(i).Position.X,
                (int)projectiles.ElementAt(i).Position.Y, projectiles.ElementAt(i).SourceRectangle[0].Width,
                projectiles.ElementAt(i).SourceRectangle[0].Height);
                Rectangle intersect = Rectangle.Intersect(playerRect, projectileRect);
                if (!intersect.IsEmpty)
                {
                    CollisionResolution.PlayerAgainstProjectile(player, projectiles.ElementAt(i), manager);
                }
            }
        }

        private static void HandlePlayerAgainstEnemies(ISprite player, List<ISprite> enemies)
        {
            Rectangle playerRect = new Rectangle((int)player.Position.X,
                (int)player.Position.Y, player.SourceRectangle[0].Width / 2,
                player.SourceRectangle[0].Height / 2);
            for (int i = 0; i < enemies.Count; i++)
            {
                Rectangle enemyRect = new Rectangle((int)enemies.ElementAt(i).Position.X,
                (int)enemies.ElementAt(i).Position.Y, enemies.ElementAt(i).SourceRectangle[0].Width,
                enemies.ElementAt(i).SourceRectangle[0].Height);
                Rectangle intersect = Rectangle.Intersect(playerRect, enemyRect);
                if (!intersect.IsEmpty)
                {
                    string intersectionLoc = GetIntersectionLocation(player.SourceRectangle[0], intersect);
                    CollisionResolution.PlayerAgainstEnemy(player, enemies.ElementAt(i), intersectionLoc);
                }
            }
        }

        private static void HandlePlayerAgainstBlocks(ISprite player, List<ISprite> blocks)
        {
            Rectangle playerRect = new Rectangle((int)player.Position.X,
                (int)player.Position.Y, player.SourceRectangle[0].Width / 2,
                player.SourceRectangle[0].Height / 2);
            for (int i = 0; i < blocks.Count; i++)
            {
                Rectangle blockRect = new Rectangle((int)blocks.ElementAt(i).Position.X,
                (int)blocks.ElementAt(i).Position.Y, blocks.ElementAt(i).SourceRectangle[0].Width,
                blocks.ElementAt(i).SourceRectangle[0].Height);
                Rectangle intersect = Rectangle.Intersect(playerRect, blockRect);
                if (!intersect.IsEmpty)
                {
                    string intersectionLoc = GetIntersectionLocation(playerRect, intersect);
                    CollisionResolution.PlayerAgainstBlock(player, blocks.ElementAt(i), intersectionLoc);
                }
            }
        }

        private static void HandlePlayerAgainstItems(ISprite player, List<ISprite> items)
        {
            Rectangle playerRect = new Rectangle((int)player.Position.X,
                (int)player.Position.Y, player.SourceRectangle[0].Width / 2,
                player.SourceRectangle[0].Height / 2);
            for (int i = 0; i < items.Count; i++)
            {
                Rectangle itemRect = new Rectangle((int)items.ElementAt(i).Position.X,
                (int)items.ElementAt(i).Position.Y, 12, 12);
                Rectangle intersect = Rectangle.Intersect(playerRect, itemRect);
                if (!intersect.IsEmpty)
                {
                    CollisionResolution.PlayerAgainstItem(player, items.ElementAt(i));
                }
            }
        }

        private static void HandleEnemiesAgainstProjectiles(List<ISprite> enemies, List<ISprite> projectiles,
            Dictionary<ISprite, string> shooterOfProjectile, GameObjectManager manager)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Rectangle enemyRect = new Rectangle((int)enemies.ElementAt(i).Position.X,
                    (int)enemies.ElementAt(i).Position.Y, enemies.ElementAt(i).SourceRectangle[0].Width,
                    enemies.ElementAt(i).SourceRectangle[0].Height);
                for (int j = 0; j < projectiles.Count; j++)
                {
                    if (shooterOfProjectile.GetValueOrDefault(projectiles.ElementAt(j)) != "player") continue;
                    Rectangle projectileRect = new Rectangle((int)projectiles.ElementAt(j).Position.X,
                    (int)projectiles.ElementAt(j).Position.Y, projectiles.ElementAt(j).SourceRectangle[0].Width,
                    projectiles.ElementAt(j).SourceRectangle[0].Height);
                    Rectangle intersect = Rectangle.Intersect(enemyRect, projectileRect);
                    if (!intersect.IsEmpty)
                    {
                        CollisionResolution.EnemyAgainstProjectile(enemies.ElementAt(i), projectiles.ElementAt(j), manager);
                    }
                }
            }
        }

        private static void HandleEnemiesAgainstEnemies(List<ISprite> enemies)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Rectangle enemyRect1 = new Rectangle((int)enemies.ElementAt(i).Position.X,
                    (int)enemies.ElementAt(i).Position.Y, enemies.ElementAt(i).SourceRectangle[0].Width,
                    enemies.ElementAt(i).SourceRectangle[0].Height);
                for (int j = i + 1; j < enemies.Count; j++)
                {
                    Rectangle enemyRect2 = new Rectangle((int)enemies.ElementAt(j).Position.X,
                    (int)enemies.ElementAt(j).Position.Y, enemies.ElementAt(j).SourceRectangle[0].Width,
                    enemies.ElementAt(j).SourceRectangle[0].Height);
                    Rectangle intersect = Rectangle.Intersect(enemyRect1, enemyRect2);
                    if (!intersect.IsEmpty)
                    {
                        string intersectionLoc = GetIntersectionLocation(enemyRect1, intersect);
                        CollisionResolution.EnemyAgainstEnemy(enemies.ElementAt(i), enemies.ElementAt(j), intersectionLoc);
                    }
                }
            }
        }

        private static void HandleEnemiesAgainstBlocks(List<ISprite> enemies, List<ISprite> blocks)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Rectangle enemyRect = new Rectangle((int)enemies.ElementAt(i).Position.X,
                    (int)enemies.ElementAt(i).Position.Y, enemies.ElementAt(i).SourceRectangle[0].Width,
                    enemies.ElementAt(i).SourceRectangle[0].Height);
                for (int j = 0; j < blocks.Count; j++)
                {
                    Rectangle blockRect = new Rectangle((int)blocks.ElementAt(j).Position.X,
                    (int)blocks.ElementAt(j).Position.Y, blocks.ElementAt(j).SourceRectangle[0].Width,
                    blocks.ElementAt(j).SourceRectangle[0].Height);
                    Rectangle intersect = Rectangle.Intersect(blockRect, enemyRect);
                    if (!intersect.IsEmpty)
                    {
                        string intersectionLoc = GetIntersectionLocation(enemyRect, intersect);
                        CollisionResolution.EnemyAgainstBlock(enemies.ElementAt(i), blocks.ElementAt(j), intersectionLoc);
                    }
                }
            }
        }

        private static void HandleProjectilesAgainstBlocks(List<ISprite> projectiles, List<ISprite> blocks, GameObjectManager manager)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                Rectangle proejctileRect = new Rectangle((int)projectiles.ElementAt(i).Position.X,
                    (int)projectiles.ElementAt(i).Position.Y, projectiles.ElementAt(i).SourceRectangle[0].Width,
                    projectiles.ElementAt(i).SourceRectangle[0].Height);
                for (int j = 0; j < blocks.Count; j++)
                {
                    Rectangle blockRect = new Rectangle((int)blocks.ElementAt(j).Position.X,
                    (int)blocks.ElementAt(j).Position.Y, blocks.ElementAt(j).SourceRectangle[0].Width,
                    blocks.ElementAt(j).SourceRectangle[0].Height);
                    Rectangle intersect = Rectangle.Intersect(blockRect, proejctileRect);
                    if (!intersect.IsEmpty)
                    {
                        CollisionResolution.ProjectileAgainstBlock(projectiles.ElementAt(i), blocks.ElementAt(j), manager);
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
