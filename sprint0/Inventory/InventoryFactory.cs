using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class InventoryFactory
    {
        private static InventoryFactory instance = new InventoryFactory();
        public static InventoryFactory Instance { get { return instance; } }

        private InventoryFactory() { }

        public Inventory TopHUD(Game1 game)
        {
            Inventory inventory = new TopHud(game);
            return inventory;
        }
        internal class TopHud : Inventory
        {
            public TopHud(Game1 game)
            {
                this.game = game;

                int offsetX = 100;
                int offsetY = 150;

                /* the top hud without the numbers*/
                Sprite = SpriteFactory.Instance.TopHUD(new Vector2(250 - offsetX, 160 - offsetY));
                Velocity = Vector2.Zero;

                /* Sword will always be available so it is drawn in the hud selecteditem will be null*/
                Sword = SpriteFactory.Instance.ZeldaSword(new Vector2(403 - offsetX, 184 - offsetY));

                /*array of sprites of hearts to be drawn side to side it can either be a full heart, a half heart, or an empty heart*/
                Sprite[] AllHearts = { SpriteFactory.Instance.FullHeart(new Vector2(425- offsetX, 189 - offsetY)), SpriteFactory.Instance.FullHeart(new Vector2(433 - offsetX, 189- offsetY)),
                        SpriteFactory.Instance.FullHeart(new Vector2(441 - offsetX, 189 - offsetY)),SpriteFactory.Instance.FullHeart(new Vector2(449 - offsetX, 189 - offsetY)),
                            SpriteFactory.Instance.FullHeart(new Vector2(457- offsetX, 189 - offsetY))};
                HealthSprite = AllHearts;


                /*the number of half hearts will be the number of hearts times 2 (might be needed to use with player health)*/
                HalfHearts = HealthSprite.Length * 2;

                /*coins,bombs,keys initialzed to 0*/
                Coins = 0;
                Keys = 0;
                Boomerangs = 0;

                /*text sprite for coin, key, bomb at different positions*/
                CoinTextSprite = TextSpriteFactory.Instance.ItemText(new Vector2(350 - offsetX, 173 - offsetY));
                KeyTextSprite = TextSpriteFactory.Instance.ItemText(new Vector2(350 - offsetX, 189 - offsetY));
                BoomerangTextSprite = TextSpriteFactory.Instance.ItemText(new Vector2(350 - offsetX, 201 - offsetY));

                /*text will be the int value for coin, key, bomb*/
                CoinTextSprite.Text = Coins.ToString();
                KeyTextSprite.Text = Keys.ToString();
                BoomerangTextSprite.Text = Boomerangs.ToString();
            }
        }
    }
}
