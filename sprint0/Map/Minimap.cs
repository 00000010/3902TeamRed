using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class Minimap : IDrawable, IUpdateable
    {
        private Game1 game;
        public List<Sprite> map = new List<Sprite>();


        private Vector2 origin = new Vector2(Constants.MAP_ORIGIN_X, Constants.MAP_ORIGIN_Y);
        private Vector2 textLocation = new Vector2(Constants.MAP_TEXT_X, Constants.MAP_TEXT_Y);
        private Vector2 centerVector = new Vector2(Constants.CENTER_VECTOR_X, Constants.CENTER_VECTOR_Y);
        private TextSprite title;
        public string mapTitle;

        public Sprite playerPixel;
        public Minimap(Game1 game)
        {
            this.game = game;
            playerPixel = SpriteFactory.Instance.GreenPixel(origin + centerVector);
        }

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible { get; set; }

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public int Frame { get; set; }

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        //Loads in the title for the minimap
        private void LoadTitle(string titleString)
        {
            title = TextSpriteFactory.Instance.customBigText(textLocation, titleString);
            game.manager.AddObject(title);
            mapTitle = titleString;
        }

        public void Draw(GameTime gametime)
        {
            if (Visible)
            {
                foreach (Sprite sprite in map)
                {
                    sprite.Draw(gametime);
                }
            }
        }

        public void Update(GameTime gametime)
        {
            if (Visible)
            {
                map.Clear();
                foreach (Room room in game.loader.allRooms)
                {
                    map.Add(SpriteFactory.Instance.BluePixels(origin + (room.coordinate * Constants.MAP_BUFFER_MULT)));
                }
                map.Add(playerPixel);
                playerPixel = SpriteFactory.Instance.GreenPixel(origin + centerVector + (game.loader.currentRoom.coordinate * Constants.MAP_BUFFER_MULT));
            }
        }

        public void UnloadMap()
        {
            Visible = false;
            map.Clear();
            game.manager.RemoveObject(title);
        }

        public void LoadMap(string title)
        {
            Visible = true;
            LoadTitle(title);
        }
    }
}
