using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace sprint0
{
    internal class ResetCommand : ICommand
    {
        private Game1 game;
        public ResetCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if (this.game.player is Sprite)
            {
                Sprite player = (Sprite)this.game.player;

                SpriteRectangle sR = new LinkRectangle();
                player.SourceRectangle = new Rectangle[1];
                player.SourceRectangle[0] = new Rectangle(Constants.STARTING_LINK_POSITION_X, Constants.STARTING_LINK_POSITION_Y, Constants.LINK_WIDTH, Constants.LINK_HEIGHT);
                player.Position = new Vector2(Constants.STARTING_LINK_POSITION_X, Constants.STARTING_LINK_POSITION_Y);

                /* Put reset of starting states of enemies, projectiles, items, etc. */
                player.Frame = 0;
                player.Velocity = new Vector2(0, 0);
            }
        }
    }
}
