using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace sprint0
{
    internal class LinkDamagedCommand : ICommand
    {
        private Game1 game;
        public LinkDamagedCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if (this.game.player is Sprite)
            {
                Sprite player = (Sprite)this.game.player;

                Console.WriteLine("X: " + player.SourceRectangle[0].X);
                Console.WriteLine("Y: " + player.SourceRectangle[0].Y);
                SpriteRectangle sR = new LinkRectangle(player.SourceRectangle[0].X, player.SourceRectangle[0].Y);
                sR = new Damaged(sR);
                player.SourceRectangle = sR.SourceRectangle(sR);

                player.Frame = 0;
                player.Velocity = new Vector2(0, 0);
            }
        }
    }
}
