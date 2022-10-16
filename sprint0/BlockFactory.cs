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
    internal class BlockFactory : ObjectFactory
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
}
