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
        


        public BulletView(Texture2D bullet) {
            this.bullet = bullet;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            spriteBatch.Draw(bullet, pos, Color.White);
        }
    }
}
