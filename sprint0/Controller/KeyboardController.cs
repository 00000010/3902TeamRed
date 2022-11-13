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
    public class KeyboardController : IController
    {
        private Dictionary<KeyboardAction, ICommand> controllerMappings;
        private Dictionary<KeyboardAction, ICommand> controllerMappingsUnpress;
        public List<Keys> actionsToKeys;

        private bool enabled = true; // TODO: for if keyboard will have enable/disable capability; delete if not using

        private Keys[] prevPressedKeys = new Keys[0];

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public KeyboardController()
        {
            controllerMappings = new Dictionary<KeyboardAction, ICommand>();
            controllerMappingsUnpress = new Dictionary<KeyboardAction, ICommand>();
            actionsToKeys = new List<Keys>();
        }

        public void RegisterCommand(KeyboardAction key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void RegisterCommandUnpress(KeyboardAction key, ICommand command)
        {
            controllerMappingsUnpress.Add(key, command);
        }

        public void Update(GameTime gameTime)
        {
            if (enabled)
            {
                Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

                foreach (Keys key in prevPressedKeys)
                {
                    KeyboardAction action = GetAction(key);
                    if (controllerMappingsUnpress.ContainsKey(action) && !pressedKeys.Contains(key))
                    {
                        controllerMappingsUnpress[action].Execute();
                    }
                }

                foreach (Keys key in pressedKeys)
                {
                    KeyboardAction action = GetAction(key);
                    if (controllerMappings.ContainsKey(action) && !prevPressedKeys.Contains(key))
                    {
                        controllerMappings[action].Execute();
                    }
                }
                this.prevPressedKeys = pressedKeys;
            }
        }

        public void LoadDefaultKeys(Game1 game)
        {
            /* WASD and arrow keys for moving Link around */
            this.RegisterCommand(KeyboardAction.UP, new PlayerRunningCommand(game, Direction.UP));
            this.RegisterCommand(KeyboardAction.LEFT, new PlayerRunningCommand(game, Direction.LEFT));
            this.RegisterCommand(KeyboardAction.DOWN, new PlayerRunningCommand(game, Direction.DOWN));
            this.RegisterCommand(KeyboardAction.RIGHT, new PlayerRunningCommand(game, Direction.RIGHT));

            this.RegisterCommandUnpress(KeyboardAction.UP, new PlayerStopRunningCommand(game, Direction.UP));
            this.RegisterCommandUnpress(KeyboardAction.LEFT, new PlayerStopRunningCommand(game, Direction.LEFT));
            this.RegisterCommandUnpress(KeyboardAction.DOWN, new PlayerStopRunningCommand(game, Direction.DOWN));
            this.RegisterCommandUnpress(KeyboardAction.RIGHT, new PlayerStopRunningCommand(game, Direction.RIGHT));

            /*UNCOMMENT FOR TESTING*/
            //this.RegisterCommand(KeyboardAction.LEFT, new LoadRoomCommand(game, Direction.LEFT));
            //this.RegisterCommand(KeyboardAction.UP, new LoadRoomCommand(game, Direction.UP));
            //this.RegisterCommand(KeyboardAction.DOWN, new LoadRoomCommand(game, Direction.DOWN));
            //this.RegisterCommand(KeyboardAction.RIGHT, new LoadRoomCommand(game, Direction.RIGHT));


            /* L and Z keys for Link attacking */
            this.RegisterCommand(KeyboardAction.SHOOT, new PlayerProjCommand(game));
            this.RegisterCommand(KeyboardAction.STAB, new PlayerAttackingCommand(game));

            /* Quit the game */
            this.RegisterCommand(KeyboardAction.EXIT, new ExitCommand(game));

            /*Pause and Resume*/
            this.RegisterCommand(KeyboardAction.PAUSE, new PauseCommand(game));

            //To be able to switch between link projectiles
            this.RegisterCommand(KeyboardAction.NEXTPROJECTILE, new NextProjectileCommand(game));
            this.RegisterCommand(KeyboardAction.PREVPROJECTILE, new PrevProjectileCommand(game));

            this.RegisterCommand(KeyboardAction.SHOWINVENTORY, new DisplayRoomCommand(game, "Display", "RoomInventory"));
            this.RegisterCommand(KeyboardAction.HIDEINVENTORY, new DisplayRoomCommand(game, "Remove", "RoomInventory"));

            this.RegisterCommand(KeyboardAction.SHOWCONTROLS, new DisplayRoomCommand(game, "Display", "RoomControls"));
            this.RegisterCommand(KeyboardAction.HIDECONTROLS, new DisplayRoomCommand(game, "Remove", "RoomControls"));

            MapActionsToKeys();
        }

        private void MapActionsToKeys()
        {
            actionsToKeys.Add(Keys.W);
            actionsToKeys.Add(Keys.S);
            actionsToKeys.Add(Keys.A);
            actionsToKeys.Add(Keys.D);
            actionsToKeys.Add(Keys.P);
            actionsToKeys.Add(Keys.U);
            actionsToKeys.Add(Keys.R);
            actionsToKeys.Add(Keys.Y);
            actionsToKeys.Add(Keys.T);
            actionsToKeys.Add(Keys.B);
            actionsToKeys.Add(Keys.N);
            actionsToKeys.Add(Keys.Q);
            actionsToKeys.Add(Keys.K);
            actionsToKeys.Add(Keys.J);
            actionsToKeys.Add(Keys.X);
            actionsToKeys.Add(Keys.Z);
        }

        public void EnableKeyboard()
        {
            this.enabled = true;
        }

        public void DisableKeyboard()
        {
            this.enabled = false;
        }

        public KeyboardAction GetAction(Keys key)
        {
            KeyboardAction result = KeyboardAction.FAULTY;
            for (int i = 0; i < actionsToKeys.Count; i++)
            {
                //Get the keyboard action that corresponds to the key input
                if (key.Equals(actionsToKeys[i]))
                {
                    result = (KeyboardAction)i;
                }
            }
            return result;
        }

        public Keys GetKey(KeyboardAction action)
        {
            return actionsToKeys[(int)action];
        }
    }
}
