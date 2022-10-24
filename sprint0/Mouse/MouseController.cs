using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace sprint0
{
    internal class MouseController : IController
    {
        private Dictionary<MouseCommand, ICommand> mouseMappings;
        Vector2 resolution;

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public MouseController(Vector2 resolution)
        {
            this.resolution = resolution;
            mouseMappings = new Dictionary<MouseCommand, ICommand>();
            int second = DateTime.Now.Second;
        }
        public void Update(GameTime gameTime)
        {
            foreach (MouseCommand mouseCommand in mouseMappings.Keys)
            {
                if (mouseCommand.Equals(Mouse.GetState())) 
                {
                    mouseMappings[mouseCommand].Execute();
                }
            }

        }
        void RegisterCommand(MouseCommand mouseCommand, ICommand command)
        {
            mouseMappings.Add(mouseCommand, command);
        }
        public void LoadMouseCommands(Game1 game)
        {
            Rectangle screen = new Rectangle(0, 0, (int)resolution.X, (int)resolution.Y);
            Rectangle q1 = new Rectangle(0, 0, (int)resolution.X / 2, (int)resolution.Y / 2);
            Rectangle q2 = new Rectangle((int)resolution.X / 2, 0, (int)resolution.X / 2, (int)resolution.Y / 2);
            Rectangle q3 = new Rectangle(0, (int)resolution.Y / 2, (int)resolution.X / 2, (int)resolution.Y / 2);
            Rectangle q4 = new Rectangle((int)resolution.X / 2, (int)resolution.Y / 2, (int)resolution.X / 2, (int)resolution.Y / 2);

            this.RegisterCommand(new MouseCommand(MouseButton.Right, screen), new ExitCommand(game));
            //this.RegisterCommand(new MouseCommand(MouseButton.Left, q1), new LinkStandingRightCommand(game));
            //this.RegisterCommand(new MouseCommand(MouseButton.Left, q2), new LinkRunningRightCommand(game));
            //this.RegisterCommand(new MouseCommand(MouseButton.Left, q3), new LinkRunningRightCommand(game));
            //this.RegisterCommand(new MouseCommand(MouseButton.Left, q4), new LinkRunningRightCommand(game));
        }
        public void LoadLevelCreatorCommands(Game1 game, LevelLoader loader)
        {
            int blockLength = 16;
            int gridLength = 16;
            int gridHeight = 11;
            int totalGridSquares = gridLength * gridHeight;
            Rectangle gridArea = new Rectangle(272, 224, blockLength * gridLength, blockLength * gridHeight);
            Rectangle[] gridSquares = new Rectangle[totalGridSquares];

            for (int i = 0; i < gridHeight; i++)
            {
                for (int j = 0; j < gridLength; j++)
                {
                    Rectangle newRec = new Rectangle(272 + blockLength * j, 224 + blockLength * i, blockLength, blockLength);
                    Console.WriteLine(newRec.ToString());
                    this.RegisterCommand(new MouseCommand(MouseButton.Left, newRec), new PlaceBlockCommand(game, new Vector2(newRec.X, newRec.Y), loader));
                }
            }
            Rectangle saveRec = new Rectangle(200, 200, 16, 16);
            this.RegisterCommand(new MouseCommand(MouseButton.Left, saveRec), new SaveLevelCommand(game, loader));
        }

    }
}
