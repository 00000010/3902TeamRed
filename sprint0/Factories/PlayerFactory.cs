using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Factories
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
            spritesheet = content.Load<Texture2D>("Link");
        }
        public Player Link(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager)
        {
            Rectangle[] rectangles = new Rectangle[1];
            rectangles[0] = new Rectangle(
                Constants.STARTING_LINK_POSITION_X,
                Constants.STARTING_LINK_POSITION_Y,
                Constants.LINK_WIDTH,
                Constants.LINK_HEIGHT);
            Player player = new Player(spritesheet, rectangles, spriteBatch, position);
            manager.addPlayer(player);
            return player;
        }
    }
}
