using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace sprint0
{
    public class GameObjectManager : IUpdateable, IDrawable
    {
        private Game1 game;
        public List<ISprite> arrowsInFlight = new List<ISprite>();


        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public GameObjectManager(Game1 game)
        {
            this.game = game;
        }

        event EventHandler<EventArgs> IUpdateable.EnabledChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<EventArgs> IUpdateable.UpdateOrderChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<EventArgs> IDrawable.DrawOrderChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<EventArgs> IDrawable.VisibleChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void addArrow(ISprite arrow)
        {
            arrowsInFlight.Add(arrow);
        }

        public void removeArrow(ISprite arrow)
        {
            arrowsInFlight.Remove(arrow);
        }

        public void Draw(GameTime gameTime)
        {
            foreach (Sprite arrow in arrowsInFlight)
            {
                arrow.Draw(gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Sprite arrow in arrowsInFlight)
            {
                arrow.Update(gameTime);
            }
        }
    }
}

