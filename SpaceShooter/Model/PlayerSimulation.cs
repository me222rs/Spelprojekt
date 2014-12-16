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
