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
    public class PlayerFactory
    {
        private Texture2D spritesheet;
        private static PlayerFactory instance = new PlayerFactory();
        public static PlayerFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private PlayerFactory() { }
        public void LoadTextures(ContentManager content)
        {
            spritesheet = content.Load<Texture2D>("smb_luigi_sheet");
        }
        public Player Luigi(SpriteBatch spriteBatch, Vector2 position)
        {
            return new Player(spritesheet, SpriteRectangle.LuigiStandingRight, spriteBatch, position);
        }
    }
}
