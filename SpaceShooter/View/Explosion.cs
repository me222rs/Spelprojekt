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
        public int frame;
        public int width;
        public Vector2 position;
        public Texture2D explosionTexture;
        public int time;
        public int speed;
        public Vector2 origin;
        public int height;
        public Rectangle sourceRect;
        public bool isVisible;
        public int images;

        //En enkel metod som ritar ut en explosion
        //Allt man behöver göra är att sätta hur hög och bred varje bild är i spriten så ritar den ut
        public Explosion(Texture2D newTexture, Vector2 newPosition) {
            time = 0;
            //Lägre nummer = snabbare animering
            speed = 20;
            frame = 1;
            position = newPosition;
            explosionTexture = newTexture;
            //Sätt bredd och höjd här
            width = 128;
            height = 128;
            isVisible = true;
            images = explosionTexture.Width / width;
        }
        public Explosion() { 
        
        }


 
        public void Update(GameTime gameTime) {
            time += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (time > speed) {
                frame++;
                time = 0;
            }

            if(frame == images){
                frame = 0;
                isVisible = false;
            }

            sourceRect = new Rectangle(frame * width, 0, width, height);
            origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);
        }

        public void Draw(SpriteBatch spriteBatch) {
            if (isVisible) {
                spriteBatch.Draw(explosionTexture, position, sourceRect, Color.White, 0f, origin, 1f, SpriteEffects.None, 0);
            }
        }

    }
}
