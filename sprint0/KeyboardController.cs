﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace sprint0
{
    internal class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;

        private Keys[] prevPressedKeys = new Keys[0];

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
            this.RegisterCommand(Keys.A, new LinkRunningLeftCommand(game));
            this.RegisterCommand(Keys.W, new LinkRunningDownCommand(game));
            this.RegisterCommand(Keys.S, new LinkRunningUpCommand(game));
            this.RegisterCommand(Keys.D, new LinkRunningRightCommand(game));

            this.RegisterCommand(Keys.Left, new LinkRunningLeftCommand(game));
            this.RegisterCommand(Keys.Up, new LinkRunningDownCommand(game));
            this.RegisterCommand(Keys.Down, new LinkRunningUpCommand(game));
            this.RegisterCommand(Keys.Right, new LinkRunningRightCommand(game));

            /* N and Z keys for Link attacking */
            this.RegisterCommand(Keys.Z, new LinkAttackingCommand(game));
            this.RegisterCommand(Keys.N, new LinkAttackingCommand(game));

            /* E key for Link being damaged in whatever state he's in */
            this.RegisterCommand(Keys.E, new LinkDamagedCommand(game));

            /* R key for resetting Link */
            this.RegisterCommand(Keys.R, new ResetCommand(game));

            /* Quit the game */
            this.RegisterCommand(Keys.Q, new ExitCommand(game));
        }
    }
}
