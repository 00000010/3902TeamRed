using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sprint0
{
    internal class Camera : ICamera
    {
        public Sprite Sprite { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        private enum TRANSITION { CURTAIN, PAN };

        private Rectangle[] prevRoomRects, nextRoomRects;
        private delegate void UpdatePrevTransition(ref Rectangle[] rects);
        UpdatePrevTransition prevHandler;
        private delegate void UpdateNextTransition(ref Rectangle[] rects);
        UpdateNextTransition nextHandler;

        public Camera()
        {
            prevRoomRects = new Rectangle[] {new Rectangle(Constants.ROOM_X, Constants.ROOM_Y, Constants.ROOM_WIDTH, Constants.ROOM_HEIGHT)};
            nextRoomRects = new Rectangle[1];
        }

        /// <summary>
        /// The transition is complete when the previous room is no longer being drawn. Total width of the previous room's rectangles is checked for this, but height could also be used. Height was not checked against zero because we may want to have a transition from top/bottom sides.
        /// </summary>
        /// <param name="prevRoomRects"></param>
        /// <returns>whether the transition is complete and camera can relinquish control</returns>
        private bool TransitionComplete(Rectangle[] prevRoomRects)
        {
            bool complete = false;
            int totalWidth = 0;
            foreach(Rectangle rect in prevRoomRects)
            {
                totalWidth += rect.Width;
            }
            if (totalWidth == 0)
            {
                complete = true;
            }
            return complete;
        }

        /// <summary>
        /// Takes an array of TWO rectangles (of the room), where one rectangle is the left side and the other is the right side and determines how the room disappears from full view to left/right sides to nothing.
        /// </summary>
        /// <param name="rects">The array of rectangles with the left side and right side. Must be TWO rectangles; no more, no less.</param>
        public static void FullToLeftRightEmpty(ref Rectangle[] rects)
        {
            rects[0].Width -= 1;
            rects[1].X += 1;
        }

        /// <summary>
        /// Takes an array of TWO empty rectangles (of the room), where one rectangle is the left side and the other is the right side and determines how the room disappears from full view to left/right sides to nothing. The left rectangle should have the X-Y coordinates of the room while the right rectangle should have the coordinates of X/2-Y of the room.
        /// </summary>
        /// <param name="rects">The array of rectangles with the left side and right side. Must be TWO rectangles; no more, no less.</param>
        private void EmptyToLeftRightFull(ref Rectangle[] rects)
        {
            rects[0].Width += 1;
            rects[1].Width += 1;
            rects[1].X -= 1;
        }

        /// <summary>
        /// Takes an array of ONE empty rectangle (of the room), where the rectangle has the X-Y coordinates of the room's top left corner. Expands rightward.
        /// </summary>
        /// <param name="rects">The array of one rectangle; no more, no less.</param>
        private void EmptyToRightFull(ref Rectangle[] rects)
        {
            rects[0].Width += 1;
        }

        /// <summary>
        /// Takes an array of ONE empty rectangle (of the room), where the rectangle has the X-Y coordinates of the room's top right corner. Expands leftward.
        /// </summary>
        /// <param name="rects">The array of one rectangle; no more, no less.</param>
        private void EmptyToLeftFull(ref Rectangle[] rects)
        {
            rects[0].Width += 1;
            rects[0].X -= 1;
        }

        /// <summary>
        /// Takes an array of ONE empty rectangle (of the room), where the rectangle has the X-Y coordinates of the room's top left corner. Contracts rightward.
        /// </summary>
        /// <param name="rects">The array of one rectangle; no more, no less.</param>
        private void FullToRightEmpty(ref Rectangle[] rects)
        {
            rects[0].Width -= 1;
            rects[0].X += 1;
        }

        /// <summary>
        /// Takes an array of ONE empty rectangle (of the room), where the rectangle has the X-Y coordinates of the room's top right corner. Contracts leftward.
        /// </summary>
        /// <param name="rects">The array of one rectangle; no more, no less.</param>
        private void FullToLeftEmpty(ref Rectangle[] rects)
        {
            rects[0].Width -= 1;
        }

        public void CurtainTransition(List<object> roomObjects, GameTime gameTime)
        {
            Console.WriteLine("Curtain transition");
            prevHandler = FullToLeftRightEmpty;
            nextHandler = EmptyToLeftRightFull;
            Update(gameTime);
        }

        /// <summary>
        /// Transition when going to the left (west) room.
        /// </summary>
        /// <param name="roomObjects"></param>
        /// <param name="gameTime"></param>
        public void PanLeftTransition(List<object> roomObjects, GameTime gameTime)
        {
            Console.WriteLine("Pan left transition");
            prevHandler = FullToRightEmpty;
            nextHandler = EmptyToRightFull;
            Update(gameTime);
        }

        /// <summary>
        /// Transition when going to the right (east) room.
        /// </summary>
        /// <param name="roomObjects"></param>
        /// <param name="gameTime"></param>
        public void PanRightTransition(List<object> roomObjects, GameTime gameTime)
        {
            Console.WriteLine("Pan right transition");
            prevHandler = FullToLeftEmpty;
            nextHandler = EmptyToLeftFull;
            Update(gameTime);
        }

        /// <summary>
        /// Transition when going to the forward (north) room.
        /// </summary>
        /// <param name="roomObjects"></param>
        /// <param name="gameTime"></param>
        public void PanUpTransition(List<object> roomObjects, GameTime gameTime)
        {
            // TODO: implement
            Console.WriteLine("Pan down transition");
            Update(gameTime);
        }

        /// <summary>
        /// Transition when going to the backward (south) room.
        /// </summary>
        /// <param name="roomObjects"></param>
        /// <param name="gameTime"></param>
        public void PanDownTransition(List<object> roomObjects, GameTime gameTime)
        {
            // TODO: implement
            Console.WriteLine("Pan down transition");
            Update(gameTime);
        }

        private void Draw(GameTime gameTime)
        {
            // TODO: implement
        }

        public void Update(GameTime gameTime)
        {
            this.Draw(gameTime);
            prevHandler(ref prevRoomRects);
            nextHandler(ref nextRoomRects);
            while (!TransitionComplete(prevRoomRects))
            {
                this.Update(gameTime);
            }            
        }
    }
}