using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    internal class Enemy : Sprite, IEnemy
    {
        private List<IEnemy> enemies;
        private int currEnemy;

        //Constructor gets inherited from Sprite
        public Enemy(Texture2D texture, Rectangle[] sourceRectangle, SpriteBatch spriteBatch, Vector2 position, Vector2 velocity) 
            : base(texture, sourceRectangle, spriteBatch, position, velocity)
        {
            this.currEnemy = 0;
        }

        public IEnemy Next()
        {
            currEnemy++;
            if (currEnemy >= enemies.Count)
            {
                currEnemy = 0;
            }
            return enemies[currEnemy];
        }

        public IEnemy Prev()
        {
            currEnemy--;
            if (currEnemy < 0)
            {
                currEnemy = enemies.Count - 1;
            }
            return enemies.ElementAt(currEnemy);
        }
    }
}
