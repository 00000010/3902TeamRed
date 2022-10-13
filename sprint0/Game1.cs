using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.Controllers;
using sprint0.Enemies;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Rectangles;
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
        private SpriteBatch _spriteBatch;

        public List<IUpdateable> updateables = new List<IUpdateable>();
        public List<IDrawable> drawables = new List<IDrawable>();
        
        public Player player;

        public List<Rectangle[]> enemies = new List<Rectangle[]>();
        public Enemy currEnemy;
        public int currEnemyIndex = 0;
        public GameObjectManager manager;
        public ISprite arrow;
        public ISprite boomerang;
        public ISprite rock;

        public Item item;
        public List<Sprite> items = new List<Sprite>();
        public int currItemIndex = 0;

        public Block block;
        public List<Sprite> blocks = new List<Sprite>();
        public int currBlockIndex = 0;

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

            /*
             * Instantiate player object
             */
            PlayerFactory.Instance.LoadTextures(Content);
            EnemyFactory.Instance.LoadTextures(Content);
            ItemFactory.Instance.LoadTextures(Content);
            BlockFactory.Instance.LoadTextures(Content);
            SpriteFactory.Instance.LoadZeldaTextures(Content);

            manager = new GameObjectManager(this);
            updateables.Add(manager);
            drawables.Add(manager);

            //Add Player
            player = PlayerFactory.Instance.Link(_spriteBatch, new Vector2(0, 0), manager);
            updateables.Add(player);
            drawables.Add(player);

            //Add Enemies
            enemies = EnemyFactory.Instance.getAllEnemyRectangles();
            currEnemy = EnemyFactory.Instance.Stalfos(_spriteBatch, new Vector2(500, 240), manager);
            updateables.Add(currEnemy);
            drawables.Add(currEnemy);

            //Add item sprites to list
            items = ItemFactory.Instance.getAllItems(_spriteBatch);

            // first item
            item = ItemFactory.Instance.ZeldaArrow(_spriteBatch, new Vector2(200, 200), manager);
            updateables.Add(item);
            drawables.Add(item);

            //add blocks to list
            blocks = BlockFactory.Instance.getAllBlocks(_spriteBatch);

            //first block
            block = BlockFactory.Instance.ZeldaBlack(_spriteBatch, new Vector2(400, 400), manager);
            updateables.Add(block);
            drawables.Add(block);
            

            //Add projectiles
            arrow = SpriteFactory.Instance.Arrow(_spriteBatch, new Vector2(0, 0));
            boomerang = SpriteFactory.Instance.Boomerang(_spriteBatch, new Vector2(0, 0));
            rock = SpriteFactory.Instance.Rock(_spriteBatch, new Vector2(0, 0));

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