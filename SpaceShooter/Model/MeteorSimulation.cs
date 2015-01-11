using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.Model
{
    class MeteorSimulation
    {
        public Texture2D meteorTexture;
        public Vector2 position;
        public Vector2 origin;
        Meteor meteor;
        Camera camera;
        public Rectangle meteorHitBox;
        Random random = new Random();
        private int width;
        private int height;

        public float speed;
        public bool isVisible;
        
        public float randomX;
        public float randomY;



        public MeteorSimulation(int width, int height, Texture2D newTexture, Vector2 newPosition)
        {
            //Default värden
            camera = new Camera(width, height);
            meteor = new Meteor();
            this.width = width;
            this.height = height;
            this.position = new Vector2(meteor.Xpos * camera.getScale(), -meteor.Ypos * camera.getScale());
            this.meteorTexture = null;
            this.speed = camera.getScale() * meteor.speed;
            meteorTexture = newTexture;
            position = newPosition;

            randomX = random.Next(0, width);
            randomY = random.Next(-height, -50);
            isVisible = true;

        }

        public void LoadContent(ContentManager content)
        {

            this.meteorTexture = content.Load<Texture2D>("asteroid");
            //Mitten på meteoren
            //Skulle ha använts till att få meteoren att rotera, men det uppstod vissa problem så jag fick skita i det
            this.origin.X = meteorTexture.Width / 2;
            this.origin.Y = meteorTexture.Height / 2;

        }

        public void Update(GameTime gameTime)
        {
            this.meteorHitBox = new Rectangle((int)position.X, (int)position.Y, meteorTexture.Width, meteorTexture.Height);

            //Respawnar 50 pixlar utanför kameran ifall meteoren når botten
            this.position.Y = position.Y + speed;
            if (this.position.Y >= meteor.Ypos * camera.getScale())
            {
                Random random = new Random();
                float randomPos = random.Next(1, width);
                this.position.Y = -50;
                this.position.X = randomPos;
            }
        }

        

    }
}
