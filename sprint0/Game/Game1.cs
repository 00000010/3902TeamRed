using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        
        //public IPlayer player;
        public IBlock block;
        public IItem item;
        public IEnemy enemy;

        public GameObjectManager manager;
        public LevelLoader loader;

        public int level = 0;

        public SpriteFont mainFont;
        public SpriteFont smallerFont;
        KeyboardController keyboard;

        public bool Paused { get; set; }
        public bool GameOver { get; set; }

        public bool Victory { get; set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(0.02);
        }

        protected override void Initialize()
        {
            base.Initialize();

            manager = new GameObjectManager(this);
            manager.AddObject(block); 

            keyboard = new KeyboardController();
            keyboard.LoadDefaultKeys(this);

            //Vector2 resolution = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            //Create level loader
            loader = new LevelLoader(this);
            loader.LoadLevel("Dungeon1");

            //Initialize the game so that it isn't paused and isn't over
            Paused = false;
            GameOver = false;
            Victory = false;

            //Play theme song in background
            MediaPlayer.Play(SoundFactory.Instance.themeSound);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = (float)0.1;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            SpriteFactory.Instance.LoadTextures(Content, _spriteBatch);
            SoundFactory.Instance.LoadSounds(Content);

            mainFont = Content.Load<SpriteFont>("Zelda_font");
            smallerFont = Content.Load<SpriteFont>("Zelda_font_smaller");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GameOver)
            {
                HandleGameOver();
                return;
            }
            else if (Paused)
            {
                HandleGamePaused();
                return;
            }
            else if (Victory)
            {
                HandleGameVictory();
                manager.Update(gameTime);
                return;
            }

            keyboard.Update(gameTime);
            manager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            manager.Draw(gameTime);
            if (GameOver)
            {
                _spriteBatch.DrawString(mainFont, "Game Over", new Vector2(270, 220), Color.White);
                _spriteBatch.DrawString(smallerFont, "Press R to Restart", new Vector2(270, 270), Color.White);
            } 
            else if (Paused)
            {
                _spriteBatch.DrawString(mainFont, "Paused", new Vector2(330, 220), Color.White);
                _spriteBatch.DrawString(smallerFont, "Press U to Resume", new Vector2(280, 270), Color.White);
            } 
            else if (Victory)
            {
                _spriteBatch.DrawString(mainFont, "Victory!", new Vector2(330, 220), Color.White);
                _spriteBatch.DrawString(smallerFont, "Press R to Restart", new Vector2(280, 270), Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void HandleGameOver()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            //Restart
            if (pressedKeys.Contains(Keys.R))
            {
                Initialize();
            }
        }

        private void HandleGamePaused()
        {
            //Resume
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            if (pressedKeys.Contains(Keys.U))
            {
                Paused = false;
            }
        }

        private void HandleGameVictory()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            //Restart
            if (pressedKeys.Contains(Keys.R))
            {
                Initialize();
            }
        }
    }
}