using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.View
{
    class Destroyer
    {
        public Rectangle enemyHitBox;
        public Texture2D enemyTexture;
        public Texture2D bulletTexture;
        public Vector2 position;
        public int health;
        public int speed;
        public int bulletDelay;
        public int setBulletDelay;
        public int currentDifficultyLevel;
        public bool isVisible;
        public List<Bullet> bulletList;
        BulletView bv;
        Viewport viewPort;



        //Lägger texturen för enemy som parameter så att man senare kan återanvända klassen för att skapa ett annat fiende
        public Destroyer(Texture2D newTexture, Vector2 newPosition, Texture2D newBulletTexture, Viewport viewPort) { 
            bulletList = new List<Bullet>();
            enemyTexture = newTexture;
            bulletTexture = newBulletTexture;
            health = 400;
            currentDifficultyLevel = 1;
            setBulletDelay = 20;
            bulletDelay = 20;
            isVisible = true;
            bv = new BulletView(bulletTexture);
            position = newPosition;
            speed = 1;
            this.viewPort = viewPort;

        }

        public void update(GameTime gameTime) {
            enemyHitBox = new Rectangle((int)position.X, (int)position.Y, enemyTexture.Width, enemyTexture.Height);

            position.Y += speed;
            
            Random randomX = new Random();

            if (position.Y == viewPort.Height) {
                position.Y = -50;
            }
            EnemyShootBullets();
            UpdateBullet();
        
        }


        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(enemyTexture, position, Color.White);


            foreach (Bullet bullet in bulletList) {
                
                bv.Draw(spriteBatch, bullet.position);
            }
        }

        public void EnemyShootBullets() {
            if (bulletDelay >= 0) {
                bulletDelay--;
            }

            if (bulletDelay <= 0) {
                Bullet newBullet = new Bullet(bulletTexture);
                    newBullet.position = new Vector2(position.X + enemyTexture.Width / 2 - newBullet.bullet.Width / 2, position.Y + 30);

                    newBullet.isVisible = true;

                    if (bulletList.Count < 20) {
                        bulletList.Add(newBullet);
                    }
            }

            if (bulletDelay == 0) {
                bulletDelay = setBulletDelay;
            }
        }

        public List<Bullet> UpdateBullet()
        {
            foreach (Bullet bullet in bulletList.ToList())
            {
                // Träffytan för kulorna
                bullet.bulletHitBox = new Rectangle((int)bullet.position.X, (int)bullet.position.Y, bullet.bullet.Width, bullet.bullet.Width);

                bullet.position.Y = bullet.position.Y + bullet.speed;

                if (bullet.position.Y >= viewPort.Height)
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
