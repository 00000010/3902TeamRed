using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static sprint0.SpriteRectangle;

namespace sprint0
{
    /// <summary>
    /// Class <c>TextSpriteFactory</c> is a place to save all the different text sprites that we have
    /// </summary>
    public class TextSpriteFactory
    {

        private SpriteFont ZeldaFont;

        private SpriteBatch spriteBatch;

        private static TextSpriteFactory instance = new TextSpriteFactory();
        public static TextSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private TextSpriteFactory() { }

        // Load the sprite sheets.
        public void LoadTextures(ContentManager content, SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;

            ZeldaFont = content.Load<SpriteFont>("galleryFont");
        }

        public void LoadZeldaTextures(ContentManager content)
        {

        }

        /*
         * Background
         */
        public TextSprite ItemText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, ZeldaFont, "", Color.White);
        }

    }
}
