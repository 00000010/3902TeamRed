using Microsoft.Xna.Framework;
using System.Drawing;

namespace sprint0
{
    public class GameCamera
    {
        private float velocity;
        private Vector2 currentPosition;
        private Vector2 futurePosition;
        private Direction movementDirection;
        public bool isLocked { get { return (int)currentPosition.X != (int)futurePosition.X || (int)currentPosition.Y != (int)futurePosition.Y; } }

        public Vector2 Position { get { return currentPosition; } }
        public Vector2 TilePosition { get { return new Vector2(currentPosition.X / Constants.SCREEN_WIDTH, currentPosition.Y / Constants.SCREEN_HEIGHT); } }

        public GameCamera()
        {
            velocity = 5f;
            currentPosition = new Vector2(0, 0);
        }

        public void Update(GameTime gameTime)
        {
            if (!isLocked)
                return;

            if (currentPosition.X < futurePosition.X)
                currentPosition.X += velocity;
            if (currentPosition.X > futurePosition.X)
                currentPosition.X -= velocity;
            if (currentPosition.Y > futurePosition.Y)
                currentPosition.Y -= velocity;
            if (currentPosition.Y < futurePosition.Y)
                currentPosition.Y += velocity;

            //if (ManagerFunction.Distance(currentPosition, futurePosition) < 5)
            //{
            //    currentPosition = futurePosition;
            //}
        }

        public void moveCamera(Direction direction)
        {
            switch (direction)
            {
                case Direction.LEFT:
                    futurePosition = new Vector2(currentPosition.X - Constants.SCREEN_WIDTH, currentPosition.Y);
                    break;
                case Direction.RIGHT:
                    futurePosition = new Vector2(currentPosition.X + Constants.SCREEN_HEIGHT, currentPosition.Y);
                    break;
                case Direction.UP:
                    futurePosition = new Vector2(currentPosition.X, currentPosition.Y - Constants.SCREEN_HEIGHT);
                    break;

                case Direction.DOWN:
                    futurePosition = new Vector2(currentPosition.X, currentPosition.Y + Constants.SCREEN_HEIGHT);
                    break;
            }
        }

        public bool isInScreen(Vector2 vector)
        {
            return ((vector.X > currentPosition.X - 16 && vector.X < currentPosition.X + Constants.SCREEN_WIDTH + 16) &&
                    (vector.Y > currentPosition.Y - 16 && vector.Y < currentPosition.Y + Constants.SCREEN_HEIGHT + 16));
        }

        public Vector2 WorldToScreenPosition(Vector2 position)
        {
            return new Vector2(position.X - currentPosition.X, position.Y - currentPosition.Y);
        }


        //public bool MouseInsideWindow()
        //{
        //    var state = Mouse.GetState();
        //    var pos = new Point(state.X, state.Y);
        //    return pos.X >= 0 && pos.X <= Constants.SCREEN_WIDTH && pos.Y >= 0 && pos.Y <= Constants.SCREEN_HEIGHT;
        //}
    }
}