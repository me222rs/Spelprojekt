using Microsoft.Xna.Framework;
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
            //this.bulletSimulation = new BulletSimulation(bulletTexture);
            this.speed = camera.getScale() * player.speed;
            this.diameter = camera.getScale() * player.diameter;
            

            //Hämtar skalan
            //this.scale = camera.getScale();
            //this.camera.setDimensions(width, height);

            //Spelarens position
            this.vx = player.xPos * camera.getScale();
            this.vy = player.yPos * camera.getScale();
            this.position = new Vector2(vx, vy);
            
        }

        public void LoadContent(ContentManager Content)
        {
            this.shipTexture = Content.Load<Texture2D>("ship");
            this.bulletTexture = Content.Load<Texture2D>("playerbullet");
            //bullet = new Bullet(bulletTexture);
        }

        public void Update(GameTime gameTime)
        {

            //Spelets kontroller
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
                PlayerShoot();
            }
            UpdateBullet();


            Vector2 screenposMax;
            Vector2 modelpos = new Vector2(1.0f, 1.0f);
            screenposMax = camera.getViewPosPic(modelpos, shipTexture);

            PlayerSimulation ps = new PlayerSimulation();
            this.position = ps.isCollidingWithBorders(this.position, screenposMax);



            ////Kollision med kanterna
            //if (this.position.X <= 0.0f)
            //{
            //    this.position.X = 0.0f;
            //}
            //if (this.position.Y <= 0.0f)
            //{
            //    this.position.Y = 0.0f;
            //}
            //if (this.position.X >= screenposMax.X)
            //{
            //    this.position.X = screenposMax.X;
            //}
            //if (this.position.Y >= screenposMax.Y)
            //{
            //    this.position.Y = screenposMax.Y;
            //}



        }

        public void PlayerShoot()
        {
            if (bulletDelay >= 0)
            {
                bulletDelay--;
            }
            if (bulletDelay <= 0)
            {
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.position = new Vector2(position.X + 32 - newBullet.bullet.Width / 2, position.Y + 30);
                newBullet.isVisible = true;
                if (bulletList.Count() < 2000)
                {
                    bulletList.Add(newBullet);
                }
            }

            if (bulletDelay == 0)
            {
                bulletDelay = 10;
            }
        }

        public void UpdateBullet()
        {
            foreach (Bullet bullet in bulletList)
            {
                bullet.position.Y = bullet.position.Y - bullet.speed;

                if (bullet.position.Y >= 0)
                {
                    bullet.isVisible = false;
                }

                for (int i = 0; i > bulletList.Count; i++)
                {
                    if (bulletList[i].isVisible)
                    {
                        bulletList.RemoveAt(i);
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            //BulletView bv = new BulletView();
            //spriteBatch.Draw(this.shipTexture, this.position, shipHitBox, Color.White);
            spriteBatch.Draw(this.shipTexture, this.position, Color.White);
            foreach (Bullet bullet in bulletList)
            {
                bullet.Draw(spriteBatch);
            }
        }
    }
}
