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
        private int[] prevCapturedAmount;
        private int[] nextCapturedAmount1;
        private int[] nextCapturedAmount2;
        private int[] nextCapturedAmount;
        private int[] prevCapturedAmount1;
        private int[] prevCapturedAmount2;

        private List<IDrawable> drawables = new List<IDrawable>(); // TODO: for testing; DELETE!

        // The cursors that determine where the appearing/disappearing of the room is.
        private int[] cursors;

        private delegate List<Sprite> UpdatePrevRoomFrame(List<Sprite> roomSprites);
        UpdatePrevRoomFrame prevHandler;
        private delegate List<Sprite> UpdateNextRoomFrame(List<Sprite> roomSprites);
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
            CameraSpeed = 2;
        }

        private List<Sprite> FromObjectsToSprites(List<object> objects)
        {
            List<Sprite> sprites = new List<Sprite>(new Sprite[objects.Count]);
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i] is Sprite)
                {
                    sprites[i] = (Sprite)objects[i];
                } else
                {
                    sprites[i] = ((IObject)objects[i]).Sprite;
                }
            }
            return sprites;
        }

        // maybe a stupidly made function
        private int ConstrainDimension(int unconstrainedDimension, int dimensionAmount)
        {
            int x = 0;
            return ((unconstrainedDimension < 0 ? 0 : x = unconstrainedDimension) > dimensionAmount ? dimensionAmount : x);
        }

        private void CheckProgress(int cursor)
        {
            // TODO: check against in y direction also
            if (cursor > Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH || cursor < Constants.ROOM_X)
            {
                Transitioning = false;
                TransitionSet = false;
                prevCapturedDimension = new int[0];
                nextCapturedDimension = new int[0];
                prevCapturedAmount = new int[0];
                nextCapturedAmount1 = new int[0];
                nextCapturedAmount2 = new int[0];
            }
        }

        private void AdvanceCursor()
        {
            cursors[0] = cursors[0] + CameraSpeed;
            CheckProgress(cursors[0]);
        }

        private void RetractCursor()
        {
            cursors[0] = cursors[0] - CameraSpeed;
            CheckProgress(cursors[0]);
        }

        private void AdvanceRetractCursors()
        {
            cursors[0] = cursors[0] - CameraSpeed;
            cursors[1] = cursors[0] + CameraSpeed;
            CheckProgress(cursors[0]);
        }

        private void SetSavedArray(int i, int element, int[] array)
        {
            if (array[i] == Constants.IMPOSSIBLE_VALUE)
            {
                array[i] = element;
            }
        }

        /// <summary>
        /// Takes an array of rectangles where each rectangle is an object's rectangle. Array <code>cursors</code> must be initialized with the two cursors; the first will go left, the last will go right.
        /// </summary>
        /// <param name="rects">The array of rectangles.</param>
        private List<Sprite> FullToLeftRightEmpty(List<Sprite> roomSprites)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Takes an array of rectangles where each rectangle is an object's rectangle.
        /// </summary>
        /// <param name="rects">The array of rectangles.</param>
        private List<Sprite> EmptyToLeftRightFull(List<Sprite> roomSprites)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Expands rightward. Assumes all objects have only one frame to draw.
        /// </summary>
        /// <param name="rects">The array of the room rectangles.</param>
        private List<Sprite> EmptyToRightFull(List<Sprite> roomSprites)
        {
            List<Sprite> updatedSprites = new List<Sprite>(roomSprites.Select(x=>x.Copy()));
            for (int i = 0; i < roomSprites.Count; i++)
            {
                SetSavedArray(i, roomSprites[i].DestinationRectangle.Width, nextCapturedDimension); // capture scaled width
                SetSavedArray(i, roomSprites[i].DestinationRectangle.X - Constants.SCALED_ROOM_WIDTH, nextCapturedAmount1); // record starting destination x
                SetSavedArray(i, roomSprites[i].SourceRectangle[0].X, nextCapturedAmount2); // record starting source x
                int trueX = nextCapturedAmount1[i] + (cursors[0] - Constants.ROOM_X);
                int newX = Constants.ROOM_X + ConstrainDimension(trueX - Constants.ROOM_X, Constants.SCALED_ROOM_WIDTH);
                int newWidth = ConstrainDimension(trueX + nextCapturedDimension[i] - Constants.ROOM_X, nextCapturedDimension[i]);

                // Get the new source X for all source rectangles of the sprite.
                int newSourceX = nextCapturedAmount2[i] + (nextCapturedDimension[i] / Constants.SCALING_FACTOR) - (newWidth / Constants.SCALING_FACTOR);
                updatedSprites[i].SourceRectangle[0].X = newSourceX;
                updatedSprites[i].SourceRectangle[0].Width = newWidth / Constants.SCALING_FACTOR;
                updatedSprites[i].DestinationRectangle = new Rectangle(newX, roomSprites[i].DestinationRectangle.Y, newWidth, roomSprites[i].DestinationRectangle.Height);
            }
            return updatedSprites;
        }

        // TODO: Below two functions do the same thing; consolidate somehow
        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Contracts rightward. Assumes all objects have only one frame to draw.
        /// </summary>
        /// <param name="rects">The array of the room rectangles.</param>
        private List<Sprite> FullToRightEmpty(List<Sprite> roomSprites)
        {
            // Go through all sprites and update their source and destination according to the cursor
            for (int i = 0; i < roomSprites.Count; i++)
            {
                // Save the original width to constrain it later
                SetSavedArray(i, roomSprites[i].DestinationRectangle.Width, prevCapturedDimension);
                // Save the original destination X
                SetSavedArray(i, roomSprites[i].DestinationRectangle.X, prevCapturedAmount);
                // Get the new destination X
                int newX = prevCapturedAmount[i] + (cursors[0] - Constants.ROOM_X);
                // Get the new destination width
                int newWidth = ConstrainDimension(Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH - roomSprites[i].DestinationRectangle.X, prevCapturedDimension[i]);
                // Set the source rectangle to the new width, unscaled
                roomSprites[i].SourceRectangle[0].Width = newWidth / Constants.SCALING_FACTOR;
                // Set the destination rectangle to the new X and width
                roomSprites[i].DestinationRectangle = new Rectangle(newX, roomSprites[i].DestinationRectangle.Y, newWidth, roomSprites[i].SourceRectangle[0].Height * Constants.SCALING_FACTOR);
            }
            return roomSprites;
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Contracts leftward. Assumes all objects have only one frame to draw.
        /// </summary>
        /// <param name="rects">The array of room rectangles.</param>
        private List<Sprite> FullToLeftEmpty(List<Sprite> roomSprites)
        {
            List<Sprite> updatedSprites = roomSprites;
            // Go through all sprites and update their source and destination according to the cursor
            for (int i = 0; i < roomSprites.Count; i++)
            {
                // Save the original width to constrain it later
                SetSavedArray(i, roomSprites[i].DestinationRectangle.Width, prevCapturedDimension);
                // Save the original destination X
                SetSavedArray(i, roomSprites[i].DestinationRectangle.X, prevCapturedAmount1);
                // Save starting source X
                SetSavedArray(i, roomSprites[i].SourceRectangle[0].X, prevCapturedAmount2);

                // Get how far the cursor has moved across the room
                int cursorDisplacement = (Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH) - cursors[0];
                // Get the destination X as if the sprite was actually moving outside of the room
                int trueX = (prevCapturedAmount1[i] - cursorDisplacement);
                // Get the new destination X; it will be between Constants.ROOM_X and Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH
                int newX = Constants.ROOM_X + ConstrainDimension(trueX - Constants.ROOM_X, Constants.SCALED_ROOM_WIDTH);
                // Get the new destination width; it will be between 0 and its original scaled width
                int newWidth = prevCapturedDimension[i] - ConstrainDimension(Constants.ROOM_X - trueX, prevCapturedDimension[i]);
                //int newSourceX = nextCapturedAmount2[i] + (nextCapturedDimension[i] / Constants.SCALING_FACTOR) - (newWidth / Constants.SCALING_FACTOR);
                // Get the new source X; it will go from its source width to 0
                int newSourceX = prevCapturedAmount2[i] + ConstrainDimension((Constants.ROOM_X - trueX) / Constants.SCALING_FACTOR, prevCapturedDimension[i] / Constants.SCALING_FACTOR);
                roomSprites[i].SourceRectangle[0].X = newSourceX;
                roomSprites[i].SourceRectangle[0].Width = newWidth / Constants.SCALING_FACTOR;
                roomSprites[i].DestinationRectangle = new Rectangle(newX, roomSprites[i].DestinationRectangle.Y, newWidth, roomSprites[i].SourceRectangle[0].Height * Constants.SCALING_FACTOR);
            }
            return roomSprites;
        }

        /// <summary>
        /// Takes an array of room object rectangles and adjusts their width depending on whether they should be shown. Expands leftward. Assumes all objects have only one frame to draw.
        /// </summary>
        /// <param name="rects">The array of room rectangles.</param>
        private List<Sprite> EmptyToLeftFull(List<Sprite> roomSprites)
        {
            return roomSprites;
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
            prevCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomObjects.Count).ToArray();
            nextCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomObjects.Count).ToArray();
            prevCapturedAmount = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomObjects.Count).ToArray();
            nextCapturedAmount1 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomObjects.Count).ToArray();
            nextCapturedAmount2 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomObjects.Count).ToArray();
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
        public void PanLeftTransition(List<Sprite> prevRoomSprites, List<Sprite> nextRoomSprites)
        {
            Console.WriteLine("Pan left transition");
            this.prevRoomSprites = prevRoomSprites;
            this.nextRoomSprites = nextRoomSprites;
            prevCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            nextCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            prevCapturedAmount = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            nextCapturedAmount1 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomSprites.Count).ToArray();
            nextCapturedAmount2 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomSprites.Count).ToArray();
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
        public void PanRightTransition(List<Sprite> prevRoomSprites, List<Sprite> nextRoomSprites)
        {
            Console.WriteLine("Pan right transition");
            this.prevRoomSprites = prevRoomSprites;
            this.nextRoomSprites = nextRoomSprites;
            prevCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            nextCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            prevCapturedAmount1 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            prevCapturedAmount2 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            cursors = new int[] { Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH };
            prevHandler = FullToLeftEmpty;
            nextHandler = EmptyToLeftFull;
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
            prevCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomObjects.Count).ToArray();
            nextCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomObjects.Count).ToArray();
            prevCapturedAmount = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomObjects.Count).ToArray();
            nextCapturedAmount1 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomObjects.Count).ToArray();
            nextCapturedAmount2 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomObjects.Count).ToArray();
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
            prevCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomObjects.Count).ToArray();
            nextCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomObjects.Count).ToArray();
            prevCapturedAmount = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomObjects.Count).ToArray();
            nextCapturedAmount1 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomObjects.Count).ToArray();
            nextCapturedAmount2 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomObjects.Count).ToArray();
            cursors = new int[] { Constants.ROOM_Y + Constants.SCALED_ROOM_HEIGHT };
            //prevHandler = FullToUpEmpty;
            //nextHandler = EmptyToUpFull;
            cursorHandler = RetractCursor;
        }

        public void Draw(GameTime gameTime)
        {
            //foreach (Sprite sprite in nextRoomSprites)
            //{
            //    sprite.Draw(gameTime);
            //}
            foreach (Sprite sprite in prevRoomSprites)
            {
                sprite.Draw(gameTime);
            }
            //for (int i = 0; i < 1; i++)
            //{
            //    prevRoomSprites[i].Draw(gameTime);
            //}
        }

        public void Update(GameTime gameTime)
        {
            prevRoomSprites = prevHandler(prevRoomSprites);
            //nextRoomSprites = nextHandler(nextRoomSprites);
            cursorHandler();
        }
    }
}