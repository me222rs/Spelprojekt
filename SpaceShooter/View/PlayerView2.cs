using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.View
{
    class PlayerView2
    {
        BulletView bulletView;
        public PlayerView2() {
            
        }
        //Ritar ut spelaren, healthbar och spelarens kulor
        public void Draw(SpriteBatch spriteBatch, Texture2D shipTexture, Vector2 position, List<Bullet>bulletList, Rectangle healthBox, Texture2D healthTexture, Texture2D bulletTexture)
        {
            
            bulletView = new BulletView(bulletTexture);
            spriteBatch.Draw(shipTexture, position, Color.White);
            spriteBatch.Draw(healthTexture, healthBox, Color.White);
            foreach (Bullet bullet in bulletList)
            {
                Vector2 pos = bullet.position;
                bulletView.Draw(spriteBatch, pos);
            }
        }
    }
}
