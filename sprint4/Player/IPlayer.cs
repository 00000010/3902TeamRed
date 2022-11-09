using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public interface IPlayer : IUpdateable, IDrawable
    {
        public Sprite Sprite { get; set; }
        public Vector2 Position { get { return Sprite.Position; } set { Sprite.Position = value; } }
        public Vector2 Velocity { get { return Sprite.Velocity; } set { Sprite.Velocity = value; } }
        public Direction Direction { get; set; }
        public State State { get; set; }
        public bool TakingDamage { get; set; }
        public GameTime LastDamaged { get; set; }
        public int Damaged { get; set; }
        public string TypeOfObject { get; set; }
        public bool ShotBoomerang { get; set; }
        public int Health { get; set; }
        public void UpdatePlayerSprite(GameObjectManager manager);
        public void UpdatePlayerState();
    }
}
