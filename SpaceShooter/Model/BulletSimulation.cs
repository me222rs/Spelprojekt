using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.View;
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
        // Idén med att göra delay på detta sättet fick jag härifrån
        //http://haxecoder.com/post.php?id=33
        public int delay = 1;
        public Texture2D bulletTexture;


        public BulletSimulation(Texture2D bulletTexture) {
            this.bulletTexture = bulletTexture;
        }

        public List<Bullet> PlayerShoot(Vector2 position, List<Bullet>bulletList, Texture2D bulletTexture, Sound s)
         {

            this.bulletList = bulletList;

            // delay hindrar spelaren från att kunna hålla skjutknappen nere och skjuta så fort det bara går.
            // Med delay så tar det en viss tid mellan varje skott
            if (delay >= 0)
            {
                delay--;
            }
            if (delay <= 0)
            {
                Bullet bullet = new Bullet(bulletTexture);
                bullet.position = new Vector2(position.X + 50.5f - bulletTexture.Width / 2, position.Y);
                bullet.isVisible = true;


                //Om listan med kulorna är för stor så kommer man inte kunna skjuta förrens några av de existerande kulorna har försvunnit
                if (bulletList.Count() < 50)
                {
                    bulletList.Add(bullet);
                    s.shoot.Play();
                }
            }

            if (delay == 0)
            {
                delay = 10;
            }

            return bulletList;
        }

        public List<Bullet> UpdateBullet(List<Bullet> bulletList)
        {
            //Fick lite inspiration från denna länken
            //http://www.sweclockers.com/forum/10-programmering-och-digitalt-skapande/1161650-c-varfor-laggar-mitt-spel/index2.html
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
