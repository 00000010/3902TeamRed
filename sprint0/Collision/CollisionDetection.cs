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
using System.Runtime.CompilerServices;

namespace sprint0
{
    internal static class CollisionDetection
    {
        public static void HandleAllCollidables(IPlayer player, List<IProjectile> projectiles, List<IEnemy> enemies,
            List<IBlock> blocks, List<IItem> items, Dictionary<IProjectile, IShooter> shooterOfProjectile, GameObjectManager manager)
        {
            IObject objectPlayer = (IObject)player;

            List<IObject> objectEnemies = new List<IObject>();
            foreach (IEnemy x in enemies) objectEnemies.Add((IObject)x);
            List<IObject> objectProjectiles = new List<IObject>();
            foreach (IProjectile x in projectiles) objectProjectiles.Add((IObject)x);
            List<IObject> objectBlocks = new List<IObject>();
            foreach (IBlock x in blocks) objectBlocks.Add((IObject)x);
            List<IObject> objectDoors = new List<IObject>();
            foreach (IDoor x in doors) objectDoors.Add((IObject)x);
            List<IObject> objectItems = new List<IObject>();
            foreach (IItem x in items) objectItems.Add((IObject)x);
            Dictionary<IObject, IShooter> shooterOfProjectileObjects = new Dictionary<IObject, IShooter>();
            foreach (KeyValuePair<IProjectile, IShooter> entry in shooterOfProjectile) shooterOfProjectileObjects.Add((IObject)entry.Key, entry.Value);

            HandlePlayerCollisions(objectPlayer, objectProjectiles, shooterOfProjectileObjects, manager);
            HandlePlayerCollisions(objectPlayer, objectEnemies, shooterOfProjectileObjects, manager);
            HandlePlayerCollisions(objectPlayer, objectItems, shooterOfProjectileObjects, manager);
            HandlePlayerCollisions(objectPlayer, objectBlocks, shooterOfProjectileObjects, manager);
            HandleGeneralCollisions(objectEnemies, objectProjectiles, shooterOfProjectileObjects, manager);
            HandleGeneralCollisions(objectEnemies, objectEnemies, shooterOfProjectileObjects, manager);
            HandleGeneralCollisions(objectEnemies, objectBlocks, shooterOfProjectileObjects, manager);
            HandleGeneralCollisions(objectProjectiles, objectBlocks, shooterOfProjectileObjects, manager);
        }

        private static void HandlePlayerCollisions(IObject player, List<IObject> otherObjects,
            Dictionary<IObject, IShooter> shooterOfProjectile, GameObjectManager manager)
        {
            int offset = 24;
            Rectangle playerRect = new Rectangle((int)player.Position.X + offset,
                (int)player.Position.Y + offset, player.Sprite.DestinationRectangle.Width - (offset * 2),
                player.Sprite.DestinationRectangle.Height - (offset * 2));
            HandleInnerLoop(player, playerRect, otherObjects, shooterOfProjectile, manager, "Player");
        }

        private static void HandleGeneralCollisions(List<IObject> objects1, List<IObject> objects2,
            Dictionary<IObject, IShooter> shooterOfProjectile, GameObjectManager manager)
        {
            for (int i = 0; i < objects1.Count; i++)
            {
                IObject object1 = objects1.ElementAt(i);
                Rectangle object1Rect = new Rectangle((int)object1.Position.X,
                    (int)object1.Position.Y, object1.Sprite.DestinationRectangle.Width,
                    object1.Sprite.DestinationRectangle.Height);
                HandleInnerLoop(object1, object1Rect, objects2, shooterOfProjectile, manager, "Enemy");
            }
        }

        public static void HandleInnerLoop(IObject object1, Rectangle object1Rect, List<IObject> otherObjects,
            Dictionary<IObject, IShooter> shooterOfProjectile, GameObjectManager manager, string expectedShooter)
        {
            for (int i = 0; i < otherObjects.Count; i++)
            {
                IObject currObject = otherObjects.ElementAt(i);
                if ((currObject is Projectile) && shooterOfProjectile.GetValueOrDefault(currObject).TypeOfObject == expectedShooter) continue;
                Rectangle objectRect = new Rectangle((int)currObject.Position.X,
                (int)otherObjects.ElementAt(i).Position.Y, currObject.Sprite.DestinationRectangle.Width,
                otherObjects.ElementAt(i).Sprite.DestinationRectangle.Height);
                Rectangle intersect = Rectangle.Intersect(object1Rect, objectRect);
                if (!intersect.IsEmpty)
                {
                    string intersectionLoc = GetIntersectionLocation(object1Rect, intersect);
                    CollisionResolution.CallCorrespondingCommand(object1, currObject, manager, intersectionLoc);
                }
            }
        } 

        private static string GetIntersectionLocation(Rectangle Moving, Rectangle intersect)
        {
            //Left-Right
            string collisionDirections = "";
            if (intersect.Height >= intersect.Width) //equal is important since if we approach it from a corner then you might have a case where width=height
            {
                if (Moving.Right == intersect.Right)
                {
                    collisionDirections += "left";  //Moving collides with left of non moving (or moving)
                }
                else
                {
                    collisionDirections += "right";
                }
            }
            //Top-Bottom
            if (intersect.Height <= intersect.Width) 
            {
                if (Moving.Top == intersect.Top)
                {
                    collisionDirections += "bottom";
                }
                else
                {
                    collisionDirections += "top";
                }
            }

            return collisionDirections;
        }

        //private static void HandlePlayerAgainstWalls(IObject player, IObject background, GameObjectManager manager)
        //{
            //int offset = 12;
            //Rectangle playerRect = new Rectangle((int)player.Position.X + offset,
            //    (int)player.Position.Y + offset, player.Sprite.SourceRectangle[player.Sprite.Frame].Width - (offset * 2),
            //    player.Sprite.SourceRectangle[player.Sprite.Frame].Height - (offset * 2));
            //Rectangle[] wallRects = GetWallRects(background);
            //foreach (Rectangle wall in wallRects)
            //{
            //    Rectangle intersect = Rectangle.Intersect(playerRect, wall);
            //    if (!intersect.IsEmpty)
            //    {
            //        CollisionResolution.CallCorrespondingCommand(player, wall, manager, "");
            //    }
            //}
        //}

        //private static Rectangle[] GetWallRects(IObject background)
        //{
        //    // TODO: code smell; lots of dots
        //    // TODO: magic numbers
        //    Rectangle[] wallRects = {
        //        new Rectangle((int)background.Position.X, (int)background.Position.Y, background.Sprite.SourceRectangle[0].Width, background.Sprite.SourceRectangle[0].Height * (18/99)),
        //        new Rectangle((int)background.Position.X, (int)background.Position.Y + background.Sprite.SourceRectangle[0].Height - (18/99), background.Sprite.SourceRectangle[0].Width, background.Sprite.SourceRectangle[0].Height * (18/99)),
        //        new Rectangle((int)background.Position.X, (int)background.Position.Y, background.Sprite.SourceRectangle[0].Height, background.Sprite.SourceRectangle[0].Width * (18/99)),
        //        new Rectangle((int)background.Position.X + background.Sprite.SourceRectangle[0].Width * (81/99), (int)background.Position.Y, background.Sprite.SourceRectangle[0].Width * (18/99), background.Sprite.SourceRectangle[0].Height)
        //        };
        //    return wallRects;
        //}
    }
}
