using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        
        public IPlayer player;
        public IBlock block;
        public IItem item;
        public IEnemy enemy;

        public GameObjectManager manager;
        public LevelLoader loader;

        SpriteFont font;
        KeyboardController keyboard;

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

            manager = new GameObjectManager(this);
            manager.AddObject(block); // CollisionDevBranch

            keyboard = new KeyboardController();
            keyboard.LoadDefaultKeys(this);

            Vector2 resolution = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            player = PlayerFactory.Instance.Link(new Vector2(Constants.FROM_DOWN_LINK_POSITION_X, Constants.FROM_DOWN_LINK_POSITION_Y));
            loader = new LevelLoader(this);
            loader.LoadLevel("Dungeon1");
        }

        protected override void Update(GameTime gameTime)
        {
            keyboard.Update(gameTime);
            manager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp);
            manager.Draw(gameTime);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
