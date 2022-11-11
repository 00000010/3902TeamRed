using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class NextProjectileCommand : ICommand
    {
        private Game1 game;
        public NextProjectileCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            int nextProj = (int)game.manager.LinkProjectile + 1;
            if (nextProj == 1 && game.manager.inventory.Boomerangs == 0)
            {
                nextProj++;
            }
                if (nextProj >= Constants.NUM_AVAILABLE_PROJECTILES)
            {
                nextProj = 0;
            }
            game.manager.LinkProjectile = (TypeOfProj)nextProj;
        }
    }
}
