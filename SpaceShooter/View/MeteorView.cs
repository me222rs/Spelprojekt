using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.View
{
    public class MeteorView
    {
        public Texture2D meteor;
        public Vector2 position;
        public Vector2 origin;
        public float rotation;
        public int speed;
        public bool isColliding;
        public bool isDestroyed;
        public Rectangle meteorHitBox;


        public MeteorView() { 
            //Default värden
            this.isColliding = false;
            this.isDestroyed = false;
            this.position = new Vector2(200, -50);
            this.meteor = null;
            this.speed = 2;
        }

        public void LoadContent(ContentManager content) {
            this.meteor = content.Load<Texture2D>("asteroid");
            this.origin.X = meteor.Width / 2;
            this.origin.Y = meteor.Height / 2;

        }

        public void Update(GameTime gameTime) { 
            this.meteorHitBox = new Rectangle((int)position.X, (int)position.Y, 45, 45);

            //Respawnar 50 pixlar utanför kameran ifall meteoren når botten
            this.position.Y = position.Y + speed;
            if (this.position.Y >= 650) {
                this.position.Y = -50;
            }

            //Roterar meteoren
            //http://msdn.microsoft.com/en-us/library/bb203869.aspx
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.rotation += elapsed;
            float circle = MathHelper.Pi * 2;
            this.rotation = this.rotation % circle;

        }

        public void Draw(SpriteBatch spriteBatch) {
            if (!this.isDestroyed) {
                spriteBatch.Draw(this.meteor, this.position, null, Color.White, this.rotation, this.origin, 1.0f, SpriteEffects.None, 0);
            }
        }

    }
}
