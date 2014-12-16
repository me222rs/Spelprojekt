using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.Model
{
    class BulletSimulation
    {
        public List<Bullet> bulletList;
        public int bulletDelay = 20;
        public Texture2D bulletTexture;


        public BulletSimulation(Texture2D bulletTexture) {
            bulletList = new List<Bullet>();
            this.bulletTexture = bulletTexture;
        }

        public void PlayerShoot(Vector2 position)
        {
            if (bulletDelay >= 0)
            {
                bulletDelay--;
            }
            if (bulletDelay <= 0)
            {
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.position = new Vector2(position.X + 32 - bulletTexture.Width / 2, position.Y + 30);
                newBullet.isVisible = true;
                if (bulletList.Count() < 2000)
                {
                    bulletList.Add(newBullet);
                }
            }

            if (bulletDelay == 0)
            {
                bulletDelay = 1;
            }
        }

        public void UpdateBullet()
        {
            foreach (Bullet bullet in bulletList)
            {
                bullet.position.Y = bullet.position.Y - bullet.speed;

                if (bullet.position.Y >= 0)
                {
                    bullet.isVisible = false;
                }

                for (int i = 0; i > bulletList.Count; i++)
                {
                    if (bulletList[i].isVisible)
                    {
                        bulletList.RemoveAt(i);
                    }
                }
            }
        }
    }
}
