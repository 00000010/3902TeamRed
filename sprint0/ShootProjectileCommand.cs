using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    internal class ShootProjectileCommand : ICommand
    {
        private Game1 game;
        public GameObjectManager manager;
        public ShootProjectileCommand(Game1 game)
        {
            this.game = game;
            this.manager = game.manager;
        }

         public void Execute()
        {
            if(this.game.arrow is Sprite)
            {
                Sprite arrow = (Sprite)this.game.arrow;
                Sprite copy = (Sprite)arrow.Clone();
                copy.Position = this.game.player.Position;
                copy.Velocity = new Vector2(10, 0);
                copy.SourceRectangle = SpriteRectangle.arrowRight;
                manager.addArrow(copy);
                Console.WriteLine("new?");
            }
        }
    }
}

