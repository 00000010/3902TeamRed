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
    /// <summary>
    /// Class <c>SpriteFactory</c> creates the sprites from the spritesheets when requested.
    /// </summary>
    public class SpriteFactory
    {
        private Texture2D linkSpritesheet;
        private static SpriteFactory instance = new SpriteFactory();
        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private SpriteFactory() {}

        /// <summary>
        /// Load the sprite sheets.
        /// </summary>
        /// <param name="content"></param>
        public void LoadTextures(ContentManager content)
        {
            // TODO: if LinkRevised works, delete Link.png from project and rename LinkRevised to Link
            linkSpritesheet = content.Load<Texture2D>("Link");
        }

        /// <summary>
        /// Create and return a Link sprite standing right at the specified position with the specified velocity.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="position"></param>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public ISprite Link(SpriteBatch spriteBatch, Vector2 position, Vector2 velocity, int direction)
        {
            Rectangle[] rectangles = new Rectangle[1];
            rectangles[0] = new Rectangle(Constants.STARTING_LINK_POSITION_X, Constants.STARTING_LINK_POSITION_Y, Constants.LINK_WIDTH, Constants.LINK_HEIGHT);
            return new Sprite(linkSpritesheet, rectangles, spriteBatch, position, velocity, direction);
        }
    }
}
