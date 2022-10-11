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

        public List<IUpdateable> updateables = new List<IUpdateable>();
        public List<IDrawable> drawables = new List<IDrawable>();
        
        public IPlayer player;
        public IBlock block;
        public IItem item;
        public IEnemy enemy;

        public GameObjectManager manager;

        SpriteFont font;
        KeyboardController keyboard;
        MouseController mouse;

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

            //Add Player
            player = PlayerFactory.Instance.Link(new Vector2(0, 0));
            updateables.Add(player);
            drawables.Add(player);

            //Add Block
            block = BlockFactory.Instance.ZeldaBlackBlock(new Vector2(100, 100));
            drawables.Add(block);

            //Add item
            item = ItemFactory.Instance.ZeldaBlueCandle(new Vector2(200, 200));
            drawables.Add(item);

            //Add enemy
            enemy = EnemyFactory.Instance.Octorok(new Vector2(300, 300));
            updateables.Add(enemy);
            drawables.Add(enemy);

            manager = new GameObjectManager(this);

            keyboard = new KeyboardController();
            keyboard.LoadDefaultKeys(this);
            updateables.Add(keyboard);

            Vector2 resolution = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            
            mouse = new MouseController(resolution);
            mouse.LoadMouseCommands(this);
            updateables.Add(mouse);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IUpdateable updateable in updateables)
            {
                updateable.Update(gameTime);
            }

            manager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            foreach (IDrawable drawable in drawables)
            {
                drawable.Draw(gameTime);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}