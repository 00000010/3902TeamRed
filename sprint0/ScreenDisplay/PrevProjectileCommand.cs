using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class PrevProjectileCommand : ICommand
    {
        private Game1 game;
        public PrevProjectileCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            int nextProj = (int)game.manager.LinkProjectile - 1;
            if (nextProj == 1 && game.manager.numBoomerangs == 0)
            {
                nextProj--;
            }
            if (nextProj < 0)
            {
                nextProj = Constants.NUM_AVAILABLE_PROJECTILES - 1;
            }
            game.manager.LinkProjectile = (TypeOfProj)nextProj;
        }
    }
}
