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
    internal class BlockFactory
    {
        private static BlockFactory instance = new BlockFactory();
        public static BlockFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private BlockFactory() { }

        public Block ZeldaGreenBlock(Vector2 position)
        {
            return new ZeldaGreenBlock(position);
        }

        public Block ZeldaBlackBlock(Vector2 position)
        {
            return new ZeldaBlackBlock(position);
        }

        public Block ZeldaPurpleBlock(Vector2 position)
        {
            return new ZeldaPurpleBlock(position);
        }

        public Block DungeonBlock(Vector2 position)
        {
            return new DungeonBlock(position);
        }

        public Block DungeonNorthWall(Vector2 position)
        {
            return new DungeonNorthWall(position);
        }

        public Block DungeonSouthWall(Vector2 position)
        {
            return new DungeonSouthWall(position);
        }

        public Block DungeonEastWall(Vector2 position)
        {
            return new DungeonEastWall(position);
        }

        public Block DungeonWestWall(Vector2 position)
        {
            return new DungeonWestWall(position);
        }

        public Block WaterBlock(Vector2 position)
        {
            return new WaterBlock(position);
        }

        public Block DungeonMonster1(Vector2 position)
        {
            return new DungeonMonster1(position);
        }

        public Block DungeonMonster2(Vector2 position)
        {
            return new DungeonMonster2(position);
        }

        public Block DungeonMonster1Faded(Vector2 position)
        {
            return new DungeonMonster1Faded(position);
        }

        public Block DungeonMonster2Faded(Vector2 position)
        {
            return new DungeonMonster2Faded(position);
        }

        public Block ZeldaOldMan(Vector2 position)
        {
            return new ZeldaOldMan(position);
        }
    }

    internal class ZeldaGreenBlock : Block
    {
        public ZeldaGreenBlock(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaGreen(position);
        }
    }

    internal class ZeldaBlackBlock : Block
    {
        public ZeldaBlackBlock(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaBlack(position);
        }
    }

    internal class ZeldaPurpleBlock : Block
    {
        public ZeldaPurpleBlock(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaPurple(position);
        }
    }

    internal class DungeonBlock : Block
    {
        public DungeonBlock(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonBlock(position);
        }
    }

    internal class DungeonNorthWall : Block
    {
        public DungeonNorthWall(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonNorthWall(position);
        }
    }

    internal class DungeonSouthWall : Block
    {
        public DungeonSouthWall(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonSouthWall(position);
        }
    }

    internal class DungeonEastWall : Block
    {
        public DungeonEastWall(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonEastWall(position);
        }
    }

    internal class DungeonWestWall : Block
    {
        public DungeonWestWall(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonWestWall(position);
        }
    }

    internal class WaterBlock : Block
    {
        public WaterBlock(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.WaterBlock(position);
        }
    }

    internal class DungeonMonster1 : Block
    {
        public DungeonMonster1(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonMonster1(position);
        }
    }

    internal class DungeonMonster2 : Block
    {
        public DungeonMonster2(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonMonster2(position);
        }
    }

    internal class DungeonMonster1Faded : Block
    {
        public DungeonMonster1Faded(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonMonster1Faded(position);
        }
    }

    internal class DungeonMonster2Faded : Block
    {
        public DungeonMonster2Faded(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.DungeonMonster2Faded(position);
        }
    }

    internal class ZeldaOldMan : Block
    {
        public ZeldaOldMan(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaOldMan(position);
        }
    }
}