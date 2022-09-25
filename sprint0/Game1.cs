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
        
        //Player became a player class
        public Player player;
        public List<Rectangle[]> enemies = new List<Rectangle[]>();
        public Enemy currEnemy;
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
            
            updateables.Add(player);
            drawables.Add(player);

            /*
             * Instantiate inputs
             */
            keyboard = new KeyboardController();
            keyboard.LoadDefaultKeys(this);
            updateables.Add(keyboard);

            Vector2 resolution = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            mouse = new MouseController(resolution);
            mouse.LoadMouseCommands(this);
            updateables.Add(mouse);

            //font = Content.Load<SpriteFont>("Arial");
            //string website = "https://www.mariomayhem.com/downloads/sprites/smb1/smb_luigi_sheet.png";
            //string text = "Credits:\nProgram made by: Adam Perhala\nSprites from: " + website;
            //TextSprite textSprite = new TextSprite(_spriteBatch, new Vector2(100, 400), font, text, Color.Black);
            //drawables.Add(textSprite);
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