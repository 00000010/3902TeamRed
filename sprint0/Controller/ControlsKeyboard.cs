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
    public class ControlsKeyboard : IController
    {
        private Game1 game;
        private KeyboardController keyboard;

        private bool enabled = false; // TODO: for if keyboard will have enable/disable capability; delete if not using

        public Keys firstPressedKey = Keys.None;

        private Keys[] prevPressedKeys = new Keys[0];

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public ControlsKeyboard(Game1 game, ref KeyboardController keyboard)
        {
            this.game = game;
            this.keyboard = keyboard; 
        }

        public void Update(GameTime gameTime)
        {
            if (enabled)
            {
                Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

                foreach (Keys key in pressedKeys)
                {
                    if (key.Equals(Keys.X)) continue;

                    if (key == Keys.Z)
                    {
                        ICommand command = new DisplayRoomCommand(game, "Remove", "RoomControls");
                        command.Execute();
                        break;
                    }

                    //If nothing has been pressed yet just save the first pressed key
                    if (firstPressedKey == Keys.None && !prevPressedKeys.Contains(key) && !keyboard.GetAction(key).Equals(KeyboardAction.FAULTY))
                    {
                        firstPressedKey = key;
                        break;
                    }
                    /*
                     * If a key has been pressed before then get the second key and 
                     * change the mapping of the first key to the second key
                     */
                    if (!prevPressedKeys.Contains(key) && keyboard.GetAction(key).Equals(KeyboardAction.FAULTY))
                    {
                        KeyboardAction prevAction = keyboard.GetAction(firstPressedKey);
                        keyboard.actionsToKeys[(int)prevAction] = key;
                        firstPressedKey = Keys.None;
                        break;
                    }
                }
                this.prevPressedKeys = pressedKeys;
            }
        }

        public void EnableControlsKeyboard()
        {
            this.enabled = true;
        }
        public void DisableControlsKeyboard()
        {
            this.enabled = false;
        }
    }
}
