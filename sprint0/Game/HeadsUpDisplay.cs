using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Game
{
    public class HeadsUpDisplay : IHeadsUpDisplay
    {
        public Sprite gem;
        public Sprite key;
        public Sprite bomb;

        private TextSprite gemCount;
        private TextSprite keyCount;
        private TextSprite bombCount;

        private TextSprite lifeText;
        private TextSprite life;

        private GameObjectManager manager;
        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public HeadsUpDisplay(GameObjectManager manager)
        {
            this.manager = manager;
            key = SpriteFactory.Instance.ZeldaKey(new Vector2(360, 188));
            bomb = SpriteFactory.Instance.ZeldaBomb(new Vector2(360, 200));

            keyCount = SpriteFactory.Instance.Number(new Vector2(370, 188), 20, Color.White);
            bombCount = SpriteFactory.Instance.Number(new Vector2(370, 200), 0, Color.White);

            lifeText = SpriteFactory.Instance.Text(new Vector2(450, 180), "-LIFE-", Color.Red);
            life = SpriteFactory.Instance.Number(new Vector2(450, 200), manager.player.Health, Color.Red);

        }

        public void Draw(GameTime gameTime)
        {
            //gem.Draw(gameTime);

            key.Draw(gameTime);
            bomb.Draw(gameTime);

            keyCount.Draw(gameTime);
            bombCount.Draw(gameTime);

            lifeText.Draw(gameTime);

            if (life != null)
            {
                life.Draw(gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (manager.player != null)
            {
                life = SpriteFactory.Instance.Number(new Vector2(450, 200), manager.player.Health, Color.Red);
            }
        }
    }
}
