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

        public MeteorSimulation(int width, int height)
        { 
            //Default värden
            this.width = width;
            this.height = height;
            this.speed = 2;

            randomX = random.Next(0, 450);
            randomY = random.Next(-600, -50);
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
