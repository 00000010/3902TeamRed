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
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        private List<Sprite> prevRoomObjects, nextRoomObjects;

        // The cursors that determine where the appearing/disappearing of the room is.
        private int[] cursors;

        // 
        private delegate void UpdatePrevRoomFrame(ref List<Sprite> roomObjects);
        UpdatePrevRoomFrame prevHandler;
        private delegate void UpdateNextRoomFrame(ref List<Sprite> roomObjects);
        UpdateNextRoomFrame nextHandler;
        private delegate void AdjustCursor();
        AdjustCursor cursorHandler;

        public Camera(){}

        // maybe a stupidly made function
        private int ConstrainWidth(int unconstrainedDimension, int dimensionAmount)
        {
            int x = 0;
            // TODO: test
            return ((unconstrainedDimension < 0 ? 0 : x = unconstrainedDimension) > dimensionAmount ? dimensionAmount : x);
        }

        // TODO: inte korrekt, fixa
        private bool TransitionComplete()
        {
            return true;
        }

        private void AdvanceCursor()
        {
            cursors[0]++;
        }

        private void RetractCursor()
        {
            cursors[0]--;
        }

        private void AdvanceRetractCursors()
        {
            cursors[0]--;
            cursors[1]++;
        }

        /// <summary>
        /// Takes an array of rectangles where each rectangle is an object's rectangle. Array <code>cursors</code> must be initialized with the two cursors; the first will go left, the last will go right.
        /// </summary>
        /// <param name="rects">The array of rectangles.</param>
        private void FullToLeftRightEmpty(ref List<Sprite> roomObjects)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Takes an array of rectangles where each rectangle is an object's rectangle.
        /// </summary>
        /// <param name="rects">The array of rectangles.</param>
        private void EmptyToLeftRightFull(ref List<Sprite> roomObjects)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Expands rightward.
        /// </summary>
        /// <param name="rects">The array of the room rectangles.</param>
        private void EmptyToRightFull(ref List<Sprite> roomObjects)
        {
            // Set width for each object which should be between [0, Rectangle.Width]
            for (int i = 0; i < roomObjects.Count; i++)
            {
                for (int j = 0; j < roomObjects[i].SourceRectangle.Count(); j++)
                {
                    int width = roomObjects[i].SourceRectangle[j].Width;
                    int x = roomObjects[i].SourceRectangle[j].X;
                    roomObjects[i].SourceRectangle[j].Width = ConstrainWidth(cursors[0] - x, width);
                }
            }
        }

        // TODO: Below two functions do the same thing; consolidate somehow
        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Contracts rightward.
        /// </summary>
        /// <param name="rects">The array of the room rectangles.</param>
        private void FullToRightEmpty(ref List<Sprite> roomObjects)
        {
            for (int i = 0; i < roomObjects.Count; i++)
            {
                for (int j = 0; j < roomObjects[i].SourceRectangle.Count(); j++)
                {
                    int width = roomObjects[i].SourceRectangle[j].Width;
                    int x = roomObjects[i].SourceRectangle[j].X;
                    roomObjects[i].SourceRectangle[j].Width = ConstrainWidth(width - (cursors[0] - x), width);
                }
            }
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Expands leftward.
        /// </summary>
        /// <param name="rects">The array of room rectangles.</param>
        private void EmptyToLeftFull(ref List<Sprite> roomObjects)
        {
            for (int i = 0; i < roomObjects.Count; i++)
            {
                for (int j = 0; j < roomObjects[i].SourceRectangle.Count(); j++)
                {
                    int width = roomObjects[i].SourceRectangle[j].Width;
                    int x = roomObjects[i].SourceRectangle[j].X;
                    roomObjects[i].SourceRectangle[j].Width = ConstrainWidth(width - (cursors[0] - x), width);
                }
            }
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Contracts leftward.
        /// </summary>
        /// <param name="rects">The array of room rectangles.</param>
        private void FullToLeftEmpty(ref List<Sprite> roomObjects)
        {
            for (int i = 0; i < roomObjects.Count; i++)
            {
                for (int j = 0; j < roomObjects[i].SourceRectangle.Count(); j++)
                {
                    int width = roomObjects[i].SourceRectangle[j].Width;
                    int x = roomObjects[i].SourceRectangle[j].X;
                    roomObjects[i].SourceRectangle[j].Width = ConstrainWidth(cursors[0] - x, width);
                }
            }
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Contracts upward.
        /// </summary>
        /// <param name="rects">The array of room rectangles.</param>
        private void FullToUpEmpty(ref List<Sprite> roomObjects)
        {
            for (int i = 0; i < roomObjects.Count; i++)
            {
                for (int j = 0; j < roomObjects[i].SourceRectangle.Count(); j++)
                {
                    int height = roomObjects[i].SourceRectangle[j].Height;
                    int y = roomObjects[i].SourceRectangle[j].Y;
                    roomObjects[i].SourceRectangle[j].Height = ConstrainWidth(cursors[0] - y, height);
                }
            }
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Expands upward.
        /// </summary>
        /// <param name="rects">The array of room rectangles.</param>
        private void EmptyToUpFull(ref List<Sprite> roomObjects)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Contracts downward.
        /// </summary>
        /// <param name="rects">The array of room rectangles.</param>
        private void FullToDownEmpty(ref List<Sprite> roomObjects)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Expands downward.
        /// </summary>
        /// <param name="rects">The array of room rectangles.</param>
        private void EmptyToDownFull(ref List<Sprite> roomObjects)
        {
            throw new NotImplementedException();
        }

        public void CurtainTransition(List<Sprite> prevRoomObjects, List<Sprite> nextRoomObjects, GameTime gameTime)
        {
            Console.WriteLine("Curtain transition");
            this.prevRoomObjects = prevRoomObjects;
            this.nextRoomObjects = nextRoomObjects;
            cursors = new int[] { Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH / 2, Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH / 2 };
            prevHandler = FullToLeftRightEmpty;
            nextHandler = EmptyToLeftRightFull;
            cursorHandler = AdvanceRetractCursors;
            Update(gameTime);
        }

        /// <summary>
        /// Transition when going to the left (west) room.
        /// </summary>
        /// <param name="roomObjects"></param>
        /// <param name="gameTime"></param>
        public void PanLeftTransition(List<Sprite> prevRoomObjects, List<Sprite> nextRoomObjects, GameTime gameTime)
        {
            Console.WriteLine("Pan left transition");
            this.prevRoomObjects = prevRoomObjects;
            this.nextRoomObjects = nextRoomObjects;
            cursors = new int[] { Constants.ROOM_X };
            prevHandler = FullToRightEmpty;
            nextHandler = EmptyToRightFull;
            cursorHandler = AdvanceCursor;
            Update(gameTime);
        }

        /// <summary>
        /// Transition when going to the right (east) room.
        /// </summary>
        /// <param name="roomObjects"></param>
        /// <param name="gameTime"></param>
        public void PanRightTransition(List<Sprite> prevRoomObjects, List<Sprite> nextRoomObjects, GameTime gameTime)
        {
            Console.WriteLine("Pan right transition");
            this.prevRoomObjects = prevRoomObjects;
            this.nextRoomObjects = nextRoomObjects;
            cursors = new int[] { Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH };
            prevHandler = FullToLeftEmpty;
            nextHandler = EmptyToLeftFull;
            cursorHandler = RetractCursor;
            Update(gameTime);
        }

        /// <summary>
        /// Transition when going to the forward (north) room.
        /// </summary>
        /// <param name="roomObjects"></param>
        /// <param name="gameTime"></param>
        public void PanUpTransition(List<Sprite> prevRoomObjects, List<Sprite> nextRoomObjects, GameTime gameTime)
        {
            Console.WriteLine("Pan up transition");
            this.prevRoomObjects = prevRoomObjects;
            this.nextRoomObjects = nextRoomObjects;
            cursors = new int[] { Constants.ROOM_Y };
            prevHandler = FullToDownEmpty;
            nextHandler = EmptyToDownFull;
            cursorHandler = AdvanceCursor;
            Update(gameTime);
        }

        /// <summary>
        /// Transition when going to the backward (south) room.
        /// </summary>
        /// <param name="roomObjects"></param>
        /// <param name="gameTime"></param>
        public void PanDownTransition(List<Sprite> prevRoomObjects, List<Sprite> nextRoomObjects, GameTime gameTime)
        {
            Console.WriteLine("Pan down transition");
            this.prevRoomObjects = prevRoomObjects;
            this.nextRoomObjects = nextRoomObjects;
            cursors = new int[] { Constants.ROOM_Y + Constants.SCALED_ROOM_HEIGHT };
            prevHandler = FullToUpEmpty;
            nextHandler = EmptyToUpFull;
            cursorHandler = RetractCursor;
            Update(gameTime);
        }

        private void Draw(GameTime gameTime)
        {
            foreach (ISprite sprite in prevRoomObjects)
            {
                sprite.Draw(gameTime);
            }
            foreach (ISprite sprite in nextRoomObjects)
            {
                sprite.Draw(gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            this.Draw(gameTime);
            prevHandler(ref prevRoomObjects);
            nextHandler(ref nextRoomObjects);
            cursorHandler();
            while (!TransitionComplete())
            {
                this.Update(gameTime);
            }
        }
    }
}