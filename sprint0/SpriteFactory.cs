using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        private Texture2D projectileSpritesheet;
        private Texture2D boomerangSpritesheet;
        private Texture2D octorokSpritesheet;

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
            linkSpritesheet = content.Load<Texture2D>("Link");
        }

        // TODO: Fix the collateral damage here
        ///// <summary>
        ///// Create and return a Link sprite standing right at the specified position with the specified velocity.
        ///// </summary>
        ///// <param name="spriteBatch"></param>
        ///// <param name="position"></param>
        ///// <param name="velocity"></param>
        ///// <returns></returns>
        //public ISprite Link(SpriteBatch spriteBatch, Vector2 position, Vector2 velocity, int direction)
        //{
        //    Rectangle[] rectangles = new Rectangle[1];
        //    rectangles[0] = new Rectangle(Constants.STARTING_LINK_POSITION_X, Constants.STARTING_LINK_POSITION_Y, Constants.LINK_WIDTH, Constants.LINK_HEIGHT);
        //    return new Sprite(linkSpritesheet, rectangles, spriteBatch, position, velocity, direction);

        public void LoadZeldaTextures(ContentManager content)
        {
            projectileSpritesheet = content.Load<Texture2D>("zeldaspritesheet");
            boomerangSpritesheet = content.Load<Texture2D>("goriyaspritesheet");
            octorokSpritesheet = content.Load<Texture2D>("OctorokSpritesheet");
        }
        public ISprite Link(SpriteBatch spriteBatch, Vector2 position)
        {
              Rectangle[] rectangles = new Rectangle[1];
            rectangles[0] = new Rectangle(Constants.STARTING_LINK_POSITION_X, Constants.STARTING_LINK_POSITION_Y, Constants.LINK_WIDTH, Constants.LINK_HEIGHT);
            return new Sprite(linkSpritesheet, rectangles, spriteBatch, position);
        }
        public ISprite Arrow(SpriteBatch spriteBatch, Vector2 position)
        {
            return new Projectile(projectileSpritesheet, new Rectangle[1], spriteBatch, position);
        }

        public ISprite Boomerang(SpriteBatch spriteBatch, Vector2 position)
        {
            return new Projectile(boomerangSpritesheet, ProjectileRectangle.Boomerang, spriteBatch, position);
        }

        public ISprite Rock(SpriteBatch spriteBatch, Vector2 position)
        {
            return new Projectile(octorokSpritesheet, ProjectileRectangle.Rock, spriteBatch, position);
        }
    }
}
