using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    internal class DoorFactory
    {
        private static DoorFactory instance = new DoorFactory();
        public static DoorFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private DoorFactory() { }

        public Door DungeonDoorNorth(Vector2 position)
        {
            return new DungeonDoorNorth(position);
        }

        public Door DungeonDoorSouth(Vector2 position)
        {
            return new DungeonDoorSouth(position);
        }

        public Door DungeonDoorEast(Vector2 position)
        {
            return new DungeonDoorEast(position);
        }

        public Door DungeonDoorWest(Vector2 position)
        {
            return new DungeonDoorWest(position);
        }

        public Door DungeonBadDoorNorth(Vector2 position)
        {
            return new DungeonBadDoorNorth(position);
        }

        public Door DungeonBadDoorSouth(Vector2 position)
        {
            return new DungeonBadDoorSouth(position);
        }
    }

    internal class DungeonDoorNorth : Door
    {
        public DungeonDoorNorth(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonDoorNorth(position);
        }
    }

    internal class DungeonDoorSouth : Door
    {
        public DungeonDoorSouth(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonDoorSouth(position);
        }
    }

    internal class DungeonDoorEast : Door
    {
        public DungeonDoorEast(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonDoorEast(position);
        }
    }

    internal class DungeonDoorWest : Door
    {
        public DungeonDoorWest(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonDoorWest(position);
        }
    }

    internal class DungeonBadDoorNorth : Door
    {
        public DungeonBadDoorNorth(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonBadDoorNorth(position);
        }
    }

    internal class DungeonBadDoorSouth : Door
    {
        public DungeonBadDoorSouth(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonBadDoorSouth(position);
        }
    }
}