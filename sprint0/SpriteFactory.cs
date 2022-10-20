﻿using Microsoft.Xna.Framework;
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
        private Texture2D dungeonSheet, dungeonDoorNorth, dungeonDoorSouth, dungeonDoorEast, dungeonDoorWest, dungeonBadDoorNorth, dungeonBadDoorSouth, dungeonSand, dungeonMonster1, dungeonMonster2, dungeonMonster1Faded, dungeonMonster2Faded, dungeonBlock, dungeonAbyss, dungeonStairs;
        private Texture2D linkSpritesheet, enemiesSpritesheet, projectileSpritesheet, boomerangSpritesheet, octorokSpritesheet;
        private Texture2D GreenBlock, BlackBlock, PurpleBlock;
        private Texture2D waterBlock;
        private Texture2D Arrow, BlueCandle, Bomb, Boomerang, Bow, Clock, Compass, Fairy, Food, Heart, HeartContainer, Key, Letter;

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

        // Load the sprite sheets.
        public void LoadTextures(ContentManager content, SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;

            dungeonSheet = content.Load<Texture2D>("DungeonBackground");
            dungeonDoorNorth = content.Load<Texture2D>("DungeonDoorNorth");
            dungeonDoorSouth = content.Load<Texture2D>("DungeonDoorSouth");
            dungeonDoorEast = content.Load<Texture2D>("DungeonDoorEast");
            dungeonDoorWest = content.Load<Texture2D>("DungeonDoorWest");
            dungeonBadDoorNorth = content.Load<Texture2D>("DungeonBadDoorNorth");
            dungeonBadDoorSouth = content.Load<Texture2D>("DungeonBadDoorSouth");
            dungeonSand = content.Load<Texture2D>("DungeonSand");
            dungeonMonster1 = content.Load<Texture2D>("DungeonMonster1");
            dungeonMonster2 = content.Load<Texture2D>("DungeonMonster2");
            dungeonMonster1Faded = content.Load<Texture2D>("DungeonMonster1Faded");
            dungeonMonster2Faded = content.Load<Texture2D>("DungeonMonster2Faded");
            dungeonBlock = content.Load<Texture2D>("DungeonBlock");
            dungeonAbyss = content.Load<Texture2D>("DungeonAbyss");
            dungeonStairs = content.Load<Texture2D>("DungeonStairs");

            waterBlock = content.Load<Texture2D>("WaterBlock");

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

        public void LoadZeldaTextures(ContentManager content)
        {

        }

        /*
         * Background
         */
        public Sprite Dungeon(Vector2 position)
        {
            return new Sprite(dungeonSheet, SpriteRectangle.Background, spriteBatch, position);
        }

        /*
         * Background blocks
         */
        public Sprite DungeonBlock(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonBlock.Width, dungeonBlock.Height) };
            return new Sprite(dungeonBlock, rectangles, spriteBatch, position);
        }

        public Sprite DungeonDoorNorth(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonDoorNorth.Width, dungeonDoorNorth.Height) };
            return new Sprite(dungeonDoorNorth, rectangles, spriteBatch, position);
        }

        public Sprite DungeonDoorSouth(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonDoorSouth.Width, dungeonDoorSouth.Height) };
            return new Sprite(dungeonDoorSouth, rectangles, spriteBatch, position);
        }

        public Sprite DungeonDoorEast(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonDoorEast.Width, dungeonDoorEast.Height) };
            return new Sprite(dungeonDoorEast, rectangles, spriteBatch, position);
        }

        public Sprite DungeonDoorWest(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonDoorWest.Width, dungeonDoorWest.Height) };
            return new Sprite(dungeonDoorWest, rectangles, spriteBatch, position);
        }

        public Sprite DungeonBadDoorNorth(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonBadDoorNorth.Width, dungeonBadDoorNorth.Height) };
            return new Sprite(dungeonBadDoorNorth, rectangles, spriteBatch, position);
        }

        public Sprite DungeonBadDoorSouth(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonBadDoorSouth.Width, dungeonBadDoorSouth.Height) };
            return new Sprite(dungeonBadDoorSouth, rectangles, spriteBatch, position);
        }

        public Sprite DungeonSand(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonSand.Width, dungeonSand.Height) };
            return new Sprite(dungeonSand, rectangles, spriteBatch, position);
        }

        public Sprite DungeonAbyss(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonAbyss.Width, dungeonAbyss.Height) };
            return new Sprite(dungeonAbyss, rectangles, spriteBatch, position);
        }

        public Sprite DungeonStairs(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonStairs.Width, dungeonStairs.Height) };
            return new Sprite(dungeonStairs, rectangles, spriteBatch, position);
        }

        public Sprite WaterBlock(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, waterBlock.Width, waterBlock.Height) };
            return new Sprite(waterBlock, rectangles, spriteBatch, position);
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
         * Link standing and damaged
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

        /*
         * Link attacking and damaged
         */
        public Sprite LinkAttackingRightDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingRightDamaged, spriteBatch, position);
        }

        public Sprite LinkAttackingLeftDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingLeftDamaged, spriteBatch, position);
        }

        public Sprite LinkAttackingUpDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingUpDamaged, spriteBatch, position);
        }

        public Sprite LinkAttackingDownDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingDownDamaged, spriteBatch, position);
        }

        /*
         * Link attacking
         */
        public Sprite LinkAttackingRight(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingRight, spriteBatch, position);
        }

        public Sprite LinkAttackingLeft(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingLeft, spriteBatch, position);
        }

        public Sprite LinkAttackingUp(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingUp, spriteBatch, position);
        }

        public Sprite LinkAttackingDown(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingDown, spriteBatch, position);
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
            result.Direction = Direction.LEFT;
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

        public Sprite DungeonMonster1(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonMonster1.Width, dungeonMonster1.Height) };
            return new Sprite(dungeonMonster1, rectangles, spriteBatch, position);
        }

        public Sprite DungeonMonster2(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonMonster2.Width, dungeonMonster2.Height) };
            return new Sprite(dungeonMonster2, rectangles, spriteBatch, position);
        }

        public Sprite DungeonMonster1Faded(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonMonster1Faded.Width, dungeonMonster1Faded.Height) };
            return new Sprite(dungeonMonster1Faded, rectangles, spriteBatch, position);
        }

        public Sprite DungeonMonster2Faded(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonMonster2Faded.Width, dungeonMonster2Faded.Height) };
            return new Sprite(dungeonMonster2Faded, rectangles, spriteBatch, position);
        }

        public Sprite ZeldaArrow(Vector2 position)
        {
            return new Sprite(Arrow, ItemRectangle.BowArrow, spriteBatch, position);
        }
    }
}
