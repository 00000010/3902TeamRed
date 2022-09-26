using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace sprint0
{
    public class GameObjectManager : IUpdateable, IDrawable
    {
        private Game1 game;
        public List<ISprite> arrowsInFlight = new List<ISprite>();
        public List<ISprite> toRemove = new List<ISprite>();
        enum State {  COOLDOWN, READY };
        State arrowState = State.READY;
        readonly int coolDownTime = 100;
        int coolDown;


        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public GameObjectManager(Game1 game)
        {
            this.game = game;
            coolDown = 0;
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
            if (arrowState == State.READY)
            {
                arrowsInFlight.Add(arrow);
                arrowState = State.COOLDOWN;
            }

        }

        public void removeArrow()
        {
            arrowsInFlight.RemoveAll(toRemove.Contains);
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
                if (arrow.Position.X >= 800)
                {
                    toRemove.Add(arrow);
                }
            }

            if(coolDown > 0)
            {
                coolDown--;
            }
            
            if(coolDown == 0 && arrowState == State.COOLDOWN)
            {
                coolDown = coolDownTime;
                arrowState = State.READY;
                Console.WriteLine("Ready!");
            }

            removeArrow();
        }
    }
}

