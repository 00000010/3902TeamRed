using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
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
            this.enemiesSpritesheet = content.Load<Texture2D>("Zelda_sprite");
        }

        public Enemy Stalfos(SpriteBatch spriteBatch, Vector2 position)
        {
            return new Enemy(this.enemiesSpritesheet, EnemyRectangle.Stalfos, spriteBatch, position);
        }

        public Enemy Keese(SpriteBatch spriteBatch, Vector2 position)
        {
            return new Enemy(this.enemiesSpritesheet, EnemyRectangle.Keese, spriteBatch, position);
        }

        public Enemy Gel(SpriteBatch spriteBatch, Vector2 position)
        {
            return new Enemy(this.enemiesSpritesheet, EnemyRectangle.Gel, spriteBatch, position);
        }
        public Enemy Goriya(SpriteBatch spriteBatch, Vector2 position)
        {
            return new Enemy(this.enemiesSpritesheet, EnemyRectangle.Goriya, spriteBatch, position);
        }
        public Enemy Octorok(SpriteBatch spriteBatch, Vector2 position)
        {
            return new Enemy(this.enemiesSpritesheet, EnemyRectangle.Octorok, spriteBatch, position);
        }

    }
}
