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
        private SpriteFont smallerFont;

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

            smallerFont = content.Load<SpriteFont>("Zelda_font_smaller");
        }

        public void LoadZeldaTextures(ContentManager content)
        {

        }

        /*
         * Background
         */
        public TextSprite customGoldText(Vector2 position, string text)
        {
            return new TextSprite(spriteBatch, position, smallerFont, text, Color.Gold);
        }

        public TextSprite customBigText(Vector2 position, string text)
        {
            return new TextSprite(spriteBatch, position, smallerFont, text, Color.White);
        }

        public TextSprite CustomText(Vector2 position, string text)
        {
            return new TextSprite(spriteBatch, position, ZeldaFont, text, Color.White);
        }

        public TextSprite ItemText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, ZeldaFont, "", Color.White);
        }

        public TextSprite ItemTextSmaller(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, smallerFont, "", Color.White);
        }

        public TextSprite PauseText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, smallerFont, "PAUSE", Color.White);
        }

        public TextSprite ResumeText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, smallerFont, "RESUME", Color.White);
        }

        public TextSprite RestartText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, smallerFont, "RESTART", Color.White);
        }

        public TextSprite NextProjectileText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, smallerFont, "NEXT PROJ", Color.White);
        }

        public TextSprite PrevProjectileText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, smallerFont, "PREV PROJ", Color.White);
        }

        public TextSprite UpText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, smallerFont, "UP", Color.White);
        }

        public TextSprite DownText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, smallerFont, "DOWN", Color.White);
        }

        public TextSprite LeftText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, smallerFont, "LEFT", Color.White);
        }
        public TextSprite RightText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, smallerFont, "RIGHT", Color.White);
        }

        public TextSprite ShootProjectileText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, smallerFont, "SHOOT", Color.White);
        }

        public TextSprite SwordText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, smallerFont, "SWORD", Color.White);
        }

        public TextSprite ExitText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, smallerFont, "EXIT", Color.White);
        }

        public TextSprite ShowInventoryText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, smallerFont, "SHOW INV", Color.White);
        }

        public TextSprite HideInventoryText(Vector2 position)
        {
            return new TextSprite(spriteBatch, position, smallerFont, "HIDE INV", Color.White);
        }
    }
}
