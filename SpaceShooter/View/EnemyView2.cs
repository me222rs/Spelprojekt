using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.View
{
    class EnemyView2
    {
        BulletView bv;
        public EnemyView2() {
            
        }
        public void Draw(SpriteBatch spriteBatch, Texture2D enemyTexture, Vector2 position, List<Bullet>bulletList, Texture2D bulletTexture)
        {
            bv = new BulletView(bulletTexture);
            spriteBatch.Draw(enemyTexture, position, Color.White);


            foreach (Bullet bullet in bulletList)
            {

                bv.Draw(spriteBatch, bullet.position);
            }
        }
    }
}
