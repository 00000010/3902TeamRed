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

        public Player Pointer(Vector2 position)
        {
            return new Pointer(position);
        }
    }

    internal class Link : Player
    {
        public Link(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.LinkStandingRight(position);
            Velocity = Vector2.Zero;
            Direction = Direction.RIGHT;
            State = State.STANDING;
            TakingDamage = false;
            TypeOfObject = "Player";
            Health = 100;
        }
    }

    internal class Pointer : Player
    {
        public Pointer(Vector2 position)
        {
            Sprite = SpriteFactory.Instance.ZeldaArrowRight(position);
            Velocity = Vector2.Zero;
        }
    }
}
