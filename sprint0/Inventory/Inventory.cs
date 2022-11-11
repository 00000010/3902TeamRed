using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class Inventory : IInventory, IObject
    {
        protected Game1 game { get; set; }
        public Sprite Sprite { get; set; } //hud
        public Sprite Sword { get; set; } //A item
        public TypeOfProj CurrentItem { get; set; }
        public Item[] ItemList { get; set; }
        public Sprite[] HealthSprite { get; set; } //the hearts (sprites change based on damage)
        public TextSprite CoinTextSprite { get; set; }
        public TextSprite KeyTextSprite { get; set; }
        public TextSprite BoomerangTextSprite { get; set; }
        public Sprite ZeldaLevelWord { get; set; }
        public Sprite ZeldaNumOne { get; set; }
        public Sprite ZeldaBlueMap { get; set; }
        public Vector2 Position { get { return Sprite.Position; } set { Sprite.Position = value; } }
        public Vector2 Velocity { get; set; }

        public int Coins { get; set; }
        public int Keys { get; set; }
        public int Boomerangs { get; set; }
        public int HalfHearts { get; set; }

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public Inventory() { }

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            CurrentItem = game.manager.LinkProjectile;
        }

        public virtual void Draw(GameTime gameTime)
        {
            if (game.loader.currentRoom.name.Equals("RoomInventory")) return;
            Sprite.Draw(gameTime);
            Sword.Draw(gameTime);

            //add logic here if type of CurrentItem == zeldaboomerang and boomerangs > 0 then draw it on top of slot B
            GenerateTextSprites();
            CoinTextSprite.Draw(gameTime);
            KeyTextSprite.Draw(gameTime);
            BoomerangTextSprite.Draw(gameTime);
            ZeldaNumOne.Draw(gameTime);
            ZeldaLevelWord.Draw(gameTime);
            ZeldaBlueMap.Draw(gameTime);

            foreach (Sprite heart in HealthSprite)
            {
                heart.Draw(gameTime);
            }
            Vector2 ArrowPosition = new Vector2(410, 55);
            Vector2 FirePosition = new Vector2(400, 58);
            Vector2 BoomerangPosition = new Vector2(410, 65);
            if (CurrentItem == TypeOfProj.ARROW)
            {
                SpriteFactory.Instance.ZeldaArrowUp(ArrowPosition).Draw(gameTime);
            }
            else if (CurrentItem == TypeOfProj.BOOMERANG)
            {
                SpriteFactory.Instance.ZeldaBoomerang(BoomerangPosition).Draw(gameTime);
            }
            else if (CurrentItem == TypeOfProj.FIRE)
            {
                SpriteFactory.Instance.ZeldaFire(FirePosition).Draw(gameTime);
            }
        }

        public void UpdateHealth(int CurrentHealth)  //only used for damaging link
        {
            int MissingHealth = 100 - CurrentHealth;    //might need to change 100 to maximum health of link rather than tie it to 100

            int i = HalfHearts - 1;
            while (MissingHealth >= 0)
            {
                MissingHealth -= 10;
                Vector2 position = HealthSprite[i / 2].Position;
                if (MissingHealth >= 0)
                {
                    if (i % 2 != 0) //we remove half heart 
                    {
                        HealthSprite[i / 2] = SpriteFactory.Instance.HalfHeart(position);
                    }
                    else //we remove full heart
                    {
                        HealthSprite[i / 2] = SpriteFactory.Instance.EmptyHeart(position);
                    }
                }
                i--;
            }

        }
        public void FillHearts()
        {
            Vector2 position = Vector2.Zero;
            for (int i = 0; i < HealthSprite.Length; i++)
            {
                position = HealthSprite[i].Position;
                HealthSprite[i] = SpriteFactory.Instance.FullHeart(position);
            }
        }


        private void GenerateTextSprites()
        {
            /*text sprite for coin, key, bomb at different positions*/
            CoinTextSprite = TextSpriteFactory.Instance.ItemText(new Vector2(350, 45));
            KeyTextSprite = TextSpriteFactory.Instance.ItemText(new Vector2(350, 70));
            BoomerangTextSprite = TextSpriteFactory.Instance.ItemText(new Vector2(350, 100));

            /*text will be the int value for coin, key, bomb*/
            CoinTextSprite.Text = Coins.ToString();
            KeyTextSprite.Text = Keys.ToString();
            BoomerangTextSprite.Text = Boomerangs.ToString();

        }
    }
}