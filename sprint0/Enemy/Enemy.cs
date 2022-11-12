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
    public class Enemy : IEnemy, IObject, IShooter
    {
        public Sprite Sprite { get; set; }
        public Vector2 Position { get { return Sprite.Position; } set { Sprite.Position = value; } }
        public Vector2 Velocity { get { return Sprite.Velocity; } set { Sprite.Velocity = value; } }
        public Direction Direction { get; set; }
        public bool ShotBoomerang { get; set; }
        public State State { get; set; }
        public string TypeOfObject { get; set; }
        public int Health { get; set; }
        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public int CollideDamage { get; set; }
        public float elapsedTime { get; set; }

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
            if (ShotBoomerang) return;
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
            Sprite testSprite = SpriteFactory.Instance.ZeldaArrowUp(Position); // TODO: changed from BowArrow to BowArrowUp; don't think this makes a difference
            elapsedTime += (float)gametime.ElapsedGameTime.TotalSeconds;
            EnemyVelocity.UpdateVelocity(gametime, Sprite.SourceRectangle, ref currVelocity, ref testSprite, elapsedTime, Velocity);

            if (currVelocity.X != -100)
            {
                Velocity = currVelocity;
            }
            if (testSprite.SourceRectangle != ItemRectangle.BowArrowUp) // TODO: changed from BowArrow to BowArrowUp; don't think this makes a difference
            {
                Sprite = testSprite;
            }
            if (elapsedTime >= 1)
            {
                elapsedTime = 0;
            }
        }

        public static void UpdateEnemyProjectiles(Game1 game, List<IEnemy> enemies)
        {
            for (int i = 0; i < enemies.Count && EnemyCanShoot(enemies[i], game.manager.setOfEnemyShooters); i++)
            {
                Random randomGen = new Random();
                int shouldShoot = randomGen.Next(0, 500);
                if (shouldShoot == 0)
                {
                    Type typeOfEnemy = enemies[i].GetType();
                    string enemyTypeName = typeOfEnemy.Name;
                    ICommand command = new EnemyProjectileCommand(game, enemies[i], enemyTypeName);
                    command.Execute();
                }
            }
        }

        private static Boolean EnemyCanShoot(IEnemy enemy, HashSet<string> setOfEnemyShooters)
        {
            Type typeOfEnemy = enemy.GetType();
            string enemyTypeName = typeOfEnemy.Name;
            return setOfEnemyShooters.Contains(enemyTypeName);
        }
    }
}