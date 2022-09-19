using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client
{
    internal class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update(GameTime gameTime)
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
                }
            }
        }
        public void LoadDefaultKeys(Game1 game)
        {
            this.RegisterCommand(Keys.Escape, new ExitCommand(game));
            this.RegisterCommand(Keys.D0, new ExitCommand(game));
            this.RegisterCommand(Keys.D1, new LuigiStandingRightStillCommand(game));
            this.RegisterCommand(Keys.D2, new LuigiRunningRightStillCommand(game));
            this.RegisterCommand(Keys.D3, new LuigiStandingRightMovingCommand(game));
            this.RegisterCommand(Keys.D4, new LuigiRunningRightMovingCommand(game));
        }
    }
}
