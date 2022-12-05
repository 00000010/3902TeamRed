using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mime;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Metadata;
using System.Diagnostics;
using System.Runtime.InteropServices;

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
        public bool TitleScreen { get; set; }
        public bool LevelSelectScreen { get; set; }
        public bool LevelCreatorScreen { get; set; }
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
            TitleScreen = false;
            LevelSelectScreen = false;
            LevelCreatorScreen = false;
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
                instance._spriteBatch.DrawString(instance.mainFont, "Game Over", new Vector2(270, 220), Color.White, rotation: 0, origin: Vector2.Zero, scale:1, effects: SpriteEffects.None, Constants.TEXT_LAYER_DEPTH);
                instance._spriteBatch.DrawString(instance.smallerFont, "Press R to Restart", new Vector2(270, 270), Color.White, rotation: 0, origin: Vector2.Zero, scale: 1, effects: SpriteEffects.None, Constants.TEXT_LAYER_DEPTH);
            }
            else if (Paused)
            {
                instance._spriteBatch.DrawString(instance.mainFont, "Paused", new Vector2(330, 220), Color.White, rotation: 0, origin: Vector2.Zero, scale: 1, effects: SpriteEffects.None, Constants.TEXT_LAYER_DEPTH);
                instance._spriteBatch.DrawString(instance.smallerFont, "Press U to Resume", new Vector2(280, 270), Color.White, rotation: 0, origin: Vector2.Zero, scale: 1, effects: SpriteEffects.None, Constants.TEXT_LAYER_DEPTH);
            }
            else if (Victory)
            {
                instance._spriteBatch.DrawString(instance.mainFont, "Victory!", new Vector2(330, 220), Color.White, rotation: 0, origin: Vector2.Zero, scale: 1, effects: SpriteEffects.None, Constants.TEXT_LAYER_DEPTH);
                instance._spriteBatch.DrawString(instance.smallerFont, "Press R to Restart", new Vector2(280, 270), Color.White, rotation: 0, origin: Vector2.Zero, scale: 1, effects: SpriteEffects.None, Constants.TEXT_LAYER_DEPTH);
            }
            else if (Room10)
            {
                instance._spriteBatch.DrawString(instance.smallerFont, "EASTMOST PENINSULA", new Vector2(270, 190), Color.White, rotation: 0, origin: Vector2.Zero, scale: 1, effects: SpriteEffects.None, Constants.TEXT_LAYER_DEPTH);
                instance._spriteBatch.DrawString(instance.smallerFont, "IS THE SECRET.", new Vector2(300, 220), Color.White, rotation: 0, origin: Vector2.Zero, scale: 1, effects: SpriteEffects.None, Constants.TEXT_LAYER_DEPTH);
            }
            else if (TitleScreen)
            {
                //instance._spriteBatch.DrawString(instance.mainFont, "Zelda", new Vector2(200, 0), Color.White);
                instance._spriteBatch.DrawString(instance.smallerFont, "Start Game", new Vector2(320, 300), Color.White);
                instance._spriteBatch.DrawString(instance.smallerFont, "Level Select", new Vector2(312, 350), Color.White);
                instance._spriteBatch.DrawString(instance.smallerFont, "Level Creator", new Vector2(302, 400), Color.White);
            }
            else if (LevelSelectScreen)
            {
                string[] levels = GetLevelNames();

                for (int i = 0; i < levels.Length; i++)
                {
                    instance._spriteBatch.DrawString(instance.smallerFont, levels[i], new Vector2(300, 300 + (50 * i)), Color.White);
                }
            }
        }

        private string[] GetLevelNames()
        {
            string[] names = new string[GetTotalLevels()];

            int i = 0;
            foreach (string s in Directory.GetDirectories(GetLevelPath()))
            {

                string level;

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    level = s.Substring(s.LastIndexOf('\\') + 1);
                }
                else
                {
                    level = s.Substring(s.LastIndexOf('/') + 1);
                }

                if (!(level.Equals("TitleScreen") || level.Equals("LevelSelectScreen") || level.Equals("LevelCreator")))
                {
                    names[i] = level;
                    i++;
                }
            }

            return names;
        }

        private int GetTotalLevels()
        {
            // totalLevels doesn't need to include TitleScreen, LevelSelectScreen, or LevelCreator
            return Directory.GetDirectories(GetLevelPath()).Length - 3;
        }
        private static void HandleGameOver()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            Keys restartKey = instance.game.keyboard.GetKey(KeyboardAction.RESTART);
            //Restart
            if (pressedKeys.Contains(restartKey))
            {
                instance.game.RestartGame();
            }
        }

        private string GetLevelPath()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @$"..\..\..\Levels\");
            }
            else
            {
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @$"../../../Levels/");
            }
        }

        private static void HandleGamePaused()
        {
            //Resume
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            Keys resumeKey = instance.game.keyboard.GetKey(KeyboardAction.RESUME);
            if (pressedKeys.Contains(resumeKey))
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
