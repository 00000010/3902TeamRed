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
using static sprint0.InventoryFactory;
using static sprint0.SpriteRectangle;

namespace sprint0
{
    /// <summary>
    /// Class <c>SpriteFactory</c> creates the sprites from the spritesheets when requested.
    /// </summary>
    public class SpriteFactory
    {
        private Texture2D dungeonSheet, dungeonWallNorth, dungeonWallSouth, dungeonWallEast, dungeonWallWest, dungeonDoorNorth, dungeonDoorSouth, dungeonDoorEast, dungeonDoorWest, dungeonBadDoorNorth, dungeonBadDoorSouth, dungeonSand, dungeonMonster1, dungeonMonster2, dungeonMonster1Faded, dungeonMonster2Faded, dungeonBlock, dungeonAbyss, dungeonStairs;
        private Texture2D linkSpritesheet, enemiesSpritesheet, Dragon, OldMan;
        private Texture2D GreenBlock, BlackBlock, PurpleBlock, waterBlock;
        private Texture2D HUD, ZeldaBlueMap, ZeldaOrangeMap;
        private Texture2D ProjectileEffect;
        private Texture2D TopHud, Fullheart, Halfheart, Emptyheart, MapBlocks;

        private Texture2D Arrow, BlueCandle, Bomb, Boomerang, Bow, Clock, Compass, Fairy, Food, Heart, HeartContainer, Key, Letter, Rupy, Triforce;
        private Texture2D GridSquareBlock, SaveIconBlock, LevelCreatorTextBlock;

        private Texture2D logo;

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
            dungeonWallNorth = content.Load<Texture2D>("DungeonNorthWall");
            dungeonWallSouth = content.Load<Texture2D>("DungeonSouthWall");
            dungeonWallEast = content.Load<Texture2D>("DungeonEastWall");
            dungeonWallWest = content.Load<Texture2D>("DungeonWestWall");
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
            Dragon = content.Load<Texture2D>("Zelda_bosses_test");

            GreenBlock = content.Load<Texture2D>("ZeldaAltpBlock");
            BlackBlock = content.Load<Texture2D>("ZeldaLaBlock");
            PurpleBlock = content.Load<Texture2D>("ZeldaLadxBlock");

            GridSquareBlock = content.Load<Texture2D>("GridSquare");
            SaveIconBlock = content.Load<Texture2D>("SaveIcon");
            LevelCreatorTextBlock = content.Load<Texture2D>("LevelCreatorText");

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
            Triforce = content.Load<Texture2D>("zeldaspritesheet");

            ProjectileEffect = content.Load<Texture2D>("zeldaspritesheet");

            enemiesSpritesheet = content.Load<Texture2D>("Zelda_sprite");
            OldMan = content.Load<Texture2D>("Zelda_old_man");
            HUD = content.Load<Texture2D>("Zelda_HUD");
            ZeldaBlueMap = content.Load<Texture2D>("Zelda_map");
            ZeldaOrangeMap = content.Load<Texture2D>("Zelda_orange_map");
            Rupy = content.Load<Texture2D>("ZeldaSpriteRupy");
            TopHud = content.Load<Texture2D>("tophud");
            Fullheart = content.Load<Texture2D>("Heart");
            Halfheart = content.Load<Texture2D>("HalfHeart");
            Emptyheart = content.Load<Texture2D>("EmptyHeart");
            MapBlocks = content.Load<Texture2D>("MapBlocks");

            logo = content.Load<Texture2D>("Zelda_1_Logo_in_game");
        }

        public void LoadZeldaTextures(ContentManager content)
        {

        }

        /*
         * Background
         */
        
        public Sprite Dungeon(Vector2 position)
        {
            Sprite dun = new Sprite(dungeonSheet, SpriteRectangle.Background, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
            dun.objectKind = "Dungeon";
            return dun;
        }

        public Sprite DungeonNorthWall(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonWallNorth.Width, dungeonWallNorth.Height) };
            return new Sprite(dungeonWallNorth, rectangles, spriteBatch, position, Constants.BLOCK_LAYER_DEPTH);
        }

        public Sprite DungeonSouthWall(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonWallSouth.Width, dungeonWallSouth.Height) };
            return new Sprite(dungeonWallSouth, rectangles, spriteBatch, position, Constants.BLOCK_LAYER_DEPTH);
        }

        public Sprite DungeonEastWall(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonWallEast.Width, dungeonWallEast.Height) };
            return new Sprite(dungeonWallEast, rectangles, spriteBatch, position, Constants.BLOCK_LAYER_DEPTH);
        }

        public Sprite DungeonWestWall(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonWallWest.Width, dungeonWallWest.Height) };
            return new Sprite(dungeonWallWest, rectangles, spriteBatch, position, Constants.BLOCK_LAYER_DEPTH);
        }

        /*
         * Background blocks
         */
        public Sprite DungeonBlock(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonBlock.Width, dungeonBlock.Height) };
            return new Sprite(dungeonBlock, rectangles, spriteBatch, position, Constants.BLOCK_LAYER_DEPTH);
        }

        public Sprite DungeonDoorNorth(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonDoorNorth.Width, dungeonDoorNorth.Height) };
            return new Sprite(dungeonDoorNorth, rectangles, spriteBatch, position, Constants.DOOR_LAYER_DEPTH);
        }

        public Sprite DungeonDoorSouth(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonDoorSouth.Width, dungeonDoorSouth.Height) };
            return new Sprite(dungeonDoorSouth, rectangles, spriteBatch, position, Constants.DOOR_LAYER_DEPTH);
        }

        public Sprite DungeonDoorEast(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonDoorEast.Width, dungeonDoorEast.Height) };
            return new Sprite(dungeonDoorEast, rectangles, spriteBatch, position, Constants.DOOR_LAYER_DEPTH);
        }

        public Sprite DungeonDoorWest(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonDoorWest.Width, dungeonDoorWest.Height) };
            return new Sprite(dungeonDoorWest, rectangles, spriteBatch, position, Constants.DOOR_LAYER_DEPTH);
        }

        public Sprite DungeonBadDoorNorth(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonBadDoorNorth.Width, dungeonBadDoorNorth.Height) };
            return new Sprite(dungeonBadDoorNorth, rectangles, spriteBatch, position, Constants.DOOR_LAYER_DEPTH);
        }

        public Sprite DungeonBadDoorSouth(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonBadDoorSouth.Width, dungeonBadDoorSouth.Height) };
            return new Sprite(dungeonBadDoorSouth, rectangles, spriteBatch, position, Constants.DOOR_LAYER_DEPTH);
        }

        public Sprite DungeonSand(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonSand.Width, dungeonSand.Height) };
            return new Sprite(dungeonSand, rectangles, spriteBatch, position, Constants.BACKGROUND_BLOCK_LAYER_DEPTH);
        }

        public Sprite DungeonAbyss(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonAbyss.Width, dungeonAbyss.Height) };
            return new Sprite(dungeonAbyss, rectangles, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }

        public Sprite DungeonStairs(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonStairs.Width, dungeonStairs.Height) };
            return new Sprite(dungeonStairs, rectangles, spriteBatch, position, Constants.DOOR_LAYER_DEPTH);
        }

        public Sprite WaterBlock(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, waterBlock.Width, waterBlock.Height) };
            return new Sprite(waterBlock, rectangles, spriteBatch, position, Constants.BACKGROUND_BLOCK_LAYER_DEPTH);
        }

        /*
         * Link running
         */
        public Sprite LinkRunningRight(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningRight, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkRunningLeft(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningLeft, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }
        public Sprite LinkRunningUp(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningUp, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkRunningDown(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningDown, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        /*
         * Link standing
         */
        public Sprite LinkStandingRight(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingRight, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkStandingLeft(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingLeft, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkStandingUp(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingUp, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkStandingDown(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingDown, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        /*
         * Link running damaged
         */
        public Sprite LinkRunningRightDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningRightDamaged, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkRunningLeftDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningLeftDamaged, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }
        public Sprite LinkRunningUpDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningUpDamaged, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkRunningDownDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkRunningDownDamaged, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        /*
         * Link standing and damaged
         */
        public Sprite LinkStandingRightDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingRightDamaged, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkStandingLeftDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingLeftDamaged, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkStandingUpDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingUpDamaged, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkStandingDownDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkStandingDownDamaged, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        /*
         * Link attacking and damaged
         */
        public Sprite LinkAttackingRightDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingRightDamaged, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkAttackingLeftDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingLeftDamaged, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkAttackingUpDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingUpDamaged, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkAttackingDownDamaged(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingDownDamaged, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        /*
         * Link attacking
         */
        public Sprite LinkAttackingRight(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingRight, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkAttackingLeft(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingLeft, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkAttackingUp(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingUp, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkAttackingDown(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkAttackingDown, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        /*
         * Link throwing an arrow.
         * TODO: not sure if this sheet contains Link throwing an arrow...
         */
        public Sprite LinkThrowingUp(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkThrowingUp, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkThrowingDown(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkThrowingDown, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkThrowingLeft(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkThrowingLeft, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite LinkThrowingRight(Vector2 position)
        {
            return new Sprite(linkSpritesheet, SpriteRectangle.LinkThrowingRight, spriteBatch, position, Constants.PLAYER_LAYER_DEPTH);
        }

        public Sprite ZeldaGreen(Vector2 position)
        {
            return new Sprite(GreenBlock, BlockRectangle.NormalBlock, spriteBatch, position, Constants.BLOCK_LAYER_DEPTH);
        }

        public Sprite ZeldaBlack(Vector2 position)
        {
            return new Sprite(BlackBlock, BlockRectangle.NormalBlock, spriteBatch, position, Constants.BLOCK_LAYER_DEPTH);
        }

        public Sprite ZeldaPurple(Vector2 position)
        {
            return new Sprite(PurpleBlock, BlockRectangle.NormalBlock, spriteBatch, position, Constants.BLOCK_LAYER_DEPTH);
        }

        /*
         * Dungeon Creator
         */
        public Sprite GridSquare(Vector2 position)
        {
            Sprite grid = new Sprite(GridSquareBlock, BlockRectangle.NormalBlock, spriteBatch, position, Constants.BACKGROUND_BLOCK_LAYER_DEPTH);
            grid.objectKind = "GridSquare";
            return grid;
        }

        public Sprite SaveIcon(Vector2 position)
        {
            Sprite save = new Sprite(SaveIconBlock, BlockRectangle.NormalBlock, spriteBatch, position, Constants.BLOCK_LAYER_DEPTH);
            save.objectKind = "SaveIcon";
            return save;
        }

        public Sprite BlockText(Vector2 position)
        {
            return new Sprite(LevelCreatorTextBlock, BlockRectangle.NormalBlock, spriteBatch, position, Constants.BACKGROUND_BLOCK_LAYER_DEPTH);
        }

        /*
         * Items
         */
        public Sprite ZeldaBlueCandle(Vector2 position)
        {
            return new Sprite(BlueCandle, ItemRectangle.Candle, spriteBatch, position, Constants.ITEM_LAYER_DEPTH);
        }

        public Sprite ZeldaSword(Vector2 position)
        {
            return new Sprite(HUD, ItemRectangle.Sword, spriteBatch, position, Constants.ITEM_LAYER_DEPTH);
        }

        public Sprite ZeldaBomb(Vector2 position)
        {
            return new Sprite(Bomb, ItemRectangle.Bomb, spriteBatch, position, Constants.PROJECTILE_LAYER_DEPTH);
        }

        public Sprite ZeldaBoomerang(Vector2 position)
        {
            return new Sprite(Boomerang, ItemRectangle.Boomerang, spriteBatch, position, Constants.PROJECTILE_LAYER_DEPTH);
        }

        public Sprite ZeldaBow(Vector2 position)
        {
            return new Sprite(Bow, ItemRectangle.BowArrowUp, spriteBatch, position, Constants.ITEM_LAYER_DEPTH); // TODO: BowArrow to BowArrowUp?
        }

        public Sprite ZeldaClock(Vector2 position)
        {
            return new Sprite(Clock, ItemRectangle.Clock, spriteBatch, position, Constants.ITEM_LAYER_DEPTH);
        }

        public Sprite ZeldaCompass(Vector2 position)
        {
            return new Sprite(Compass, ItemRectangle.Compass, spriteBatch, position, Constants.ITEM_LAYER_DEPTH);
        }

        public Sprite ZeldaFairy(Vector2 position)
        {
            return new Sprite(Fairy, ItemRectangle.Fairy, spriteBatch, position, Constants.ITEM_LAYER_DEPTH);
        }

        public Sprite ZeldaFood(Vector2 position)
        {
            return new Sprite(Food, ItemRectangle.Food, spriteBatch, position, Constants.ITEM_LAYER_DEPTH);
        }

        public Sprite ZeldaHeart(Vector2 position)
        {
            return new Sprite(Heart, ItemRectangle.Heart, spriteBatch, position, Constants.ITEM_LAYER_DEPTH);
        }

        public Sprite ZeldaHeartContainer(Vector2 position)
        {
            return new Sprite(HeartContainer, ItemRectangle.HeartContainer, spriteBatch, position, Constants.ITEM_LAYER_DEPTH);
        }

        public Sprite ZeldaKey(Vector2 position)
        {
            return new Sprite(Key, ItemRectangle.Key, spriteBatch, position, Constants.ITEM_LAYER_DEPTH);
        }

        public Sprite ZeldaLetter(Vector2 position)
        {
            return new Sprite(Letter, ItemRectangle.Letter, spriteBatch, position, Constants.ITEM_LAYER_DEPTH);
        }

        public Sprite ZeldaTriforce(Vector2 position)
        {
            return new Sprite(Triforce, ItemRectangle.Triforce, spriteBatch, position, Constants.ITEM_LAYER_DEPTH);
        }

        public Sprite ZeldaRock(Vector2 position)
        {
            return new Sprite(enemiesSpritesheet, ProjectileRectangle.Rock, spriteBatch, position, Constants.PROJECTILE_LAYER_DEPTH);
        }

        public Sprite ZeldaFire(Vector2 position)
        {
            return new Sprite(enemiesSpritesheet, ProjectileRectangle.Fire, spriteBatch, position, Constants.ENEMY_LAYER_DEPTH);
        }

        public Sprite ZeldaDragonProj(Vector2 position)
        {
            return new Sprite(Dragon, ProjectileRectangle.DragonProjectile, spriteBatch, position, Constants.PROJECTILE_LAYER_DEPTH);
        }

        /*
         * Enemies
         */
        public Sprite ZeldaOldMan(Vector2 position)
        {
            return new Sprite(OldMan, EnemyRectangle.ZeldaOldMan, spriteBatch, position, Constants.BACKGROUND_BLOCK_LAYER_DEPTH);
        }

        public Sprite ZeldaDragon(Vector2 position)
        {
            return new Sprite(Dragon, EnemyRectangle.Dragon, spriteBatch, position, Constants.ENEMY_LAYER_DEPTH);
        }

        public Sprite Stalfos(Vector2 position)
        {
            return new Sprite(enemiesSpritesheet, EnemyRectangle.Stalfos, spriteBatch, position, Constants.ENEMY_LAYER_DEPTH);
        }

        public Sprite Keese(Vector2 position)
        {
            return new Sprite(enemiesSpritesheet, EnemyRectangle.Keese, spriteBatch, position, Constants.ENEMY_LAYER_DEPTH);
        }

        public Sprite GoriyaLeft(Vector2 position)
        {
            Sprite result = new Sprite(enemiesSpritesheet, EnemyRectangle.GoriyaLeft, spriteBatch, position, Constants.ENEMY_LAYER_DEPTH);
            result.Direction = Direction.LEFT;
            return result;
        }

        public Sprite GoriyaRight(Vector2 position)
        {
            Sprite result = new Sprite(enemiesSpritesheet, EnemyRectangle.GoriyaRight, spriteBatch, position, Constants.ENEMY_LAYER_DEPTH);
            result.Direction = Direction.RIGHT;
            return result;
        }

        public Sprite GoriyaUp(Vector2 position)
        {
            Sprite result = new Sprite(enemiesSpritesheet, EnemyRectangle.GoriyaUp, spriteBatch, position, Constants.ENEMY_LAYER_DEPTH);
            result.Direction = Direction.UP;
            return result;
        }

        public Sprite GoriyaDown(Vector2 position)
        {
            Sprite result = new Sprite(enemiesSpritesheet, EnemyRectangle.GoriyaDown, spriteBatch, position, Constants.ENEMY_LAYER_DEPTH);
            result.Direction = Direction.DOWN;
            return result;
        }

        public Sprite Gel(Vector2 position)
        {
            return new Sprite(enemiesSpritesheet, EnemyRectangle.Gel, spriteBatch, position, Constants.ENEMY_LAYER_DEPTH);
        }

        public Sprite Octorok(Vector2 position)
        {
            return new Sprite(enemiesSpritesheet, EnemyRectangle.Octorok, spriteBatch, position, Constants.ENEMY_LAYER_DEPTH);
        }

        public Sprite DungeonMonster1(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonMonster1.Width, dungeonMonster1.Height) };
            return new Sprite(dungeonMonster1, rectangles, spriteBatch, position, Constants.BLOCK_LAYER_DEPTH);
        }

        public Sprite DungeonMonster2(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonMonster2.Width, dungeonMonster2.Height) };
            return new Sprite(dungeonMonster2, rectangles, spriteBatch, position, Constants.BLOCK_LAYER_DEPTH);
        }

        public Sprite DungeonMonster1Faded(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonMonster1Faded.Width, dungeonMonster1Faded.Height) };
            return new Sprite(dungeonMonster1Faded, rectangles, spriteBatch, position, Constants.BLOCK_LAYER_DEPTH);
        }

        public Sprite DungeonMonster2Faded(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, dungeonMonster2Faded.Width, dungeonMonster2Faded.Height) };
            return new Sprite(dungeonMonster2Faded, rectangles, spriteBatch, position, Constants.BLOCK_LAYER_DEPTH);
        }

        // TODO: dictionary with key as direction for these
        public Sprite ZeldaArrowUp(Vector2 position)
        {
            return new Sprite(Arrow, ItemRectangle.BowArrowUp, spriteBatch, position, Constants.PROJECTILE_LAYER_DEPTH);
        }

        public Sprite ZeldaArrowDown(Vector2 position)
        {
            return new Sprite(Arrow, ItemRectangle.BowArrowDown, spriteBatch, position, Constants.PROJECTILE_LAYER_DEPTH);
        }

        public Sprite ZeldaArrowLeft(Vector2 position)
        {
            return new Sprite(Arrow, ItemRectangle.BowArrowLeft, spriteBatch, position, Constants.PROJECTILE_LAYER_DEPTH);
        }

        public Sprite ZeldaArrowRight(Vector2 position)
        {
            return new Sprite(Arrow, ItemRectangle.BowArrowRight, spriteBatch, position, Constants.PROJECTILE_LAYER_DEPTH);
        }

        public Sprite ZeldaProjectileEffect(Vector2 position)
        {
            return new Sprite(ProjectileEffect, SpriteRectangle.ProjectileEffect, spriteBatch, position, Constants.PROJECTILE_LAYER_DEPTH);
        }

        /*
         * HUD
         */
        public Sprite ZeldaCurrProjectile(Vector2 position)
        {
            return new Sprite(HUD, SpriteRectangle.ZeldaCurrProjectile, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }

        public Sprite ZeldaAvailableProjectiles(Vector2 position)
        {
            return new Sprite(HUD, SpriteRectangle.ZeldaAvailProjectiles, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }
        public Sprite ZeldaMapAndCompassHUD(Vector2 position)
        {
            return new Sprite(HUD, SpriteRectangle.ZeldaMapAndCompassHUD, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }

        public Sprite ZeldaMapHUD(Vector2 position)
        {
            return new Sprite(HUD, SpriteRectangle.ZeldaMapHUD, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }

        public Sprite ZeldaOrangeBlockHUD(Vector2 position)
        {
            return new Sprite(HUD, SpriteRectangle.ZeldaOrangeBlockHUD, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }

        public Sprite ZeldaRupy(Vector2 position)
        {
            return new Sprite(Rupy, ItemRectangle.ZeldaRupy, spriteBatch, position, Constants.ITEM_LAYER_DEPTH);
        }

        public Sprite ZeldaInventoryHUD(Vector2 position)
        {
            return new Sprite(HUD, SpriteRectangle.ZeldaInventoryHUD, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }

        public Sprite ZeldaLevelHUD(Vector2 position)
        {
            return new Sprite(HUD, SpriteRectangle.ZeldaLevelHUD, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }

        public Sprite ZeldaNumOneHUD(Vector2 position)
        {
            return new Sprite(HUD, SpriteRectangle.ZeldaNumOneHUD, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }

        public Sprite ZeldaBlueMapHUD(Vector2 position)
        {
            return new Sprite(ZeldaBlueMap, SpriteRectangle.ZeldaBlueMapHUD, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }

        public Sprite ZeldaOrangeMapHUD(Vector2 position)
        {
            return new Sprite(ZeldaOrangeMap, SpriteRectangle.ZeldaOrangeMapHUD, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }

        public Sprite ZeldaBlueBox(Vector2 position)
        {
            return new Sprite(HUD, SpriteRectangle.ZeldaBlueBox, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }

        /* inventory */
        public Sprite TopHUD(Vector2 position)
        {
            return new Sprite(TopHud, InventoryRectangle.TopHUD, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }
        public Sprite FullHeart(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, Fullheart.Width, Fullheart.Height) };
            return new Sprite(Fullheart, rectangles, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }
        public Sprite HalfHeart(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, Halfheart.Width, Halfheart.Height) };
            return new Sprite(Halfheart, rectangles, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }
        public Sprite EmptyHeart(Vector2 position)
        {
            Rectangle[] rectangles = new Rectangle[] { new Rectangle(0, 0, Emptyheart.Width, Emptyheart.Height) };
            return new Sprite(Emptyheart, rectangles, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }

        public Sprite Logo(Vector2 position)
        {
            return new Sprite(logo, SpriteRectangle.Logo, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }

        public Sprite BluePixels(Vector2 position)
        {
            return new Sprite(MapBlocks, SpriteRectangle.BluePixels, spriteBatch, position, Constants.BACKGROUND_LAYER_DEPTH);
        }

        public Sprite GreenPixel(Vector2 position)
        {
            return new Sprite(MapBlocks, SpriteRectangle.GreenPixel, spriteBatch, position, Constants.BACKGROUND_BLOCK_LAYER_DEPTH);
        }

        public Sprite RedPixel(Vector2 position)
        {
            return new Sprite(MapBlocks, SpriteRectangle.RedPixel, spriteBatch, position, Constants.BACKGROUND_BLOCK_LAYER_DEPTH);
        }
    }
}
