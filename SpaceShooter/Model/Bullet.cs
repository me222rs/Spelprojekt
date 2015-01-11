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
    public class Bullet
    {
        public Rectangle bulletHitBox;
        public Texture2D bullet;
        public Vector2 origin;
        public Vector2 position;
        public bool isVisible;
        public float speed;
        
        //Sätter kulans hastighet och textur
        public Bullet(Texture2D newBullet) {
            speed = 7;
            bullet = newBullet;
            isVisible = false;

        }
    }


}
