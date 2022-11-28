using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class Camera : ICamera
    {
        private Game game;

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        private List<object> prevRoomObjects, nextRoomObjects;
        private List<Sprite> prevRoomSprites, nextRoomSprites;
        private int[] prevCapturedDimension;
        private int[] nextCapturedDimension;

        private List<IDrawable> drawables = new List<IDrawable>(); // TODO: for testing; DELETE!

        // The cursors that determine where the appearing/disappearing of the room is.
        private int[] cursors;

        private delegate void UpdatePrevRoomFrame(ref List<Sprite> roomSprites);
        UpdatePrevRoomFrame prevHandler;
        private delegate void UpdateNextRoomFrame(ref List<Sprite> roomSprites);
        UpdateNextRoomFrame nextHandler;
        private delegate void AdjustCursor(); // TODO: incorporating this into the above two delegates would be nice
        AdjustCursor cursorHandler;

        private delegate void SetTransition(Direction direction);
        SetTransition transitionHandler;

        public bool Transitioning { get; set; }
        public bool TransitionSet { get; set; }

        public int CameraSpeed { get; set; }

        public Direction direction = Direction.LEFT;

        public Camera(Game1 game)
        {
            this.game = game;
            CameraSpeed = 1;
        }

        private List<Sprite> FromObjectsToSprites(List<object> objects)
        {
            List<Sprite> sprites = new List<Sprite>();
            foreach(object obj in objects)
            {
                if (obj is Sprite)
                {
                    sprites.Add((Sprite)obj);
                } else
                {
                    sprites.Add(((IObject)obj).Sprite);
                }
            }
            return sprites;
        }

        // maybe a stupidly made function
        private int ConstrainDimension(int unconstrainedDimension, int dimensionAmount)
        {
            int x = 0;
            // TODO: test
            return ((unconstrainedDimension < 0 ? 0 : x = unconstrainedDimension) > dimensionAmount ? dimensionAmount : x);
        }

        private void CheckProgress(int cursor)
        {
            // TODO: check against in y direction also
            if (cursor > Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH || cursor < Constants.ROOM_X)
            {
                Transitioning = false;
                prevCapturedDimension = new int[0];
                nextCapturedDimension = new int[0];
            }
        }

        private void AdvanceCursor()
        {
            cursors[0] = cursors[0] + 1;
            CheckProgress(cursors[0]);
        }

        private void RetractCursor()
        {
            cursors[0]--;
            CheckProgress(cursors[0]);
        }

        private void AdvanceRetractCursors()
        {
            cursors[0]--;
            cursors[1]++;
            CheckProgress(cursors[0]);
        }

        private void SetPrevCapturedDimension(int i, int dimensionAmount)
        {
            if (prevCapturedDimension[i] == 0)
            {
                prevCapturedDimension[i] = dimensionAmount;
            }
        }

        private void SetNextCapturedDimension(int i, int dimensionAmount)
        {
            if (nextCapturedDimension[i] == 0)
            {
                nextCapturedDimension[i] = dimensionAmount;
            }
        }

        /// <summary>
        /// Takes an array of rectangles where each rectangle is an object's rectangle. Array <code>cursors</code> must be initialized with the two cursors; the first will go left, the last will go right.
        /// </summary>
        /// <param name="rects">The array of rectangles.</param>
        private void FullToLeftRightEmpty(ref List<Sprite> roomSprites)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Takes an array of rectangles where each rectangle is an object's rectangle.
        /// </summary>
        /// <param name="rects">The array of rectangles.</param>
        private void EmptyToLeftRightFull(ref List<Sprite> roomSprites)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Expands rightward. Assumes all objects have only one frame to draw.
        /// </summary>
        /// <param name="rects">The array of the room rectangles.</param>
        private void EmptyToRightFull(ref List<Sprite> roomSprites)
        {
            for (int i = 0; i < roomSprites.Count; i++)
            {
                SetPrevCapturedDimension(i, roomSprites[i].DestinationRectangle.Width);
                int newWidth = ConstrainDimension(cursors[0] - roomSprites[i].DestinationRectangle.X,
                    prevCapturedDimension[i]);
                roomSprites[i].SourceRectangle[0].Width = newWidth / Constants.SCALING_FACTOR;
                roomSprites[i].DestinationRectangle = new Rectangle(roomSprites[i].DestinationRectangle.X, roomSprites[i].DestinationRectangle.Y, newWidth, roomSprites[i].DestinationRectangle.Height);
            }
        }

        // TODO: Below two functions do the same thing; consolidate somehow
        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Contracts rightward. Assumes all objects have only one frame to draw.
        /// </summary>
        /// <param name="rects">The array of the room rectangles.</param>
        private void FullToRightEmpty(ref List<Sprite> roomSprites)
        {
            for (int i = 0; i < roomSprites.Count; i++)
            {
                SetNextCapturedDimension(i, roomSprites[i].DestinationRectangle.Width);
                int newWidth = ConstrainDimension(cursors[0] - roomSprites[i].DestinationRectangle.X,
                    nextCapturedDimension[i]);
                roomSprites[i].SourceRectangle[0].Width = newWidth / Constants.SCALING_FACTOR;
                roomSprites[i].DestinationRectangle = new Rectangle(roomSprites[i].DestinationRectangle.X, roomSprites[i].DestinationRectangle.Y, newWidth, roomSprites[i].SourceRectangle[0].Height * Constants.SCALING_FACTOR);
            }
            //for (int i = 0; i < roomSprites.Count; i++)
            //{
            //    int width = roomSprites[i].DestinationRectangle.Width;
            //    //if (i == 0)
            //    //{
            //    //    Console.Write("prev original width: " + width + ", ");
            //    //}
            //    int x = (int)roomSprites[i].Position.X;
            //    //if (i == 0)
            //    //{
            //    //    Console.Write("x: " + x + ", ");
            //    //    Console.Write("cursor at: " + cursors[0] + ", ");
            //    //    Console.Write("before constraining: " + (width - (cursors[0] - x)) + ", ");
            //    //}
            //    roomSprites[i].SourceRectangle[0].Width = ConstrainDimension(width - (cursors[0] - Constants.ROOM_X), width);
            //    if (i == 0)
            //    {
            //        //Console.WriteLine("width: " + roomSprites[i].SourceRectangle[0].Width);
            //    }
            //    roomSprites[i].DestinationRectangle = roomSprites[i].SourceRectangle[0];
            //    roomSprites[i].Position = new Vector2(cursors[0], roomSprites[i].Position.Y);
            //    if (i == 0)
            //    {
            //        //Console.Write("after constraining: " + roomSprites[i].SourceRectangle[0].Width + ", ");
            //        //Console.WriteLine("position: " + roomSprites[i].Position.ToString());
            //        //Console.Write("source: " + roomSprites[i].SourceRectangle[0].ToString());
            //        //Console.WriteLine("destination: " + roomSprites[i].DestinationRectangle.ToString());
            //    }
            //}
            //Console.WriteLine("room width: " + roomSprites[0].SourceRectangle[0].Width);
            // TODO: room is full then suddenly zero!
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Expands leftward. Assumes all objects have only one frame to draw.
        /// </summary>
        /// <param name="rects">The array of room rectangles.</param>
        private void EmptyToLeftFull(ref List<Sprite> roomSprites)
        {
            for (int i = 0; i < roomSprites.Count; i++)
            {
                int width = roomSprites[i].DestinationRectangle.Width;
                int x = roomSprites[i].DestinationRectangle.X;
                roomSprites[i].SourceRectangle[0].Width = ConstrainDimension(width - (cursors[0] - x), width);
            }
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Contracts leftward. Assumes all objects have only one frame to draw.
        /// </summary>
        /// <param name="rects">The array of room rectangles.</param>
        private void FullToLeftEmpty(ref List<Sprite> roomSprites)
        {
            for (int i = 0; i < roomSprites.Count; i++)
            {
                int width = roomSprites[i].DestinationRectangle.Width;
                int x = roomSprites[i].DestinationRectangle.X;
                roomSprites[i].SourceRectangle[0].Width = ConstrainDimension(cursors[0] - x, width);
            }
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Contracts upward. Assumes all objects have only one frame to draw.
        /// </summary>
        /// <param name="rects">The array of room rectangles.</param>
        private void FullToUpEmpty(ref List<Sprite> roomSprites)
        {
            for (int i = 0; i < roomSprites.Count; i++)
            {
                int height = roomSprites[i].DestinationRectangle.Height;
                int y = roomSprites[i].DestinationRectangle.Y;
                roomSprites[i].SourceRectangle[0].Height = ConstrainDimension(cursors[0] - y, height);
            }
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Expands upward.
        /// </summary>
        /// <param name="rects">The array of room rectangles.</param>
        private void EmptyToUpFull(ref List<Sprite> roomSprites)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Contracts downward.
        /// </summary>
        /// <param name="rects">The array of room rectangles.</param>
        private void FullToDownEmpty(ref List<Sprite> roomSprites)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Expands downward.
        /// </summary>
        /// <param name="rects">The array of room rectangles.</param>
        private void EmptyToDownFull(ref List<Sprite> roomSprites)
        {
            throw new NotImplementedException();
        }

        public void CurtainTransition(List<object> prevRoomObjects, List<object> nextRoomObjects)
        {
            Console.WriteLine("Curtain transition");
            this.prevRoomObjects = prevRoomObjects;
            this.nextRoomObjects = nextRoomObjects;
            prevCapturedDimension = new int[prevRoomObjects.Count];
            nextCapturedDimension = new int[nextRoomObjects.Count];
            cursors = new int[] { Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH / 2, Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH / 2 };
            //prevHandler = FullToLeftRightEmpty;
            //nextHandler = EmptyToLeftRightFull;
            cursorHandler = AdvanceRetractCursors;
        }

        /// <summary>
        /// Transition when going to the left (west) room.
        /// </summary>
        /// <param name="roomObjects"></param>
        /// <param name="gameTime"></param>
        public void PanLeftTransition(List<object> prevRoomObjects, List<object> nextRoomObjects)
        {
            Console.WriteLine("Pan left transition");
            this.prevRoomSprites = FromObjectsToSprites(prevRoomObjects);
            this.nextRoomSprites = FromObjectsToSprites(nextRoomObjects);
            prevCapturedDimension = new int[prevRoomObjects.Count];
            nextCapturedDimension = new int[nextRoomObjects.Count];
            cursors = new int[] { Constants.ROOM_X };
            prevHandler = FullToRightEmpty;
            nextHandler = EmptyToRightFull;
            cursorHandler = AdvanceCursor;
        }

        /// <summary>
        /// Transition when going to the right (east) room.
        /// </summary>
        /// <param name="roomObjects"></param>
        /// <param name="gameTime"></param>
        public void PanRightTransition(List<object> prevRoomObjects, List<object> nextRoomObjects)
        {
            Console.WriteLine("Pan right transition");
            this.prevRoomObjects = prevRoomObjects;
            this.nextRoomObjects = nextRoomObjects;
            prevCapturedDimension = new int[prevRoomObjects.Count];
            nextCapturedDimension = new int[nextRoomObjects.Count];
            cursors = new int[] { Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH };
            //prevHandler = FullToLeftEmpty;
            //nextHandler = EmptyToLeftFull;
            cursorHandler = RetractCursor;
        }

        /// <summary>
        /// Transition when going to the forward (north) room.
        /// </summary>
        /// <param name="roomObjects"></param>
        /// <param name="gameTime"></param>
        public void PanUpTransition(List<object> prevRoomObjects, List<object> nextRoomObjects)
        {
            Console.WriteLine("Pan up transition");
            this.prevRoomObjects = prevRoomObjects;
            this.nextRoomObjects = nextRoomObjects;
            prevCapturedDimension = new int[prevRoomObjects.Count];
            nextCapturedDimension = new int[nextRoomObjects.Count];
            cursors = new int[] { Constants.ROOM_Y };
            //prevHandler = FullToDownEmpty;
            //nextHandler = EmptyToDownFull;
            cursorHandler = AdvanceCursor;
        }

        /// <summary>
        /// Transition when going to the backward (south) room.
        /// </summary>
        /// <param name="roomObjects"></param>
        /// <param name="gameTime"></param>
        public void PanDownTransition(List<object> prevRoomObjects, List<object> nextRoomObjects)
        {
            Console.WriteLine("Pan down transition");
            this.prevRoomObjects = prevRoomObjects;
            this.nextRoomObjects = nextRoomObjects;
            prevCapturedDimension = new int[prevRoomObjects.Count];
            nextCapturedDimension = new int[nextRoomObjects.Count];
            cursors = new int[] { Constants.ROOM_Y + Constants.SCALED_ROOM_HEIGHT };
            //prevHandler = FullToUpEmpty;
            //nextHandler = EmptyToUpFull;
            cursorHandler = RetractCursor;
        }

        public void Draw(GameTime gameTime)
        {
            foreach (Sprite sprite in nextRoomSprites)
            {
                sprite.Draw(gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.ElapsedGameTime.Milliseconds % CameraSpeed == 0)
            {
                prevHandler(ref prevRoomSprites);
                nextHandler(ref nextRoomSprites);
                cursorHandler();
            }
        }
    }
}