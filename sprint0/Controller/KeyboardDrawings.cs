using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class KeyboardDrawings : IUpdateable, IDrawable
    {
        protected Game1 game { get; set; }
        public Sprite Sprite { get; set; }
        public TextSprite UpSprite { get; set; }
        public TextSprite DownSprite { get; set; }
        public TextSprite LeftSprite { get; set; }
        public TextSprite RightSprite { get; set; }
        public TextSprite ShootSprite { get; set; }
        public TextSprite StabSprite { get; set; }
        public TextSprite NextProjSprite { get; set; }
        public TextSprite PrevProjSprite { get; set; }
        public TextSprite ShowInventorySprite { get; set; }
        public TextSprite HideInventorySprite { get; set; }
        public TextSprite PauseSprite { get; set; }
        public TextSprite ResumeSprite { get; set; }
        public TextSprite RestartSprite { get; set; }
        public TextSprite ExitSprite { get; set; }
        public bool Enabled => throw new NotImplementedException();
        public int UpdateOrder => throw new NotImplementedException();
        public int DrawOrder => throw new NotImplementedException();
        public bool Visible => throw new NotImplementedException();

        public KeyboardDrawings(Game1 game) {
            this.game = game;
        }

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public virtual void Update(GameTime gameTime)
        {
            //no-op
        }

        public virtual void Draw(GameTime gameTime)
        {
            if (!game.loader.currentRoom.name.Equals("RoomControls")) return;

            GenerateTextSprites();
            PauseSprite.Draw(gameTime);
            ResumeSprite.Draw(gameTime);
            RestartSprite.Draw(gameTime);
            PrevProjSprite.Draw(gameTime);
            NextProjSprite.Draw(gameTime);
            UpSprite.Draw(gameTime);
            DownSprite.Draw(gameTime);
            LeftSprite.Draw(gameTime);
            RightSprite.Draw(gameTime);
            ShootSprite.Draw(gameTime);
            StabSprite.Draw(gameTime);
            ExitSprite.Draw(gameTime);
            ShowInventorySprite.Draw(gameTime);
            HideInventorySprite.Draw(gameTime);
        }

        private void GenerateTextSprites()
        {
            PauseSprite = TextSpriteFactory.Instance.ItemTextSmaller(new Vector2(45, 95));
            ResumeSprite = TextSpriteFactory.Instance.ItemTextSmaller(new Vector2(45, 195));
            RestartSprite = TextSpriteFactory.Instance.ItemTextSmaller(new Vector2(45, 295));

            PrevProjSprite = TextSpriteFactory.Instance.ItemTextSmaller(new Vector2(225, 95));
            NextProjSprite = TextSpriteFactory.Instance.ItemTextSmaller(new Vector2(225, 195));
            UpSprite = TextSpriteFactory.Instance.ItemTextSmaller(new Vector2(225, 295));
            DownSprite = TextSpriteFactory.Instance.ItemTextSmaller(new Vector2(225, 395));

            LeftSprite = TextSpriteFactory.Instance.ItemTextSmaller(new Vector2(425, 95));
            RightSprite = TextSpriteFactory.Instance.ItemTextSmaller(new Vector2(425, 195));
            ShootSprite = TextSpriteFactory.Instance.ItemTextSmaller(new Vector2(425, 295));
            StabSprite = TextSpriteFactory.Instance.ItemTextSmaller(new Vector2(425, 395));

            ExitSprite = TextSpriteFactory.Instance.ItemTextSmaller(new Vector2(625, 95));
            ShowInventorySprite = TextSpriteFactory.Instance.ItemTextSmaller(new Vector2(625, 195));
            HideInventorySprite = TextSpriteFactory.Instance.ItemTextSmaller(new Vector2(625, 295));

            PauseSprite.Text = game.keyboard.GetKey(KeyboardAction.PAUSE).ToString();
            ResumeSprite.Text = game.keyboard.GetKey(KeyboardAction.RESUME).ToString();
            RestartSprite.Text = game.keyboard.GetKey(KeyboardAction.RESTART).ToString();
            
            PrevProjSprite.Text = game.keyboard.GetKey(KeyboardAction.PREVPROJECTILE).ToString();
            NextProjSprite.Text = game.keyboard.GetKey(KeyboardAction.NEXTPROJECTILE).ToString();
            UpSprite.Text = game.keyboard.GetKey(KeyboardAction.UP).ToString();
            DownSprite.Text = game.keyboard.GetKey(KeyboardAction.DOWN).ToString();

            LeftSprite.Text = game.keyboard.GetKey(KeyboardAction.LEFT).ToString();
            RightSprite.Text = game.keyboard.GetKey(KeyboardAction.RIGHT).ToString();
            ShootSprite.Text = game.keyboard.GetKey(KeyboardAction.SHOOT).ToString();
            StabSprite.Text = game.keyboard.GetKey(KeyboardAction.STAB).ToString();

            ExitSprite.Text = game.keyboard.GetKey(KeyboardAction.EXIT).ToString();
            ShowInventorySprite.Text = game.keyboard.GetKey(KeyboardAction.SHOWINVENTORY).ToString();
            HideInventorySprite.Text = game.keyboard.GetKey(KeyboardAction.HIDEINVENTORY).ToString();
        }
    }
}