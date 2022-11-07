using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    internal class PlayerFactory
    {
        private static PlayerFactory instance = new PlayerFactory();
        public static PlayerFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private PlayerFactory() { }

        public Player Link(Vector2 position)
        {
            return new Link(position);
        }
    }

    internal class Link : Player
    {
        public Link(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.LinkStandingUp(position);
            Velocity = Vector2.Zero;
            Direction = Direction.UP;
            State = State.STANDING;
            TakingDamage = false;
            Health = 3;
            Sprite.LayerDepth = Constants.PLAYER_LAYER_DEPTH;
        }
    }
}
