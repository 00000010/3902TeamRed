using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Enemies;
using sprint0.Rectangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Factories
{
    public class EnemyFactory
    {
        private Texture2D enemiesSpritesheet;
        private static EnemyFactory instance = new EnemyFactory();

        public static EnemyFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private EnemyFactory() { }
        public void LoadTextures(ContentManager content)
        {
            enemiesSpritesheet = content.Load<Texture2D>("Zelda_sprite");
        }

        public List<Rectangle[]> getAllEnemyRectangles()
        {
            List<Rectangle[]> enemies = new List<Rectangle[]>();
            enemies.Add(EnemyRectangle.Stalfos);
            enemies.Add(EnemyRectangle.Keese);
            enemies.Add(EnemyRectangle.Goriya);
            enemies.Add(EnemyRectangle.Gel);
            enemies.Add(EnemyRectangle.Octorok);
            return enemies;
        }

        public Enemy Stalfos(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager)
        {
            Enemy newEnemy = new Enemy(enemiesSpritesheet, EnemyRectangle.Stalfos, spriteBatch, position);
            manager.addEnemy(newEnemy);
            return newEnemy;
        }

        public Enemy Keese(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager)
        {
            Enemy newEnemy = new Enemy(enemiesSpritesheet, EnemyRectangle.Keese, spriteBatch, position);
            manager.addEnemy(newEnemy);
            return newEnemy;
        }

        public Enemy Gel(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager)
        {
            Enemy newEnemy = new Enemy(enemiesSpritesheet, EnemyRectangle.Gel, spriteBatch, position);
            manager.addEnemy(newEnemy);
            return newEnemy;
        }
        public Enemy Goriya(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager)
        {
            Enemy newEnemy = new Enemy(enemiesSpritesheet, EnemyRectangle.Goriya, spriteBatch, position);
            manager.addEnemy(newEnemy);
            return newEnemy;
        }
        public Enemy Octorok(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager)
        {
            Enemy newEnemy = new Enemy(enemiesSpritesheet, EnemyRectangle.Octorok, spriteBatch, position);
            manager.addEnemy(newEnemy);
            return newEnemy;
        }

    }
}
