using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.Model
{
    /// <summary>
    /// Klassen hanterar uträkningar med kulorna
    /// </summary>
    class BulletSimulation
    {
        public List<Bullet> bulletList;
        public int bulletDelay = 1;
        public Texture2D bulletTexture;


        public BulletSimulation(Texture2D bulletTexture) {
            //bulletList = new List<Bullet>();
            this.bulletTexture = bulletTexture;
        }

        public List<Bullet> PlayerShoot(Vector2 position, List<Bullet>bulletList, Texture2D bulletTexture)
         {

            this.bulletList = bulletList;


            if (bulletDelay >= 0)
            {
                bulletDelay--;
            }
            if (bulletDelay <= 0)
            {
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.position = new Vector2(position.X + 32 - bulletTexture.Width / 2, position.Y + 30);
                newBullet.isVisible = true;
                if (bulletList.Count() < 20)
                {
                    bulletList.Add(newBullet);
                }
            }

            if (bulletDelay == 0)
            {
                bulletDelay = 10;
            }

            return bulletList;
        }

        public List<Bullet> UpdateBullet(List<Bullet> bulletList)
        {
            foreach (Bullet bullet in bulletList.ToList())
            {
                // Träffytan för kulorna
                bullet.bulletHitBox = new Rectangle((int)bullet.position.X, (int)bullet.position.Y, bullet.bullet.Width, bullet.bullet.Width);

                bullet.position.Y = bullet.position.Y - bullet.speed;

                if (bullet.position.Y <= 0)
                {
                    bullet.isVisible = false;
                }

                for (int i = 0; i < bulletList.Count; i++)
                {
                    if (!bulletList[i].isVisible)
                    {
                        bulletList.RemoveAt(i);
                        i--;
                    }
                }
            }
            return bulletList;
        }
    }
}
