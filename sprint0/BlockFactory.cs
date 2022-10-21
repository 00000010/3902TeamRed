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
        public Block GridSquare(Vector2 position)
        {
            return new GridSquare(position);
        }
        public Block SaveIconBlock(Vector2 position)
        {
            return new SaveIconBlock(position);
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

    internal class GridSquare : Block
    {
        public GridSquare(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.GridSquare(position);
        }
    }

    internal class SaveIconBlock : Block
    {
        public SaveIconBlock(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.SaveIconBlock(position);
        }
    }
}
