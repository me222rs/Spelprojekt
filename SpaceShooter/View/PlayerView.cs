﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShooter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.View
{
    /// <summary>
    /// Klassen sköter inmatning och utritning av kula och spelare
    /// </summary>
    class PlayerView
    {
        private int windowWidth;
        private int windowHeight;
        Player player;
        Camera camera;
        BulletSimulation bulletSimulation;
        //Bullet bullet;
        public Vector2 position;
        public Texture2D shipTexture;
        public Texture2D bulletTexture;
        public Rectangle shipHitBox;
        public bool isColliding;
        public float speed;
        public float scale;
        private float vx;
        private float vy;
        private float diameter;
        BulletView bulletView;


        //Skjuta
        public List<Bullet> bulletList;
        public int bulletDelay = 10;

        public PlayerView(int width, int height)
        {
            bulletList = new List<Bullet>();
            this.shipTexture = null;
            this.isColliding = false;
            

            //Sätter fönstrets storlek
            this.windowWidth = width;
            this.windowHeight = height;

            //Skapar instanser av Player och Camera
            this.player = new Player();
            this.camera = new Camera(width, height);
            this.bulletSimulation = new BulletSimulation(bulletTexture);
            this.speed = camera.getScale() * player.speed;
            this.diameter = camera.getScale() * player.diameter;

            //Spelarens position
            this.vx = player.xPos * camera.getScale();
            this.vy = player.yPos * camera.getScale();
            this.position = new Vector2(vx, vy);
            
        }

        public void LoadContent(ContentManager Content)
        {
            this.shipTexture = Content.Load<Texture2D>("ship");
            this.bulletTexture = Content.Load<Texture2D>("playerbullet");
            bulletView = new BulletView(bulletTexture);
            //bullet = new Bullet(bulletTexture);
        }

        public void Update(GameTime gameTime)
        {

            shipHitBox = new Rectangle((int)position.X, (int)position.Y, shipTexture.Width, shipTexture.Height);


            //Spelets kontroller läses in
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                this.position.Y = this.position.Y - this.speed;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                this.position.Y = this.position.Y + this.speed;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                this.position.X = this.position.X - this.speed;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                this.position.X = this.position.X + this.speed;
            }
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                this.bulletList = bulletSimulation.PlayerShoot(position, this.bulletList, bulletTexture);
                //PlayerShoot();
            }

            this.bulletList = bulletSimulation.UpdateBullet(this.bulletList);
            //UpdateBullet();


            Vector2 screenposMax;
            Vector2 modelpos = new Vector2(1.0f, 1.0f);
            screenposMax = camera.getViewPosPic(modelpos, shipTexture);

            PlayerSimulation ps = new PlayerSimulation();
            this.position = ps.isCollidingWithBorders(this.position, screenposMax);


        }

        public void Draw(SpriteBatch spriteBatch)
        {

            //BulletView bv = new BulletView();
            //spriteBatch.Draw(this.shipTexture, this.position, shipHitBox, Color.White);
            spriteBatch.Draw(this.shipTexture, this.position, Color.White);
            foreach (Bullet bullet in bulletList)
            {
                Vector2 pos = bullet.position;
                bulletView.Draw(spriteBatch, pos);
            }
        }
    }
}
