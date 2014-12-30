using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter.View
{
    class Explosion
    {
        //public Texture2D explosionTexture;
        //public Vector2 position;
        //public Vector2 origin;
        //public Rectangle rectangle;
        //public float timer;
        //public float interval;
        //public int frame;
        //public int width;
        //public int height;

        Texture2D explosion;
        private Vector2 position;
        private float timeElapsed;
        private float maxTime = 0.9f;
        private int frameRate = 24;
        private int numberOfFrames = 4;
        private int size;

        public void LoadContent(ContentManager content) {
            explosion = content.Load<Texture2D>("explosion");
            size = explosion.Bounds.Width / numberOfFrames;
            //position.X = 80;
            //position.Y = 200;
        }
        public Explosion() { 
        
        }
        public Explosion(Texture2D texture, Vector2 position) {
            this.position = position;
        }

        //public Explosion(Texture2D texture, Vector2 position) {
        //    this.position = position;
        //    explosionTexture = texture;
        //    timer = 0f;
        //    interval = 20f;
        //}


        public void Draw(SpriteBatch spriteBatch, float elapsedTime)
        {

            if (timeElapsed >= maxTime)
            {
                timeElapsed = 0;
            }
            timeElapsed += elapsedTime;
            float percentAnimated = timeElapsed / maxTime;
            int frame = (int)(percentAnimated * frameRate);
            int frameX = frame % numberOfFrames;
            int frameY = frame / numberOfFrames;

            //spriteBatch.Begin();
            spriteBatch.Draw(explosion, position, new Rectangle(frameX * size, frameY * size, size, size), Color.White);
            //spriteBatch.End();
        }

    }
}
