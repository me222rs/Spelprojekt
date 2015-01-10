using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShooter.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.Model
{
    class PlayerModel
    {
                private int windowWidth;
        private int windowHeight;
        Player player;
        Camera camera;
        BulletSimulation bulletSimulation;
        //Bullet bullet;
        public Vector2 position;
        public Vector2 healthBarPosition;
        public Texture2D shipTexture;
        public Texture2D bulletTexture;
        public Texture2D healthTexture;
        public Rectangle shipHitBox;
        public Rectangle healthBox;
        public int health;
        public bool isColliding;
        public float speed;
        public float scale;
        private float vx;
        private float vy;
        private float diameter;
        BulletView bulletView;
        Sound s = new Sound();
        private Texture2D sbv;


        //Skjuta
        public List<Bullet> bulletList;
        public int bulletDelay = 10;

        public PlayerModel(int width, int height, Texture2D sbv)
        {
            bulletList = new List<Bullet>();
            this.shipTexture = null;
            this.isColliding = false;
            this.sbv = sbv;

            //Sätter fönstrets storlek
            this.windowWidth = width;
            this.windowHeight = height;

            Vector2 v2 = new Vector2(width, height);
            //Skapar instanser av Player och Camera
            this.player = new Player();
            this.camera = new Camera(width, height);
            this.bulletSimulation = new BulletSimulation(bulletTexture);
            this.speed = camera.getScale() * player.speed;
            this.diameter = camera.getScale() * player.diameter;

            //Spelarens position
            //this.vx = player.xPos;
            //this.vy = player.yPos;
            this.vx = player.xPos * camera.getScale();
            this.vy = player.yPos * camera.getScale();
            this.position = new Vector2(vx, vy);
            this.health = 200;
            this.healthBarPosition = new Vector2(25, 25);
            
        }

        public void LoadContent(ContentManager Content)
        {
            this.shipTexture = Content.Load<Texture2D>("playerShip1_blue");
            this.bulletTexture = Content.Load<Texture2D>("playerbullet");
            this.healthTexture = Content.Load<Texture2D>("healthbar");
            bulletView = new BulletView(bulletTexture);
            s.LoadContent(Content);
            //bullet = new Bullet(bulletTexture);
        }

        public void Update(GameTime gameTime)
        {

            shipHitBox = new Rectangle((int)position.X, (int)position.Y, shipTexture.Width, shipTexture.Height);

            healthBox = new Rectangle((int)healthBarPosition.X, (int)healthBarPosition.Y, health, 25);
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
                this.bulletList = bulletSimulation.PlayerShoot(position, this.bulletList, bulletTexture, s);
                //s.shoot.Play();
                //PlayerShoot();
            }

            this.bulletList = bulletSimulation.UpdateBullet(this.bulletList);
            //UpdateBullet();


            Vector2 screenposMax;
            Vector2 modelpos = new Vector2(1.0f, 1.0f);
            screenposMax = camera.getViewPosPic(modelpos, shipTexture);
            Vector2 maxPos = new Vector2(windowWidth, windowHeight);
            PlayerSimulation ps = new PlayerSimulation();
            this.position = ps.isCollidingWithBorders(this.position, maxPos, shipTexture, sbv);


        }
    }
}
