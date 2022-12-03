using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using sprint0;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace sprint0
{
    public class MouseController : IController
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
            int blockLength = Constants.BLOCK_SIZE;
            int gridLength = 12;
            int gridHeight = 7;
            int totalGridSquares = gridLength * gridHeight;


            //Can be changed if want to make something out of the dungeon (default 150, 120)
            int topLeftGridSpaceX = 214;
            int topLeftGridSpaceY = 184;

            //Creates a listener for each of the grid squares
            for (int i = 0; i < gridHeight; i++)
            {
                for (int j = 0; j < gridLength; j++)
                {
                    Rectangle newRec = new Rectangle(topLeftGridSpaceX + blockLength * j, topLeftGridSpaceY + blockLength * i, blockLength, blockLength);
                    Console.WriteLine(newRec.ToString());
                    this.RegisterCommand(new MouseCommand(MouseButton.Left, newRec), new PlaceBlockCommand(game, new Vector2(newRec.X, newRec.Y)));
                    this.RegisterCommand(new MouseCommand(MouseButton.Right, newRec), new RemoveBlockCommand(game, new Vector2(newRec.X, newRec.Y)));
                }
            }
            
            //Creates a listener for each object in the list to change
            foreach(KeyValuePair<object, Vector2> entry in game.creator.itemList)
            {

                Console.WriteLine("Entry bruh " + entry.Key.ToString() + " " + entry.Value.ToString());
                Rectangle newRec = new Rectangle((int)entry.Value.X, (int)entry.Value.Y, blockLength, blockLength);

                if(entry.Key is Door)
                {
                    newRec = new Rectangle((int)entry.Value.X, (int)entry.Value.Y, blockLength * 2, blockLength * 2);
                }

                this.RegisterCommand(new MouseCommand(MouseButton.Left, newRec), new ChangeCurrentObjectCommand(game, entry.Key));
            }

            //Creates a listener for the save command
            Rectangle newRectangle = new Rectangle(Constants.SAVE_ICON_X, Constants.SAVE_ICON_Y, blockLength, blockLength);
            this.RegisterCommand(new MouseCommand(MouseButton.Left, newRectangle), new SaveLevelCommand(game));

            //Creates back button listener
            newRectangle = new Rectangle(Constants.BACK_BUTTON_X, Constants.BACK_BUTTON_Y, blockLength * 2, blockLength * 2);
            this.RegisterCommand(new MouseCommand(MouseButton.Left, newRectangle), new BackToTitleScreenCommand(game, GameState.CREATOR));

            //Creats the functionality to move between rooms
            Dictionary<Direction, Vector2> doorPositionInfo = new Dictionary<Direction, Vector2>();
            doorPositionInfo.Add(Direction.UP, new Vector2(Constants.DOOR_NORTH_POSITION_X, Constants.DOOR_NORTH_POSITION_Y));
            doorPositionInfo.Add(Direction.RIGHT, new Vector2(Constants.DOOR_EAST_POSITION_X, Constants.DOOR_EAST_POSITION_Y));
            doorPositionInfo.Add(Direction.DOWN, new Vector2(Constants.DOOR_SOUTH_POSITION_X, Constants.DOOR_SOUTH_POSITION_Y));
            doorPositionInfo.Add(Direction.LEFT, new Vector2(Constants.DOOR_WEST_POSITION_X, Constants.DOOR_WEST_POSITION_Y));

            //foreach(KeyValuePair<Direction, Vector2> pair in doorPositionInfo)
            //{
            //    Rectangle doorRec = new Rectangle((int)pair.Value.X, (int)pair.Value.Y, blockLength, blockLength);
            //    this.RegisterCommand(new MouseCommand(MouseButton.Left, doorRec), new LoadRoomCommand(game, pair.Key));
            //}
        }

        public void unloadCommands()
        {
            mouseMappings.Clear();
        }
    }
}
