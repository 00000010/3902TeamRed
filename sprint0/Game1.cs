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

            //Add Player
            player = PlayerFactory.Instance.Luigi(_spriteBatch, new Vector2(0, 0));
            updateables.Add(player);
            drawables.Add(player);

            //Add Enemies
            enemies.Add(EnemyRectangle.Stalfos);
            enemies.Add(EnemyRectangle.Keese);
            enemies.Add(EnemyRectangle.Goriya);
            enemies.Add(EnemyRectangle.Gel);
            enemies.Add(EnemyRectangle.Octorok);
            currEnemy = EnemyFactory.Instance.Stalfos(_spriteBatch, new Vector2(500, 240));
            updateables.Add(currEnemy);
            drawables.Add(currEnemy);

            /*
             * Add projectiles
             */
            SpriteFactory.Instance.LoadZeldaTextures(Content);
            //Adding arrow
            arrow = SpriteFactory.Instance.Arrow(_spriteBatch, new Vector2(0, 0));
            arrow.Velocity = new Vector2(10, 0);
            //Adding boomerang
            boomerang = SpriteFactory.Instance.Boomerang(_spriteBatch, new Vector2(0, 0));
            //Rock
            rock = SpriteFactory.Instance.Rock(_spriteBatch, new Vector2(0, 0));
            manager = new GameObjectManager(this);
            updateables.Add(manager);
            drawables.Add(manager);

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