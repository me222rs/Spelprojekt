using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.View
{
    public class MeteorView
    {
        public Texture2D meteorTexture;
        public Vector2 position;
        public Vector2 origin;
        public float rotation;
        public float speed;
        public bool isColliding;
        public bool isDestroyed;
        public Rectangle meteorHitBox;
        private int width;
        private int height;
        Meteor meteor;
        Camera camera;

        public bool isVisible;
        Random random = new Random();
        public float randomX;
        public float randomY;



        public MeteorView(int width, int height, Texture2D newTexture, Vector2 newPosition)
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

            randomX = random.Next(0, 450);
            randomY = random.Next(-600, -50);
            isVisible = true;
            
        }

        public void LoadContent(ContentManager content) {
            this.meteorTexture = content.Load<Texture2D>("asteroid");
            //Mitten på meteoren
            this.origin.X = meteorTexture.Width / 2;
            this.origin.Y = meteorTexture.Height / 2;

        }

        public void Update(GameTime gameTime)
        {
            this.meteorHitBox = new Rectangle((int)position.X, (int)position.Y, 45, 45);

            //Respawnar 50 pixlar utanför kameran ifall meteoren når botten
            this.position.Y = position.Y + speed;
            if (this.position.Y >= meteor.Ypos * camera.getScale())
            {
                Random random = new Random();
                float randomPos = random.Next(1, width);
                this.position.Y = -50;
                this.position.X = randomPos;
            }

            ////Roterar meteoren endasat för visuell effekt, därför placerat i vyn
            ////Roteringen stör kollisionen så jag tar bort roteringen så länge
            ////http://msdn.microsoft.com/en-us/library/bb203869.aspx
            //float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //this.rotation += elapsed;
            //float circle = MathHelper.Pi * 2;
            //this.rotation = this.rotation % circle;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            if (this.isVisible)
            {

                //spriteBatch.Begin();
                spriteBatch.Draw(this.meteorTexture, this.position, null, Color.White, this.rotation, this.origin, 1.0f, SpriteEffects.None, 0);
                //spriteBatch.End();
            }
        }

        }


    }
    

