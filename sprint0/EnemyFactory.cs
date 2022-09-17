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

        public ISprite Stalfos(SpriteBatch spriteBatch, Vector2 position, Vector2 velocity)
        {
            return new Enemy(this.enemiesSpritesheet, EnemyRectangle.Stalfos, spriteBatch, position, velocity);
        }

        public ISprite Keese(SpriteBatch spriteBatch, Vector2 position, Vector2 velocity)
        {
            return new Enemy(this.enemiesSpritesheet, EnemyRectangle.Keese, spriteBatch, position, velocity);
        }

        public ISprite Gel(SpriteBatch spriteBatch, Vector2 position, Vector2 velocity)
        {
            return new Enemy(this.enemiesSpritesheet, EnemyRectangle.Gel, spriteBatch, position, velocity);
        }
        public ISprite Goriya(SpriteBatch spriteBatch, Vector2 position, Vector2 velocity)
        {
            return new Enemy(this.enemiesSpritesheet, EnemyRectangle.Goriya, spriteBatch, position, velocity);
        }
        public ISprite Octorok(SpriteBatch spriteBatch, Vector2 position, Vector2 velocity)
        {
            return new Enemy(this.enemiesSpritesheet, EnemyRectangle.Octorok, spriteBatch, position, velocity);
        }

    }
}
