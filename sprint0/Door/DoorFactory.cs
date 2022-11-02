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

        // TODO: add "bad" doors
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
}