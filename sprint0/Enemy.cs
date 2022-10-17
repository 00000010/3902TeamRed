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
    public class Enemy : IEnemy, IObject
    {
        public Sprite Sprite { get; set; }
        public Vector2 Position { get { return Sprite.Position; } set { Sprite.Position = value; } }
        public Vector2 Velocity { get { return Sprite.Velocity; } set { Sprite.Velocity = value; } }
        public Direction Direction { get; set; }
        public State State { get; set; }

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public virtual void Draw(GameTime gameTime)
        {
            Sprite.Draw(gameTime);
        }

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            UpdateEnemyVelocity(gameTime);
        }


        /**
         * handling the velocities of the different enemies
         */
        public void UpdateEnemyVelocity(GameTime gametime)
        {
            //dummy values for currVelocity and testSprite
            Vector2 currVelocity = new Vector2(-100);
            Sprite testSprite = SpriteFactory.Instance.ZeldaArrow(Position);
            EnemyVelocity.UpdateVelocity(gametime, Sprite.SourceRectangle, ref currVelocity, ref testSprite);

            if (currVelocity.X != -100)
            {
                Velocity = currVelocity;
            }
            if (testSprite.SourceRectangle != ItemRectangle.BowArrow)
            {
                Sprite = testSprite;
            }
        }

        //protected void UpdateProjectile()
        //{
        //    if (SourceRectangle == EnemyRectangle.Goriya)
        //    {
        //        UpdateEnemyProjectile("boomerang");
        //    }
        //    else if (SourceRectangle == EnemyRectangle.Octorok)
        //    {
        //        UpdateEnemyProjectile("rock");
        //    }
        //}

        //protected void UpdateEnemyProjectile(String projectile)
        //{
        //    //Randomizing when to shoot projectile
        //    Random randomGen = new Random();
        //    int shouldShoot = randomGen.Next(0, 50);
        //    if (shouldShoot == 0)
        //    {
        //        ShootProjectileCommand command = new ShootProjectileCommand(projectile);
        //        command.Execute();
        //        projectileInMotion = true;
        //    }
        //}
    }
}
