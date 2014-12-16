using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.Model
{
    class PlayerSimulation
    {
        public List<Bullet> bulletList;
        public int bulletDelay = 1;

        public void PlayerShoot(Texture2D bulletTexture, Vector2 position)
        {
            if (bulletDelay >= 0)
            {
                bulletDelay--;
            }
            if (bulletDelay <= 0)
            {
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.position = new Vector2(position.X + 32 - newBullet.bullet.Width / 2, position.Y + 30);
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

            }
        }



        public Vector2 isCollidingWithBorders(Vector2 v, Vector2 screenposMax) {
            //Kollision med kanterna
            if (v.X <= 0.0f)
            {
                v.X = 0.0f;
            }
            if (v.Y <= 0.0f)
            {
                v.Y = 0.0f;
            }
            if (v.X >= screenposMax.X)
            {
                v.X = screenposMax.X;
            }
            if (v.Y >= screenposMax.Y)
            {
                v.Y = screenposMax.Y;
            }

            return v;
        }
    }
}
