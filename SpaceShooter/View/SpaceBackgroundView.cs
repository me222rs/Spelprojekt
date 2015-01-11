using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.View
{

    class SpaceBackgroundView
    {
        public Texture2D space;
        public Vector2 position1;
        public Vector2 position2;
        public float speed = 10.0f;
        private int width;
        private int height;

        public SpaceBackgroundView(int width, int height) {
            this.height = height;
            this.width = width;
            this.space = null;
            this.position1 = new Vector2(0, 0);
            this.position2 = new Vector2(0, -this.height);
        }

        public void LoadContent(ContentManager content) {
            space = content.Load<Texture2D>("space3");
        }

        public void Update(GameTime gameTime) {
            position1.Y = position1.Y + this.speed;
            position2.Y = position2.Y + this.speed;

            if(position1.Y >= this.height){
                position1.Y = 0;
                position2.Y = -this.height;
            }
        }

        //Ritar ut samma bakgrund
        //Den ena ritas ut ovanpå den andra och därmed får man en typ oändlig bakgrund
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(space, position1, Color.White);
            spriteBatch.Draw(space, position2, Color.White);
        }


    }
}
