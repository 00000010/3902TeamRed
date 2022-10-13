using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Rectangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Factories
{
    internal class BlockFactory
    {
        private Texture2D GreenBlock;
        private Texture2D BlackBlock;
        private Texture2D PurpleBlock;

        private static BlockFactory instance = new BlockFactory();
        public static BlockFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private BlockFactory() { }
        public void LoadTextures(ContentManager content)
        {
            GreenBlock = content.Load<Texture2D>("ZeldaAltpBlock");
            BlackBlock = content.Load<Texture2D>("ZeldaLaBlock");
            PurpleBlock = content.Load<Texture2D>("ZeldaLadxBlock");
        }

        public List<Sprite> getAllBlocks(SpriteBatch _spriteBatch)
        {
            List<Sprite> blocks = new List<Sprite>();
            blocks.Add(BlockFactory.Instance.ZeldaBlack(_spriteBatch, new Vector2(400, 400)));
            blocks.Add(BlockFactory.Instance.ZeldaGreen(_spriteBatch, new Vector2(400, 400)));
            blocks.Add(BlockFactory.Instance.ZeldaPurple(_spriteBatch, new Vector2(400, 400)));
            return blocks;
        }

        public Block ZeldaGreen(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Block greenBlock = new Block(GreenBlock, BlockRectangle.NormalBlock, spriteBatch, position);
            if (manager != null)
            {
                manager.addBlock(greenBlock);
            }
            return greenBlock;
        }

        public Block ZeldaBlack(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Block blackBlock = new Block(BlackBlock, BlockRectangle.NormalBlock, spriteBatch, position);
            if (manager != null)
            {
                manager.addBlock(blackBlock);
            }
            return blackBlock;
        }

        public Block ZeldaPurple(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Block purpleBlock = new Block(PurpleBlock, BlockRectangle.NormalBlock, spriteBatch, position);
            if (manager != null)
            {
                manager.addBlock(purpleBlock);
            }
            return purpleBlock;
        }

    }

}
