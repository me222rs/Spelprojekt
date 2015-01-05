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
        public Vector2 position;
        public Texture2D texture;
        public float timer;
        public float interval;
        public Vector2 origin;
        public int currentFrame;
        public int spriteWidth;
        public int spriteHeight;
        public Rectangle srcRect;
        public bool isVisible;

        public Explosion(Texture2D newTexture, Vector2 newPosition) {
            position = newPosition;
            texture = newTexture;
            timer = 0f;
            interval = 40f;
            currentFrame = 1;
            spriteWidth = 128;
            spriteHeight = 128;
            isVisible = true;
        }

        public void LoadContent(ContentManager content) { 
            
        }

        public void Update(GameTime gameTime) {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval) {
                currentFrame++;
                timer = 0;
            }

            if(currentFrame == 17){
                isVisible = false;
                currentFrame = 0;
            }

            srcRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
            origin = new Vector2(srcRect.Width / 2, srcRect.Height / 2);
        }

        public void Draw(SpriteBatch spriteBatch) {
            if (isVisible) {
                spriteBatch.Draw(texture, position, srcRect, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);
            }
        }

    }
}
