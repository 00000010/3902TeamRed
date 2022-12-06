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

        private List<Sprite> prevRoomSprites, nextRoomSprites;
        private int[] prevCapturedDimension, prevCapturedAmount1, prevCapturedAmount2;
        private int[] nextCapturedDimension, nextCapturedAmount1, nextCapturedAmount2;

        // The cursors that determine where the appearing/disappearing of the room is.
        private int cursor;

        private Dictionary<Direction, Action> transitionDict = new Dictionary<Direction, Action>();

        private delegate void UpdatePrevRoomFrame();
        UpdatePrevRoomFrame prevHandler;
        private delegate void UpdateNextRoomFrame();
        UpdateNextRoomFrame nextHandler;
        private delegate void AdjustCursor();
        AdjustCursor cursorHandler;

        private delegate void SetTransition(Direction direction);
        SetTransition transitionHandler;

        public bool Transitioning { get; set; }
        public bool TransitionSet { get; set; }

        public int CameraSpeed { get; set; }

        private enum PLANE { HORIZONTAL, VERTICAL }
        private PLANE plane;

        public Camera(Game1 game)
        {
            this.game = game;
            CameraSpeed = Constants.CAMERA_SPEED;
            plane = PLANE.HORIZONTAL;
            PopulateTransitionDictionary();
        }

        /// <summary>
        /// Import the sprites involved in the camera transition.
        /// </summary>
        /// <param name="prevRoomSprites"></param>
        /// <param name="nextRoomSprites"></param>
        public void GetSprites(List<Sprite> prevRoomSprites, List<Sprite> nextRoomSprites)
        {
            this.prevRoomSprites = prevRoomSprites;
            this.nextRoomSprites = nextRoomSprites;
        }

        /// <summary>
        /// Set the transition direction.
        /// </summary>
        /// <param name="direction"></param>
        public void SetDirection(Direction direction)
        {
            transitionDict[direction].Invoke();
        }

        private void PopulateTransitionDictionary()
        {
            transitionDict.Add(Direction.LEFT, PanLeftTransition);
            transitionDict.Add(Direction.RIGHT, PanRightTransition);
            transitionDict.Add(Direction.UP, PanUpTransition);
            transitionDict.Add(Direction.DOWN, PanDownTransition);
        }
        /// <summary>
        /// Constrain an amount between zero and the specified amount.
        /// </summary>
        /// <param name="unconstrainedAmount"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private int ConstrainAmount(int unconstrainedAmount, int amount)
        {
            int x = 0;
            return ((unconstrainedAmount < 0 ? 0 : x = unconstrainedAmount) > amount ? amount : x);
        }

        /// <summary>
        /// Check whether the transition is complete by where the cursor is and what type of transition is occuring.
        /// </summary>
        /// <param name="cursor"></param>
        private void CheckProgress(int cursor)
        {
            if ((plane == PLANE.VERTICAL && (cursor > Constants.ROOM_Y + Constants.SCALED_ROOM_HEIGHT || cursor < Constants.ROOM_Y)) || (plane == PLANE.HORIZONTAL && (cursor > Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH || cursor < Constants.ROOM_X)))
            {
                Transitioning = false;
                TransitionSet = false;
            }
        }

        /// <summary>
        /// Advance the cursor by the speed the camera is set to.
        /// </summary>
        private void AdvanceCursor()
        {
            cursor = cursor + CameraSpeed;
            CheckProgress(cursor);
        }

        /// <summary>
        /// Retract the cursor by the speed the camera is set to.
        /// </summary>
        private void RetractCursor()
        {
            cursor = cursor - CameraSpeed;
            CheckProgress(cursor);
        }

        /// <summary>
        /// Save the element in index i of the array depending on whether that slot is filled by an impossible value.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="element"></param>
        /// <param name="array"></param>
        private void SetSavedArray(int i, int element, int[] array)
        {
            if (array[i] == Constants.IMPOSSIBLE_VALUE)
            {
                array[i] = element;
            }
        }

        /// <summary>
        /// Adjusts the source rectangle X and width and the destination X and width of the next room sprites depending on where the cursor is. Expands rightward.
        /// </summary>
        private void EmptyToRightFull()
        {
            for (int i = 0; i < nextRoomSprites.Count; i++)
            {
                // Save the original width to constrain it later
                SetSavedArray(i, nextRoomSprites[i].DestinationRectangle.Width, nextCapturedDimension);
                // Save the original destination X
                SetSavedArray(i, nextRoomSprites[i].DestinationRectangle.X, nextCapturedAmount1);
                // Save starting source X
                SetSavedArray(i, nextRoomSprites[i].SourceRectangle[0].X, nextCapturedAmount2);

                // Get the destination X as if the sprite was actually moving outside of the room
                int trueX = nextCapturedAmount1[i] - Constants.SCALED_ROOM_WIDTH + (cursor - Constants.ROOM_X);
                // Get the new destination X
                int newX = Constants.ROOM_X + ConstrainAmount(trueX - Constants.ROOM_X, Constants.SCALED_ROOM_WIDTH);
                // Get the new destination width
                int newWidth = ConstrainAmount(trueX + nextCapturedDimension[i] - Constants.ROOM_X, nextCapturedDimension[i]);
                // Get the new source X for all source rectangles of the sprite.
                int newSourceX = nextCapturedAmount2[i] + (nextCapturedDimension[i] / Constants.SCALING_FACTOR) - (newWidth / Constants.SCALING_FACTOR);

                // Adjust the source and destination rectangles
                nextRoomSprites[i].SourceRectangle[0].X = newSourceX;
                nextRoomSprites[i].SourceRectangle[0].Width = newWidth / Constants.SCALING_FACTOR;
                nextRoomSprites[i].DestinationRectangle = new Rectangle(newX, nextRoomSprites[i].DestinationRectangle.Y, newWidth, nextRoomSprites[i].DestinationRectangle.Height);
            }
        }

        /// <summary>
        /// Adjusts the source rectangle width and the destination X and width of the previous room sprites depending on where the cursor is. Contracts rightward.
        /// </summary>
        private void FullToRightEmpty()
        {
            // Go through all sprites and update their source and destination according to the cursor
            for (int i = 0; i < prevRoomSprites.Count; i++)
            {
                // Save the original width to constrain it later
                SetSavedArray(i, prevRoomSprites[i].DestinationRectangle.Width, prevCapturedDimension);
                // Save the original destination X
                SetSavedArray(i, prevRoomSprites[i].DestinationRectangle.X, prevCapturedAmount1);

                // Get the new destination X
                int newX = prevCapturedAmount1[i] + (cursor - Constants.ROOM_X);
                // Get the new destination width
                int newWidth = ConstrainAmount(Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH - prevRoomSprites[i].DestinationRectangle.X, prevCapturedDimension[i]);

                // Adjust the source and destination rectangles
                prevRoomSprites[i].SourceRectangle[0].Width = newWidth / Constants.SCALING_FACTOR;
                prevRoomSprites[i].DestinationRectangle = new Rectangle(newX, prevRoomSprites[i].DestinationRectangle.Y, newWidth, prevRoomSprites[i].SourceRectangle[0].Height * Constants.SCALING_FACTOR);
            }
        }

        /// <summary>
        /// Adjusts the source rectangle X and width and the destination X and width of the previous room sprites depending on where the cursor is. Contracts leftward.
        /// </summary>
        private void FullToLeftEmpty()
        {
            // Go through all sprites and update their source and destination according to the cursor
            for (int i = 0; i < prevRoomSprites.Count; i++)
            {
                // Save the original width to constrain it later
                SetSavedArray(i, prevRoomSprites[i].DestinationRectangle.Width, prevCapturedDimension);
                // Save the original destination X
                SetSavedArray(i, prevRoomSprites[i].DestinationRectangle.X, prevCapturedAmount1);
                // Save starting source X
                SetSavedArray(i, prevRoomSprites[i].SourceRectangle[0].X, prevCapturedAmount2);

                // Get how far the cursor has moved across the room
                int cursorDisplacement = (Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH) - cursor;
                // Get the destination X as if the sprite was actually moving outside of the room
                int trueX = (prevCapturedAmount1[i] - cursorDisplacement);
                // Get the new destination X; it will be between Constants.ROOM_X and Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH
                int newX = Constants.ROOM_X + ConstrainAmount(trueX - Constants.ROOM_X, Constants.SCALED_ROOM_WIDTH);
                // Get the new destination width; it will be between 0 and its original scaled width
                int newWidth = prevCapturedDimension[i] - ConstrainAmount(Constants.ROOM_X - trueX, prevCapturedDimension[i]);
                // Get the new source X; it will go from its source width to 0
                int newSourceX = prevCapturedAmount2[i] + ConstrainAmount((Constants.ROOM_X - trueX) / Constants.SCALING_FACTOR, prevCapturedDimension[i] / Constants.SCALING_FACTOR);

                // Adjust the source and destination rectangles
                prevRoomSprites[i].SourceRectangle[0].X = newSourceX;
                prevRoomSprites[i].SourceRectangle[0].Width = newWidth / Constants.SCALING_FACTOR;
                prevRoomSprites[i].DestinationRectangle = new Rectangle(newX, prevRoomSprites[i].DestinationRectangle.Y, newWidth, prevRoomSprites[i].SourceRectangle[0].Height * Constants.SCALING_FACTOR);
            }
        }

        /// <summary>
        /// Adjusts the source rectangle width and the destination X and width of the next room sprites depending on where the cursor is. Expands leftward.
        /// </summary>
        private void EmptyToLeftFull()
        {
            for (int i = 0; i < nextRoomSprites.Count; i++)
            {
                // Save the original width to constrain it later
                SetSavedArray(i, nextRoomSprites[i].DestinationRectangle.Width, nextCapturedDimension);
                // Save the original destination X
                SetSavedArray(i, nextRoomSprites[i].DestinationRectangle.X, nextCapturedAmount1);

                // Get how far the cursor has moved across the room
                int cursorDisplacement = Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH - cursor;
                // Get the new destination X; it will be between Constants.ROOM_X and Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH
                int newX = nextCapturedAmount1[i] + Constants.SCALED_ROOM_WIDTH - cursorDisplacement;
                // Get the new destination width; it will be between 0 and its original scaled width
                int newWidth = ConstrainAmount(Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH - newX, nextCapturedDimension[i]);

                // Adjust the source and destination rectangles
                nextRoomSprites[i].SourceRectangle[0].Width = newWidth / Constants.SCALING_FACTOR;
                nextRoomSprites[i].DestinationRectangle = new Rectangle(newX, nextRoomSprites[i].DestinationRectangle.Y, newWidth, nextRoomSprites[i].DestinationRectangle.Height);
            }
        }

        /// <summary>
        /// Adjusts the source rectangle Y and height and the destination Y and width of the previous room sprites depending on where the cursor is. Contracts upward.
        /// </summary>
        private void FullToUpEmpty()
        {
            // Go through all sprites and update their source and destination according to the cursor
            for (int i = 0; i < prevRoomSprites.Count; i++)
            {
                // Save the original height to constrain it later
                SetSavedArray(i, prevRoomSprites[i].DestinationRectangle.Height, prevCapturedDimension);
                // Save the original destination Y
                SetSavedArray(i, prevRoomSprites[i].DestinationRectangle.Y, prevCapturedAmount1);
                // Save starting source Y
                SetSavedArray(i, prevRoomSprites[i].SourceRectangle[0].Y, prevCapturedAmount2);

                // Get how far the cursor has moved across the room
                int cursorDisplacement = (Constants.ROOM_Y + Constants.SCALED_ROOM_HEIGHT) - cursor;
                // Get the destination Y as if the sprite was actually moving outside of the room
                int trueY = (prevCapturedAmount1[i] - cursorDisplacement);
                // Get the new destination Y; it will be between Constants.ROOM_Y and Constants.ROOM_Y + Constants.SCALED_ROOM_HEIGHT
                int newY = Constants.ROOM_Y + ConstrainAmount(trueY - Constants.ROOM_Y, Constants.SCALED_ROOM_HEIGHT);
                // Get the new destination height; it will be between 0 and its original scaled height
                int newHeight = prevCapturedDimension[i] - ConstrainAmount(Constants.ROOM_Y - trueY, prevCapturedDimension[i]);
                // Get the new source Y; it will go from its source width to 0
                int newSourceY = prevCapturedAmount2[i] + ConstrainAmount((Constants.ROOM_Y - trueY) / Constants.SCALING_FACTOR, prevCapturedDimension[i] / Constants.SCALING_FACTOR);

                // Adjust the source the destination rectangles
                prevRoomSprites[i].SourceRectangle[0].Y = newSourceY;
                prevRoomSprites[i].SourceRectangle[0].Height = newHeight / Constants.SCALING_FACTOR;
                prevRoomSprites[i].DestinationRectangle = new Rectangle(prevRoomSprites[i].DestinationRectangle.X, newY, prevRoomSprites[i].SourceRectangle[0].Width * Constants.SCALING_FACTOR, newHeight);
            }
        }

        /// <summary>
        /// Adjusts the source rectangle height and the destination Y and width of the previous room sprites depending on where the cursor is. Expands upward.
        /// </summary>
        private void EmptyToUpFull()
        {
            for (int i = 0; i < nextRoomSprites.Count; i++)
            {
                // Save the original height to constrain it later
                SetSavedArray(i, nextRoomSprites[i].DestinationRectangle.Height, nextCapturedDimension);
                // Save the original destination Y
                SetSavedArray(i, nextRoomSprites[i].DestinationRectangle.Y, nextCapturedAmount1);
                // Save starting source Y
                SetSavedArray(i, nextRoomSprites[i].SourceRectangle[0].Y, nextCapturedAmount2);

                // Get how far the cursor has moved across the room
                int cursorDisplacement = Constants.ROOM_Y + Constants.SCALED_ROOM_HEIGHT - cursor;
                // Get the new destination Y; it will be between Constants.ROOM_Y and Constants.ROOM_Y + Constants.SCALED_ROOM_HEIGHT
                int newY = nextCapturedAmount1[i] + Constants.SCALED_ROOM_HEIGHT - cursorDisplacement;
                // Get the new destination height; it will be between 0 and its original scaled height
                int newHeight = ConstrainAmount(Constants.ROOM_Y + Constants.SCALED_ROOM_HEIGHT - newY, nextCapturedDimension[i]);

                // Adjust the source and destination rectangles
                nextRoomSprites[i].SourceRectangle[0].Height = newHeight / Constants.SCALING_FACTOR;
                nextRoomSprites[i].DestinationRectangle = new Rectangle(nextRoomSprites[i].DestinationRectangle.X, newY, nextRoomSprites[i].DestinationRectangle.Width, newHeight);
            }
        }

        /// <summary>
        /// Adjusts the source rectangle height and the destination Y and width of the previous room sprites depending on where the cursor is.  Contracts downward.
        /// </summary>
        private void FullToDownEmpty()
        {
            // Go through all sprites and update their source and destination according to the cursor
            for (int i = 0; i < prevRoomSprites.Count; i++)
            {
                // Save the original width to constrain it later
                SetSavedArray(i, prevRoomSprites[i].DestinationRectangle.Height, prevCapturedDimension);
                // Save the original destination X
                SetSavedArray(i, prevRoomSprites[i].DestinationRectangle.Y, prevCapturedAmount1);

                // Get the new destination X
                int newY = prevCapturedAmount1[i] + (cursor - Constants.ROOM_Y);
                // Get the new destination width
                int newHeight = ConstrainAmount(Constants.ROOM_Y + Constants.SCALED_ROOM_HEIGHT - prevRoomSprites[i].DestinationRectangle.Y, prevCapturedDimension[i]);

                // Adjust the source and destination rectangles
                prevRoomSprites[i].SourceRectangle[0].Height = newHeight / Constants.SCALING_FACTOR;
                prevRoomSprites[i].DestinationRectangle = new Rectangle(prevRoomSprites[i].DestinationRectangle.X, newY, prevRoomSprites[i].SourceRectangle[0].Width * Constants.SCALING_FACTOR, newHeight);
            }
        }

        /// <summary>
        /// Adjusts the source rectangle Y and height and the destination Y and width of the previous room sprites depending on where the cursor is. Expands downward.
        /// </summary>
        private void EmptyToDownFull()
        {
            for (int i = 0; i < nextRoomSprites.Count; i++)
            {
                // Save the original height to constrain it later
                SetSavedArray(i, nextRoomSprites[i].DestinationRectangle.Height, nextCapturedDimension);
                // Save the original destination Y
                SetSavedArray(i, nextRoomSprites[i].DestinationRectangle.Y, nextCapturedAmount1);
                // Save starting source Y
                SetSavedArray(i, nextRoomSprites[i].SourceRectangle[0].Y, nextCapturedAmount2);

                // Get the destination Y as if the sprite was actually moving outside of the room
                int trueY = nextCapturedAmount1[i] - Constants.SCALED_ROOM_HEIGHT + (cursor - Constants.ROOM_Y);
                // Get the new destination Y; it will be between Constants.ROOM_Y and Constants.ROOM_Y + Constants.SCALED_ROOM_HEIGHT
                int newY = Constants.ROOM_Y + ConstrainAmount(trueY - Constants.ROOM_Y, Constants.SCALED_ROOM_HEIGHT);
                // Get the new destination height; it will be between 0 and its original scaled height
                int newHeight = ConstrainAmount(trueY + nextCapturedDimension[i] - Constants.ROOM_Y, nextCapturedDimension[i]);
                // Get the new source Y for all source rectangles of the sprite.
                int newSourceY = nextCapturedAmount2[i] + (nextCapturedDimension[i] / Constants.SCALING_FACTOR) - (newHeight / Constants.SCALING_FACTOR);

                // Adjust the source and destination rectangles
                nextRoomSprites[i].SourceRectangle[0].Y = newSourceY;
                nextRoomSprites[i].SourceRectangle[0].Height = newHeight / Constants.SCALING_FACTOR;
                nextRoomSprites[i].DestinationRectangle = new Rectangle(nextRoomSprites[i].DestinationRectangle.X, newY, nextRoomSprites[i].DestinationRectangle.Width, newHeight);
            }
        }

        /// <summary>
        /// Set transition to go to the left (west) room.
        /// </summary>
        public void PanLeftTransition()
        {
            Console.WriteLine("Pan left transition");
            plane = PLANE.HORIZONTAL;
            cursor = Constants.ROOM_X;
            prevHandler = FullToRightEmpty;
            nextHandler = EmptyToRightFull;
            cursorHandler = AdvanceCursor;

            prevCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            nextCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomSprites.Count).ToArray();
            prevCapturedAmount1 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            nextCapturedAmount1 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomSprites.Count).ToArray();
            nextCapturedAmount2 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomSprites.Count).ToArray();
        }

        /// <summary>
        /// Set transition to go to the right (east) room.
        /// </summary>
        public void PanRightTransition()
        {
            Console.WriteLine("Pan right transition");
            plane = PLANE.HORIZONTAL;
            cursor = Constants.ROOM_X + Constants.SCALED_ROOM_WIDTH;
            prevHandler = FullToLeftEmpty;
            nextHandler = EmptyToLeftFull;
            cursorHandler = RetractCursor;

            prevCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            nextCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomSprites.Count).ToArray();
            prevCapturedAmount1 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            prevCapturedAmount2 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            nextCapturedAmount1 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomSprites.Count).ToArray();
        }

        /// <summary>
        /// Set transition to go to the forward (north) room.
        /// </summary>
        public void PanUpTransition()
        {
            Console.WriteLine("Pan up transition");
            plane = PLANE.VERTICAL;
            cursor = Constants.ROOM_Y;
            prevHandler = FullToDownEmpty;
            nextHandler = EmptyToDownFull;
            cursorHandler = AdvanceCursor;

            prevCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            nextCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomSprites.Count).ToArray();
            prevCapturedAmount1 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            nextCapturedAmount1 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomSprites.Count).ToArray();
            nextCapturedAmount2 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomSprites.Count).ToArray();
        }

        /// <summary>
        /// Set transition to go to the backward (south) room.
        /// </summary>
        public void PanDownTransition()
        {
            Console.WriteLine("Pan down transition");
            plane = PLANE.VERTICAL;
            cursor = Constants.ROOM_Y + Constants.SCALED_ROOM_HEIGHT;
            prevHandler = FullToUpEmpty;
            nextHandler = EmptyToUpFull;
            cursorHandler = RetractCursor;

            prevCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            nextCapturedDimension = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomSprites.Count).ToArray();
            prevCapturedAmount1 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            prevCapturedAmount2 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, prevRoomSprites.Count).ToArray();
            nextCapturedAmount1 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomSprites.Count).ToArray();
            nextCapturedAmount2 = Enumerable.Repeat(Constants.IMPOSSIBLE_VALUE, nextRoomSprites.Count).ToArray();
        }

        public void Draw(GameTime gameTime)
        {
            foreach (Sprite sprite in nextRoomSprites)
            {
                sprite.Draw(gameTime);
            }
            foreach (Sprite sprite in prevRoomSprites)
            {
                sprite.Draw(gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            prevHandler();
            nextHandler();
            cursorHandler();
        }
    }
}