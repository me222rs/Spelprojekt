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
        public Vector2 position;
        public Texture2D ship;
        public Rectangle shipRectangle;
        public bool isColliding;
        public float speed;
        public float scale;
        private float vx;
        private float vy;

        public PlayerView(int width, int height)
        {
            this.ship = null;
            this.speed = 5.0f;
            this.isColliding = false;

            //Sätter fönstrets storlek
            this.windowWidth = width;
            this.windowHeight = height;

            //Skapar instanser av Player och Camera
            this.player = new Player();
            this.camera = new Camera(width, height);

            //Hämtar skalan
            this.scale = camera.getScale();

            //Spelarens position
            this.vx = player.xPos;
            this.vy = player.yPos;
            this.position = new Vector2(vx, vy);
            
        }

        public void LoadContent(ContentManager Content) {
            this.ship = Content.Load<Texture2D>("ship");
        }

        public void Update(GameTime gameTime) {

            //Spelets kontroller
            KeyboardState keyboardState = Keyboard.GetState();

            if(keyboardState.IsKeyDown(Keys.Up)){
                this.position.Y = this.position.Y - this.speed;
            }
            if (keyboardState.IsKeyDown(Keys.Down)){
                this.position.Y = this.position.Y + this.speed;
            }
            if (keyboardState.IsKeyDown(Keys.Left)){
                this.position.X = this.position.X - this.speed;
            }
            if (keyboardState.IsKeyDown(Keys.Right)){
                this.position.X = this.position.X + this.speed;
            }

            //Kollision med kanterna
            //Fungerar inte med logiska kordinater
            if(this.position.X <= 0.0f){
                this.position.X = 0.0f;
            }
            if (this.position.Y <= 0.0f){
                this.position.Y = 0.0f;
            }
            if (this.position.X >= windowWidth - ship.Width){
                this.position.X = windowWidth - ship.Width;
            }
            if (this.position.Y >= windowHeight - ship.Height){
                this.position.Y = windowHeight - ship.Height;
            }


        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(this.ship, this.position, Color.White);
        }
    }
}
