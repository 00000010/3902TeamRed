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

        public SpriteFont font;
        KeyboardController keyboard;

        public bool Paused { get; set; }
        public bool GameOver { get; set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            SpriteFactory.Instance.LoadTextures(Content, _spriteBatch);
            SoundFactory.Instance.LoadSounds(Content);
            TextSpriteFactory.Instance.LoadTextures(Content, _spriteBatch);

            //Play theme song in background
            MediaPlayer.Play(SoundFactory.Instance.themeSound);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = (float)0.1;

            manager = new GameObjectManager(this);
            manager.AddObject(block); // CollisionDevBranch

            keyboard = new KeyboardController();
            keyboard.LoadDefaultKeys(this);

            Vector2 resolution = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            loader = new LevelLoader(this);
            loader.LoadNextLevel();
            Console.WriteLine(loader.ToString());

            Paused = false;
            GameOver = false;

            font = Content.Load<SpriteFont>("Zelda_font");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GameOver)
            {
                Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
                if (pressedKeys.Contains(Keys.R))
                {
                    Initialize();
                }
                return;
            }
            if (Paused)
            {
                Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
                if (pressedKeys.Contains(Keys.U))
                {
                    Paused = false;
                }
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
                _spriteBatch.DrawString(font, "Game Over", new Vector2(270, 220), Color.White);
            } else if (Paused)
            {
                _spriteBatch.DrawString(font, "Paused", new Vector2(330, 220), Color.White);
            } 
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}