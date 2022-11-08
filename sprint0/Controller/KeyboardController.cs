using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace sprint0
{
    internal class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private Dictionary<Keys, ICommand> controllerMappingsUnpress;

        private Keys[] prevPressedKeys = new Keys[0];

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            controllerMappingsUnpress = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void RegisterCommandUnpress(Keys key, ICommand command)
        {
            controllerMappingsUnpress.Add(key, command);
        }

        public void Update(GameTime gameTime)
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in prevPressedKeys)
            {
                if (controllerMappingsUnpress.ContainsKey(key) && !pressedKeys.Contains(key))
                {
                    controllerMappingsUnpress[key].Execute();
                }
            }

            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key) && !prevPressedKeys.Contains(key))
                {
                    controllerMappings[key].Execute();
                }
            }
            this.prevPressedKeys = pressedKeys;
        }

        public void LoadDefaultKeys(Game1 game)
        {
            /* WASD and arrow keys for moving Link around */
            this.RegisterCommand(Keys.W, new PlayerRunningCommand(game, Direction.UP));
            this.RegisterCommand(Keys.A, new PlayerRunningCommand(game, Direction.LEFT));
            this.RegisterCommand(Keys.S, new PlayerRunningCommand(game, Direction.DOWN));
            this.RegisterCommand(Keys.D, new PlayerRunningCommand(game, Direction.RIGHT));

            this.RegisterCommandUnpress(Keys.W, new PlayerStopRunningCommand(game, Direction.UP));
            this.RegisterCommandUnpress(Keys.A, new PlayerStopRunningCommand(game, Direction.LEFT));
            this.RegisterCommandUnpress(Keys.S, new PlayerStopRunningCommand(game, Direction.DOWN));
            this.RegisterCommandUnpress(Keys.D, new PlayerStopRunningCommand(game, Direction.RIGHT));

            //this.RegisterCommand(Keys.Up, new PlayerRunningCommand(game, Direction.UP));
            //this.RegisterCommand(Keys.Left, new PlayerRunningCommand(game, Direction.LEFT));
            //this.RegisterCommand(Keys.Down, new PlayerRunningCommand(game, Direction.DOWN));
            //this.RegisterCommand(Keys.Right, new PlayerRunningCommand(game, Direction.RIGHT));

            //this.RegisterCommandUnpress(Keys.Up, new PlayerStopRunningCommand(game, Direction.UP));
            //this.RegisterCommandUnpress(Keys.Left, new PlayerStopRunningCommand(game, Direction.LEFT));
            //this.RegisterCommandUnpress(Keys.Down, new PlayerStopRunningCommand(game, Direction.DOWN));
            //this.RegisterCommandUnpress(Keys.Right, new PlayerStopRunningCommand(game, Direction.RIGHT));

            //Loads in the changes room commands for manually controlling rooms
            this.RegisterCommand(Keys.Left, new LoadRoomCommand(game, Direction.LEFT));
            this.RegisterCommand(Keys.Up, new LoadRoomCommand(game, Direction.UP));
            this.RegisterCommand(Keys.Down, new LoadRoomCommand(game, Direction.DOWN));
            this.RegisterCommand(Keys.Right, new LoadRoomCommand(game, Direction.RIGHT));

            /* L and Z keys for Link attacking */
            this.RegisterCommand(Keys.B, new PlayerProjCommand(game));
            this.RegisterCommand(Keys.N, new PlayerAttackingCommand(game));

            /* Reload the current level */
            this.RegisterCommand(Keys.R, new ReloadLevelCommand(game));

            /* Quit the game */
            this.RegisterCommand(Keys.Q, new ExitCommand(game));

            /*Pause and Resume*/
            this.RegisterCommand(Keys.P, new PauseCommand(game));

            //To be able to switch between link projectiles
            this.RegisterCommand(Keys.K, new NextProjectileCommand(game));
            this.RegisterCommand(Keys.J, new PrevProjectileCommand(game));

            this.RegisterCommand(Keys.Y, new DisplayInventoryCommand(game, "Display"));
            this.RegisterCommand(Keys.T, new DisplayInventoryCommand(game, "Remove"));
        }
    }
}
