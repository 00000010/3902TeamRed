using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace sprint0.Controllers
{
    internal class KeyboardController : IController
    {
        private Dictionary<Keys, Interfaces.ICommand> controllerMappings;

        private Keys[] prevPressedKeys = new Keys[0];

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, Interfaces.ICommand>();
        }
        public void RegisterCommand(Keys key, Interfaces.ICommand command)
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

            prevPressedKeys = pressedKeys;
        }

        public void LoadDefaultKeys(Game1 game)
        {
            /* WASD and arrow keys for moving Link around */
            RegisterCommand(Keys.A, new Commands.LinkRunningLeftCommand(game));
            RegisterCommand(Keys.W, new Commands.LinkRunningDownCommand(game));
            RegisterCommand(Keys.S, new Commands.LinkRunningUpCommand(game));
            RegisterCommand(Keys.D, new Commands.LinkRunningRightCommand(game));

            RegisterCommand(Keys.Left, new Commands.LinkRunningLeftCommand(game));
            RegisterCommand(Keys.Up, new Commands.LinkRunningDownCommand(game));
            RegisterCommand(Keys.Down, new Commands.LinkRunningUpCommand(game));
            RegisterCommand(Keys.Right, new Commands.LinkRunningRightCommand(game));

            /* N and Z keys for Link attacking */
            RegisterCommand(Keys.Z, new Commands.LinkAttackingCommand(game));
            RegisterCommand(Keys.N, new Commands.LinkAttackingCommand(game));

            /* E key for Link being damaged in whatever state he's in */
            RegisterCommand(Keys.E, new Commands.LinkDamagedCommand(game));

            /* R key for resetting Link */
            RegisterCommand(Keys.R, new Commands.ResetCommand(game));

            /* Quit the game */
            RegisterCommand(Keys.Q, new ExitCommand(game));

            RegisterCommand(Keys.O, new Commands.PrevEnemyCommand(game));
            RegisterCommand(Keys.P, new Commands.NextEnemyCommand(game));
            RegisterCommand(Keys.L, new Commands.ShootProjectileCommand(game));
            RegisterCommand(Keys.I, new Commands.NextItemCommand(game));
            RegisterCommand(Keys.U, new Commands.PrevItemCommand(game));
            RegisterCommand(Keys.T, new Commands.NextBlockCommand(game));
            RegisterCommand(Keys.Y, new Commands.PrevBlockCommand(game));
        }
    }
}