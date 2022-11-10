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
        //public IBlock block;
        public IItem item;
        public IEnemy enemy;

        public GameObjectManager manager;
        public LevelLoader loader;
        KeyboardController keyboard;

        public int level = 0;

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
            //manager.AddObject(block); 

            keyboard = new KeyboardController();
            keyboard.LoadDefaultKeys(this);

            //Create level loader
            loader = new LevelLoader(this);
            loader.LoadLevel("Dungeon1");

            HandleSpecialDisplays.Instance.Initialize(this);

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
            HandleSpecialDisplays.Instance.LoadDisplays(Content, _spriteBatch);
            TextSpriteFactory.Instance.LoadTextures(Content, _spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            if (HandleSpecialDisplays.Instance.HandleSpecialUpdates(gameTime)) return;

            keyboard.Update(gameTime);
            manager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            manager.Draw(gameTime);
            HandleSpecialDisplays.Instance.HandleSpecialDrawings();
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void RestartGame()
        {
            Initialize();
        }
    }
}

