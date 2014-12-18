using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.Model
{
    class MeteorSimulation
    {
        public Texture2D meteor;
        public Vector2 position;
        public Vector2 origin;
        public float rotation;
        public int speed;
        public bool isColliding;
        public bool isDestroyed;
        public Rectangle meteorHitBox;
        private int width;
        private int height;
        //public Texture2D meteorTexture;

        public bool isVisible;
        Random random = new Random();
        public float randomX;
        public float randomY;

        public MeteorSimulation(int width, int height) { 
            //Default värden
            this.width = width;
            this.height = height;
            //this.position = new Vector2(200, -50);
            //this.meteor = null;
            this.speed = 2;
            //meteor = newTexture;
            //position = newPosition;

            randomX = random.Next(0, 450);
            randomY = random.Next(-600, -50);
            //meteorTexture = null;
        }

        public void Update(GameTime gameTime)
        {
            this.meteorHitBox = new Rectangle((int)position.X, (int)position.Y, 45, 45);

            //Respawnar 50 pixlar utanför kameran ifall meteoren når botten
            this.position.Y = position.Y + speed;
            if (this.position.Y >= 650)
            {
                Random random = new Random();
                float randomPos = random.Next(1, width);
                this.position.Y = -50;
                this.position.X = randomPos;
            }

            //Roterar meteoren
            //http://msdn.microsoft.com/en-us/library/bb203869.aspx
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.rotation += elapsed;
            float circle = MathHelper.Pi * 2;
            this.rotation = this.rotation % circle;

        }

        public Vector2 getPosition() {
            return position;
        }
        public Texture2D getTexture() {
            return meteor;
        }
        public float getRotation() {
            return rotation;
        }
        public Vector2 getOrigin() {
            return origin;
        }

    }
}
