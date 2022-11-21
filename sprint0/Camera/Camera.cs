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

        public Direction direction = Direction.LEFT;

        public Camera(Game1 game)
        {
            this.game = game;
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
            if (direction == Direction.LEFT || direction == Direction.RIGHT)
            {
                if (cursor > Constants.SCALED_ROOM_WIDTH || cursor < 0)
                {
                    Transitioning = false;
                    Console.WriteLine("Transition complete");
                }
            }
            else
            {
                if (cursor > Constants.SCALED_ROOM_HEIGHT || cursor < 0)
                {
                    Transitioning = false;
                    Console.WriteLine("Transition complete");
                }
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
            // Set width for each object which should be between [0, Rectangle.Width]
            for (int i = 0; i < roomSprites.Count; i++)
            {
                int width = roomSprites[i].SourceRectangle[0].Width;
                int x = roomSprites[i].SourceRectangle[0].X;
                roomSprites[i].SourceRectangle[0].Width = ConstrainDimension(cursors[0] - x, width);
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
                int width = roomSprites[i].SourceRectangle[0].Width;
                int x = roomSprites[i].SourceRectangle[0].X;
                roomSprites[i].SourceRectangle[0].Width = ConstrainDimension(width - (cursors[0] - x), width);
            }
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Expands leftward. Assumes all objects have only one frame to draw.
        /// </summary>
        /// <param name="rects">The array of room rectangles.</param>
        private void EmptyToLeftFull(ref List<Sprite> roomSprites)
        {
            for (int i = 0; i < roomSprites.Count; i++)
            {
                int width = roomSprites[i].SourceRectangle[0].Width;
                int x = roomSprites[i].SourceRectangle[0].X;
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
                int width = roomSprites[i].SourceRectangle[0].Width;
                int x = roomSprites[i].SourceRectangle[0].X;
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
                int height = roomSprites[i].SourceRectangle[0].Height;
                int y = roomSprites[i].SourceRectangle[0].Y;
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
            cursors = new int[] { 0 };
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
            prevHandler(ref prevRoomSprites);
            nextHandler(ref nextRoomSprites);
            cursorHandler();
        }
    }
}