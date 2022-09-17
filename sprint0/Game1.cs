using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public List<IUpdateable> updateables = new List<IUpdateable>();
        public List<IDrawable> drawables = new List<IDrawable>();

        public ISprite player;
        public List<Rectangle[]> rectangles = new List<Rectangle[]>();
        public ISprite currEnemy;
        public int currIndex = 0;

        SpriteFont font;
        KeyboardController keyboard;
        MouseController mouse;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //TargetElapsedTime = TimeSpan.FromMilliseconds(200);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            SpriteFactory.Instance.LoadTextures(Content);
            EnemyFactory.Instance.LoadTextures(Content);

            //Add Player
            player = SpriteFactory.Instance.Luigi(_spriteBatch, new Vector2(0, 0), new Vector2(0, 0));
            updateables.Add(player);
            drawables.Add(player);

            //Add Enemies
            rectangles.Add(EnemyRectangle.Stalfos);
            rectangles.Add(EnemyRectangle.Keese);
            rectangles.Add(EnemyRectangle.Goriya);
            rectangles.Add(EnemyRectangle.Gel);
            rectangles.Add(EnemyRectangle.Octorok);
            currEnemy = EnemyFactory.Instance.Stalfos(_spriteBatch, new Vector2(500, 240), new Vector2(0, 1));
            updateables.Add(currEnemy);
            drawables.Add(currEnemy);

            keyboard = new KeyboardController();
            keyboard.LoadDefaultKeys(this);
            updateables.Add(keyboard);

            Vector2 resolution = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            mouse = new MouseController(resolution);
            mouse.LoadMouseCommands(this);
            updateables.Add(mouse);

            font = Content.Load<SpriteFont>("Arial");
            string website = "https://www.mariomayhem.com/downloads/sprites/smb1/smb_luigi_sheet.png";
            string text = "Credits:\nProgram made by: Adam Perhala\nSprites from: " + website;
            TextSprite textSprite = new TextSprite(_spriteBatch, new Vector2(100, 400), font, text, Color.Black);
            drawables.Add(textSprite);
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            // TODO: Add your update logic here
            foreach (IUpdateable updateable in updateables)
            {
                updateable.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            
            foreach (IDrawable drawable in drawables)
            {
                drawable.Draw(gameTime);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}