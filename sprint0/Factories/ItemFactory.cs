using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Rectangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Factories
{
    public class ItemFactory
    {
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
        private Texture2D Map;
        private Texture2D Recorder;
        private Texture2D Raft;
        private Texture2D Rupy;
        private Texture2D RedRing;
        private Texture2D BlueRing;
        private Texture2D Sword;
        private Texture2D Stepladder;
        private Texture2D FiveRupy;
        private Texture2D WhiteSword;
        private Texture2D Triforce;
        private static ItemFactory instance = new ItemFactory();
        public static ItemFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private ItemFactory() { }
        public void LoadTextures(ContentManager content)
        {
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
            Map = content.Load<Texture2D>("ZeldaSpriteMap");
            Recorder = content.Load<Texture2D>("ZeldaSpriteRecorder");
            Raft = content.Load<Texture2D>("ZeldaSpriteRaft");
            Rupy = content.Load<Texture2D>("ZeldaSpriteRupy");
            RedRing = content.Load<Texture2D>("ZeldaSpriteRedRing");
            BlueRing = content.Load<Texture2D>("ZeldaSpriteBlueRing");
            Sword = content.Load<Texture2D>("ZeldaSpriteSword");
            Stepladder = content.Load<Texture2D>("ZeldaSpriteStepladder");
            FiveRupy = content.Load<Texture2D>("ZeldaSprite5Rupies");
            WhiteSword = content.Load<Texture2D>("ZeldaSpriteWhiteSword");
            Triforce = content.Load<Texture2D>("ZeldaSpriteTriforce");
        }

        public List<Sprite> getAllItems(SpriteBatch _spriteBatch)
        {
            List<Sprite> items = new List<Sprite>();
            items.Add(ItemFactory.Instance.ZeldaArrow(_spriteBatch, new Vector2(200, 200)));
            items.Add(ItemFactory.Instance.ZeldaBow(_spriteBatch, new Vector2(200, 200)));
            items.Add(ItemFactory.Instance.ZeldaBlueCandle(_spriteBatch, new Vector2(200, 200)));
            items.Add(ItemFactory.Instance.ZeldaBomb(_spriteBatch, new Vector2(200, 200)));
            items.Add(ItemFactory.Instance.ZeldaBoomerang(_spriteBatch, new Vector2(200, 200)));
            items.Add(ItemFactory.Instance.ZeldaClock(_spriteBatch, new Vector2(200, 200)));
            items.Add(ItemFactory.Instance.ZeldaCompass(_spriteBatch, new Vector2(200, 200)));
            items.Add(ItemFactory.Instance.ZeldaFairy(_spriteBatch, new Vector2(200, 200)));
            items.Add(ItemFactory.Instance.ZeldaFood(_spriteBatch, new Vector2(200, 200)));
            items.Add(ItemFactory.Instance.ZeldaHeart(_spriteBatch, new Vector2(200, 200)));
            items.Add(ItemFactory.Instance.ZeldaHeartContainer(_spriteBatch, new Vector2(200, 200)));
            items.Add(ItemFactory.Instance.ZeldaKey(_spriteBatch, new Vector2(200, 200)));
            items.Add(ItemFactory.Instance.ZeldaLetter(_spriteBatch, new Vector2(200, 200)));
            return items;
        }

        public Item ZeldaArrow(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item arrow = new Item(Arrow, ItemRectangle.BowArrow, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(arrow);
            }
            return arrow;
        }

        public Item ZeldaBlueCandle(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item candle = new Item(BlueCandle, ItemRectangle.Candle, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(candle);
            }
            return candle;
        }

        public Item ZeldaBomb(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item bomb = new Item(Bomb, ItemRectangle.Bomb, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(bomb);
            }
            return bomb;
        }

        public Item ZeldaBoomerang(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item boomerang = new Item(Boomerang, ItemRectangle.Boomerang, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(boomerang);
            }
            return boomerang;
        }

        public Item ZeldaBow(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item bow = new Item(Bow, ItemRectangle.BowArrow, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(bow);
            }
            return bow;
        }

        public Item ZeldaClock(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item clock = new Item(Clock, ItemRectangle.Clock, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(clock);
            }
            return clock;
        }

        public Item ZeldaCompass(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item compass = new Item(Compass, ItemRectangle.Compass, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(compass);
            }
            return compass;
        }

        public Item ZeldaFairy(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item fairy = new Item(Fairy, ItemRectangle.Fairy, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(fairy);
            }
            return fairy;
        }

        public Item ZeldaFood(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item food = new Item(Food, ItemRectangle.Food, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(food);
            }
            return food;
        }

        public Item ZeldaHeart(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item heart = new Item(Heart, ItemRectangle.Heart, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(heart);
            }
            return heart;
        }

        public Item ZeldaHeartContainer(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item heartContainer = new Item(HeartContainer, ItemRectangle.HeartContainer, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(heartContainer);
            }
            return heartContainer;
        }

        public Item ZeldaKey(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item key = new Item(Key, ItemRectangle.Key, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(key);
            }
            return key;
        }

        public Item ZeldaLetter(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item letter = new Item(Letter, ItemRectangle.Letter, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(letter);
            }
            return letter;
        }
        public Item ZeldaMap(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item map = new Item(Map, ItemRectangle.Letter, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(map);
            }
            return map;
        }
        public Item ZeldaRecorder(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item recorder = new Item(Recorder, ItemRectangle.Recorder, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(recorder);
            }
            return recorder;
        }
        public Item ZeldaRaft(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item raft = new Item(Raft, ItemRectangle.Raft, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(raft);
            }
            return raft;
        }
        public Item ZeldaRupy(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item rupy = new Item(Rupy, ItemRectangle.Rupy, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(rupy);
            }
            return rupy;
        }
        public Item ZeldaRedRing(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item redring = new Item(RedRing, ItemRectangle.Ring, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(redring);
            }
            return redring;
        }
        public Item ZeldaBlueRing(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item bluering = new Item(BlueRing, ItemRectangle.Ring, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(bluering);
            }
            return bluering;
        }
        public Item ZeldaBlueSword(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item sword = new Item(Sword, ItemRectangle.Sword, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(sword);
            }
            return sword;
        }
        public Item ZeldaBlueStepladder(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item stepladder = new Item(Stepladder, ItemRectangle.StepLadder, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(stepladder);
            }
            return stepladder;
        }
        public Item ZeldaFiveRupy(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item fiverupy = new Item(FiveRupy, ItemRectangle.Rupy, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(fiverupy);
            }
            return fiverupy;
        }
        public Item ZeldaWhiteSword(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item whitesword = new Item(WhiteSword, ItemRectangle.Sword, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(whitesword);
            }
            return whitesword;
        }
        public Item ZeldaTriforce(SpriteBatch spriteBatch, Vector2 position, GameObjectManager manager = null)
        {
            Item triforce = new Item(Triforce, ItemRectangle.Triforce, spriteBatch, position);
            if (manager != null)
            {
                manager.addItem(triforce);
            }
            return triforce;
        }
    }
}