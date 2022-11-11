using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.AccessControl;
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
            return new TopHud(game);
        }
        internal class TopHud : Inventory
        {
            public TopHud(Game1 game)
            {
                this.game = game;

                /* the top hud without the numbers*/
                Sprite = SpriteFactory.Instance.TopHUD(new Vector2(150, 10));
                Velocity = Vector2.Zero;

                CurrentItem = TypeOfProj.ARROW;

                /* Sword will always be available so it is drawn in the hud*/
                Sword = SpriteFactory.Instance.ZeldaSword(new Vector2(455, 55));

                /*array of sprites of hearts to be drawn side to side it can either be a full heart, a half heart, or an empty heart*/
                Sprite[] AllHearts = { SpriteFactory.Instance.FullHeart(new Vector2(520, 65)), SpriteFactory.Instance.FullHeart(new Vector2(535, 65)),
                        SpriteFactory.Instance.FullHeart(new Vector2(550, 65)),SpriteFactory.Instance.FullHeart(new Vector2(565, 65)),
                            SpriteFactory.Instance.FullHeart(new Vector2(580, 65))};
                HealthSprite = AllHearts;


                /*the number of half hearts will be the number of hearts times 2 (might be needed to use with player health)*/
                HalfHearts = HealthSprite.Length * 2;

                /*coins,bombs,keys initialzed to 0*/
                Coins = 0;
                Keys = 0;
                Boomerangs = 0;

                ZeldaNumOne = SpriteFactory.Instance.ZeldaNumOneHUD(new Vector2(160, 25));
                ZeldaBlueMap = SpriteFactory.Instance.ZeldaBlueMapHUD(new Vector2(90, 40));
                ZeldaLevelWord = SpriteFactory.Instance.ZeldaLevelHUD(new Vector2(70, 25));
            }
        }
    }
}
