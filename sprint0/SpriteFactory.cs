using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static sprint0.SpriteRectangle;

namespace sprint0
{
    /// <summary>
    /// Class <c>SpriteFactory</c> creates the sprites from the spritesheets when requested.
    /// </summary>
    public class SpriteFactory
    {
        private Texture2D linkSpritesheet;
        private Texture2D enemiesSpritesheet;
        private Texture2D projectileSpritesheet;
        private Texture2D boomerangSpritesheet;
        private Texture2D octorokSpritesheet;

        private Texture2D GreenBlock;
        private Texture2D BlackBlock;
        private Texture2D PurpleBlock;

        private Texture2D Arrow;
        private Texture2D BlueCandle;
        private Texture2D Bomb;
        private Texture2D Boomerang;
        private Texture2D Bow;
        private Texture2D Clock;
        private Texture2D Compass;
        private Texture2D Fairy;
        private Texture2D Food;
        private Texture2D Heart;
        private Texture2D HeartContainer;
        private Texture2D Key;
        private Texture2D Letter;

        private SpriteBatch spriteBatch;

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
        public void LoadTextures(ContentManager content, SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;

            linkSpritesheet = content.Load<Texture2D>("Link");

            GreenBlock = content.Load<Texture2D>("ZeldaAltpBlock");
            BlackBlock = content.Load<Texture2D>("ZeldaLaBlock");
            PurpleBlock = content.Load<Texture2D>("ZeldaLadxBlock");

            Arrow = content.Load<Texture2D>("ZeldaSpriteArrow");
            BlueCandle = content.Load<Texture2D>("ZeldaSpriteBlueCandle");
            Bomb = content.Load<Texture2D>("ZeldaSpriteBomb");
            Boomerang = content.Load<Texture2D>("ZeldaSpriteBoomerang");
            Bow = content.Load<Texture2D>("ZeldaSpriteBow");
            Clock = content.Load<Texture2D>("ZeldaSpriteClock");
            Compass = content.Load<Texture2D>("ZeldaSpriteCompass");
            Fairy = content.Load<Texture2D>("ZeldaSpriteFairy");
            Food = content.Load<Texture2D>("ZeldaSpriteFood");
            Heart = content.Load<Texture2D>("ZeldaSpriteHeart");
            HeartContainer = content.Load<Texture2D>("ZeldaSpriteHeartContainer");
            Key = content.Load<Texture2D>("ZeldaSpriteKey");
            Letter = content.Load<Texture2D>("ZeldaSpriteLetter");

            enemiesSpritesheet = content.Load<Texture2D>("Zelda_sprite");

            //boomerangSpritesheet = content.Load<Texture2D>("goriyaspritesheet");
            //octorokSpritesheet = content.Load<Texture2D>("OctorokSpritesheet");

            //projectileSpritesheet = content.Load<Texture2D>("zeldaspritesheet");
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

        }

        /*
         * Link running
         */
        public Sprite LinkRunningRight(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningRight, spriteBatch, position);
        }

        public Sprite LinkRunningLeft(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningLeft, spriteBatch, position);
        }
        public Sprite LinkRunningUp(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningUp, spriteBatch, position);
        }

        public Sprite LinkRunningDown(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningDown, spriteBatch, position);
        }

        /*
         * Link standing
         */
        public Sprite LinkStandingRight(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingRight, spriteBatch, position);
        }

        public Sprite LinkStandingLeft(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingLeft, spriteBatch, position);
        }

        public Sprite LinkStandingUp(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingUp, spriteBatch, position);
        }

        public Sprite LinkStandingDown(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingDown, spriteBatch, position);
        }

        /*
         * Link running damaged
         */
        public Sprite LinkRunningRightDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningRightDamaged, spriteBatch, position);
        }

        public Sprite LinkRunningLeftDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningLeftDamaged, spriteBatch, position);
        }
        public Sprite LinkRunningUpDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningUpDamaged, spriteBatch, position);
        }

        public Sprite LinkRunningDownDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningDownDamaged, spriteBatch, position);
        }

        /*
         * Link standing
         */
        public Sprite LinkStandingRightDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingRightDamaged, spriteBatch, position);
        }

        public Sprite LinkStandingLeftDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingLeftDamaged, spriteBatch, position);
        }

        public Sprite LinkStandingUpDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingUpDamaged, spriteBatch, position);
        }

        public Sprite LinkStandingDownDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingDownDamaged, spriteBatch, position);
        }


        public Sprite ZeldaGreen(Vector2 position)
        {
            return new Sprite(GreenBlock, BlockRectangle.NormalBlock, spriteBatch, position);
        }

        public Sprite ZeldaBlack(Vector2 position)
        {
            return new Sprite(BlackBlock, BlockRectangle.NormalBlock, spriteBatch, position);
        }

        public Sprite ZeldaPurple(Vector2 position)
        {
            return new Sprite(PurpleBlock, BlockRectangle.NormalBlock, spriteBatch, position);
        }


        /*
         * Items
         */
        public Sprite ZeldaBlueCandle(Vector2 position)
        {
            return new Sprite(BlueCandle, ItemRectangle.Candle, spriteBatch, position);
        }

        public Sprite ZeldaBomb(Vector2 position)
        {
            return new Sprite(Bomb, ItemRectangle.Bomb, spriteBatch, position);
        }

        public Sprite ZeldaBoomerang(Vector2 position)
        {
            return new Sprite(Boomerang, ItemRectangle.Boomerang, spriteBatch, position);
        }

        public Sprite ZeldaBow(Vector2 position)
        {
            return new Sprite(Bow, ItemRectangle.BowArrow, spriteBatch, position);
        }

        public Sprite ZeldaClock(Vector2 position)
        {
            return new Sprite(Clock, ItemRectangle.Clock, spriteBatch, position);
        }

        public Sprite ZeldaCompass(Vector2 position)
        {
            return new Sprite(Compass, ItemRectangle.Compass, spriteBatch, position);
        }

        public Sprite ZeldaFairy(Vector2 position)
        {
            return new Sprite(Fairy, ItemRectangle.Fairy, spriteBatch, position);
        }

        public Sprite ZeldaFood(Vector2 position)
        {
            return new Sprite(Food, ItemRectangle.Food, spriteBatch, position);
        }

        public Sprite ZeldaHeart(Vector2 position)
        {
            return new Sprite(Heart, ItemRectangle.Heart, spriteBatch, position);
        }

        public Sprite ZeldaHeartContainer(Vector2 position)
        {
            return new Sprite(HeartContainer, ItemRectangle.HeartContainer, spriteBatch, position);
        }

        public Sprite ZeldaKey(Vector2 position)
        {
            return new Sprite(Key, ItemRectangle.Key, spriteBatch, position);
        }

        public Sprite ZeldaLetter(Vector2 position)
        {
            return new Sprite(Letter, ItemRectangle.Letter, spriteBatch, position);
        }

        public Sprite Stalfos(Vector2 position)
        {
            return new Sprite(enemiesSpritesheet, EnemyRectangle.Stalfos, spriteBatch, position);
        }

        public Sprite Keese(Vector2 position)
        {
            return new Sprite(enemiesSpritesheet, EnemyRectangle.Keese, spriteBatch, position);
        }

        public Sprite GoriyaLeft(Vector2 position)
        {
            Sprite result = new Sprite(enemiesSpritesheet, EnemyRectangle.GoriyaLeft, spriteBatch, position);
            result.Direction = Direction.DOWN;
            return result;
        }

        public Sprite GoriyaRight(Vector2 position)
        {
            Sprite result = new Sprite(enemiesSpritesheet, EnemyRectangle.GoriyaRight, spriteBatch, position);
            result.Direction = Direction.RIGHT;
            return result;
        }

        public Sprite GoriyaUp(Vector2 position)
        {
            Sprite result = new Sprite(enemiesSpritesheet, EnemyRectangle.GoriyaUp, spriteBatch, position);
            result.Direction = Direction.UP;
            return result;
        }

        public Sprite GoriyaDown(Vector2 position)
        {
            Sprite result = new Sprite(enemiesSpritesheet, EnemyRectangle.GoriyaDown, spriteBatch, position);
            result.Direction = Direction.DOWN;
            return result;
        }

        public Sprite Gel(Vector2 position)
        {
            return new Sprite(enemiesSpritesheet, EnemyRectangle.Gel, spriteBatch, position);
        }
        //public Sprite OctorokLeft(Vector2 position)
        //{
        //    return new Sprite(enemiesSpritesheet, EnemyRectangle.OctorokLeft, spriteBatch, position);
        //}
        //public Sprite OctorokRight(Vector2 position)
        //{
        //    return new Sprite(enemiesSpritesheet, EnemyRectangle.OctorokRight, spriteBatch, position);
        //}
        //public Sprite OctorokDown(Vector2 position)
        //{
        //    return new Sprite(enemiesSpritesheet, EnemyRectangle.OctorokDown, spriteBatch, position);
        //}
        //public Sprite OctorokUp(Vector2 position)
        //{
        //    return new Sprite(enemiesSpritesheet, EnemyRectangle.OctorokUp, spriteBatch, position);
        //}

        public Sprite Octorok(Vector2 position)
        {
            return new Sprite(enemiesSpritesheet, EnemyRectangle.Octorok, spriteBatch, position);
        }

        public Sprite ZeldaArrow(Vector2 position)
        {
            return new Sprite(Arrow, ItemRectangle.BowArrow, spriteBatch, position);
        }
    }
}
