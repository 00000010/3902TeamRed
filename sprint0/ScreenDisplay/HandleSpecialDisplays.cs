using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mime;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Metadata;

namespace sprint0
{
    internal class HandleSpecialDisplays
    {

        private SpriteFont mainFont, smallerFont;
        private SpriteBatch _spriteBatch;
        private Game1 game;

        public bool Paused { get; set; }
        public bool GameOver { get; set; }
        public bool Victory { get; set; }
        public bool Room10 { get; set; }

        private static HandleSpecialDisplays instance = new HandleSpecialDisplays();
        public static HandleSpecialDisplays Instance
        {
            get
            {
                return instance;
            }
        }

        private HandleSpecialDisplays() { }

        public void Initialize(Game1 game)
        {
            this.game = game;
            Paused = false;
            GameOver = false;
            Victory = false;
            Room10 = false;
        }

        public void LoadDisplays(ContentManager Content, SpriteBatch _spriteBatch)
        {
            mainFont = Content.Load<SpriteFont>("Zelda_font");
            smallerFont = Content.Load<SpriteFont>("Zelda_font_smaller");
            this._spriteBatch = _spriteBatch;
        }

        public bool HandleSpecialUpdates(GameTime gameTime)
        {
            if (GameOver)
            {
                HandleGameOver();
                return true;
            }
            else if (Paused)
            {
                HandleGamePaused();
                return true;
            }
            else if (Victory)
            {
                HandleGameVictory();
                return true;
            }
            return false;
        }

        public void HandleSpecialDrawings()
        {
            if (GameOver)
            {
                instance._spriteBatch.DrawString(instance.mainFont, "Game Over", new Vector2(270, 220), Color.White);
                instance._spriteBatch.DrawString(instance.smallerFont, "Press R to Restart", new Vector2(270, 270), Color.White);
            }
            else if (Paused)
            {
                instance._spriteBatch.DrawString(instance.mainFont, "Paused", new Vector2(330, 220), Color.White);
                instance._spriteBatch.DrawString(instance.smallerFont, "Press U to Resume", new Vector2(280, 270), Color.White);
            }
            else if (Victory)
            {
                instance._spriteBatch.DrawString(instance.mainFont, "Victory!", new Vector2(330, 220), Color.White);
                instance._spriteBatch.DrawString(instance.smallerFont, "Press R to Restart", new Vector2(280, 270), Color.White);
            }
            else if (Room10)
            {
                instance._spriteBatch.DrawString(instance.smallerFont, "EASTMOST PENINSULA", new Vector2(270, 190), Color.White);
                instance._spriteBatch.DrawString(instance.smallerFont, "IS THE SECRET.", new Vector2(300, 220), Color.White);
            }
        }

        private static void HandleGameOver()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            //Restart
            if (pressedKeys.Contains(Keys.R))
            {
                instance.game.RestartGame();
            }
        }

        private static void HandleGamePaused()
        {
            //Resume
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            if (pressedKeys.Contains(Keys.U))
            {
                Instance.Paused = false;
            }
        }

        private static void HandleGameVictory()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            //Restart
            if (pressedKeys.Contains(Keys.R))
            {
                instance.game.RestartGame();
            }
        }
    }
}
