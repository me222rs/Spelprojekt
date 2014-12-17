using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.View
{
    class BulletView
    {
        //public Rectangle bulletHitBox;
        public Texture2D bullet;
        //public Vector2 origin;
        public Vector2 position;
        public bool isVisible;
        public float speed;


        public BulletView(Texture2D bullet) {
            this.bullet = bullet;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bullet, position, Color.White);
        }
    }
}
