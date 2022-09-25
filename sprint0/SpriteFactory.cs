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
    public class SpriteFactory
    {
        private Texture2D luigiSpritesheet;
        private Texture2D projectileSpritesheet;
        private Texture2D boomerangSpritesheet;
        private static SpriteFactory instance = new SpriteFactory();
        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private SpriteFactory() { }
        public void LoadTextures(ContentManager content)
        {
            luigiSpritesheet = content.Load<Texture2D>("smb_luigi_sheet");
        }
        public void LoadZeldaTextures(ContentManager content)
        {
            projectileSpritesheet = content.Load<Texture2D>("zeldaspritesheet");
            boomerangSpritesheet = content.Load<Texture2D>("goriyaspritesheet");
        }
        public ISprite Luigi(SpriteBatch spriteBatch, Vector2 position)
        {
            return new Sprite(luigiSpritesheet, SpriteRectangle.LuigiStandingRight, spriteBatch, position);
        }
        public ISprite Arrow(SpriteBatch spriteBatch, Vector2 position)
        {
            return new Sprite(projectileSpritesheet, new Rectangle[1], spriteBatch, position);
        }

        public ISprite Boomerang(SpriteBatch spriteBatch, Vector2 position)
        {
            return new Sprite(boomerangSpritesheet, ProjectileRectangle.Boomerang, spriteBatch, position);
        }
    }
}
