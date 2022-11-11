using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sprint0
{
    internal class Camera : ICamera, IObject, IUpdateable
    {
        private GameCamera gameCamera;

        public Sprite Sprite { get; set; }
        public Vector2 Position { get { return Sprite.Position; } set { Sprite.Position = value; } }
        public Vector2 Velocity { get { return Sprite.Velocity; } set { Sprite.Velocity = value; } }
        public Direction Direction { get; set; }

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public Camera() { }

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public Camera(GameCamera camera)
        {
            gameCamera = camera;
        }

        // Set camera to proper position and ensure it is there correctly
        public bool GetPosition(Vector2 position, out Vector2 newPosition)
        {
            newPosition = gameCamera.WorldToScreenPosition(position);
            return gameCamera.isInScreen(position);
        }
        // Check camera is within the screen
        public bool InsideScreen(System.Numerics.Vector2 position)
        {
            return gameCamera.isInScreen(position);
        }
        // Move camera to new position
        public void MoveCamera(Direction direction)
        {
            gameCamera.moveCamera(direction);
        }
        // Check if the camera is transitioning or not to prevent multiple at the same time
        public bool CameraInTransition()
        {
            return gameCamera.isLocked;
        }

        public virtual void Update(GameTime gameTime)
        {
            gameCamera.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime)
        {
        }
    }
}