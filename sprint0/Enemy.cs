﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class Enemy : IEnemy
    {
        public Sprite Sprite { get; set; }
        public Vector2 Position { get { return Sprite.Position; } set { Sprite.Position = value; } }
        public Vector2 Velocity { get; set; }
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
        }



        //public bool projectileInMotion;
        //public Vector2 Velocity { get; set; }

        ////Constructor gets inherited from Sprite
        //public Enemy(Texture2D texture, Rectangle[] sourceRectangle, SpriteBatch spriteBatch, Vector2 position)
        //    : base(texture, sourceRectangle, spriteBatch, position)
        //{
        //    this.projectileInMotion = false;
        //}

        ////Constructor that copies an enemy 
        //public Enemy(Enemy enemy)
        //    : base(enemy.Texture, enemy.SourceRectangle, enemy.SpriteBatch, enemy.Position)
        //{
        //}

        //public override void Update(GameTime gameTime)
        //{
        //    if (projectileInMotion) return;
        //    base.Update(gameTime);
        //    //UpdateProjectile();
        //}

        ///**
        // * Handling the velocities of the different enemies
        // */
        //public override void UpdateVelocity(GameTime gameTime)
        //{
        //    //Setting the velocity's value too low to figure out if it changed
        //    Vector2 currVelocity = new Vector2(-100);
        //    EnemyVelocity.UpdateVelocity(gameTime, SourceRectangle, ref currVelocity);

        //    if (currVelocity.X != -100)
        //    {
        //        Velocity = currVelocity;
        //    }
        //}

        ///**
        // * Handling the position of the enemies
        // */
        //public override void UpdatePosition()
        //{
        //    Position += Velocity;
        //    if (Position.X > 800 || Position.X < 0)
        //    {
        //        Position = new Vector2(Position.X - Velocity.X, Position.Y);
        //    }
        //    if (Position.Y > 480 || Position.Y < 0)
        //    {
        //        Position = new Vector2(Position.X, Position.Y - Velocity.Y);
        //    }
        //}

        /**
         * Handling the frame updates for the enemies
         */
        //public override void UpdateFrame()
        //{
        //    int frame = Frame;
        //    EnemyFrame.UpdateFrame(SourceRectangle, ref frame, Velocity);
        //    Frame = frame;
        //}

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
