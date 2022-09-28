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

        public Sprite ZeldaGreen(SpriteBatch spriteBatch, Vector2 position)
        {
            return new Sprite(GreenBlock, BlockRectangle.NormalBlock, spriteBatch, position);
        }

        public Sprite ZeldaBlack(SpriteBatch spriteBatch, Vector2 position)
        {
            return new Sprite(BlackBlock, BlockRectangle.NormalBlock, spriteBatch, position);
        }

        public Sprite ZeldaPurple(SpriteBatch spriteBatch, Vector2 position)
        {
            return new Sprite(PurpleBlock, BlockRectangle.NormalBlock, spriteBatch, position);
        }

    }

}
