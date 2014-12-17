using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.View
{
    /// <summary>
    /// Ritar ut den rullande bakgrunden, endast för visuella effekter, därför placerat i en vy
    /// </summary>
    class SpaceBackgroundView
    {
        public Texture2D space;
        public Vector2 bgPosition1, bgPosition2;
        public float speed = 5.0f;
        private int width;
        private int height;

        public SpaceBackgroundView(int width, int height) {
            this.height = height;
            this.width = width;
            this.space = null;
            this.bgPosition1 = new Vector2(0, 0);
            this.bgPosition2 = new Vector2(0, -this.height);
        }

        public void LoadContent(ContentManager content) {
            space = content.Load<Texture2D>("space");
        }

        public void Update(GameTime gameTime) {
            bgPosition1.Y = bgPosition1.Y + this.speed;
            bgPosition2.Y = bgPosition2.Y + this.speed;

            if(bgPosition1.Y >= this.height){
                bgPosition1.Y = 0;
                bgPosition2.Y = -this.height;
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(space, bgPosition1, Color.White);
            spriteBatch.Draw(space, bgPosition2, Color.White);
        }


    }
}
