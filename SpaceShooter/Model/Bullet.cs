using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter.Model
{
    /// <summary>
    /// Denna klass är ett objekt av typen kula som även ritar ut kulan(utritning borde ligga i någon vy istället)
    /// </summary>
    public class Bullet
    {
        public Rectangle bulletHitBox;
        public Texture2D bullet;
        public Vector2 origin;
        public Vector2 position;
        public bool isVisible;
        public float speed;

        public Bullet(Texture2D newBullet) {
            speed = 5;
            bullet = newBullet;
            isVisible = false;

        }
        //Ritar ut kulorna
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(bullet, position, Color.White);
        }
    }


}
