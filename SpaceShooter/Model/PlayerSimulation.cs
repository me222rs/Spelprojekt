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
    /// Klassen hanterar kollisioner och andra uträkningar som rör spelaren
    /// </summary>
    class PlayerSimulation
    {
        public List<Bullet> bulletList;
        public int bulletDelay = 1;
        

        public Vector2 isCollidingWithBorders(Vector2 v, Vector2 screenposMax, Texture2D shipTexture, Texture2D sbv) {
            //Kollision med kanterna
            if (v.X <= 0.0f)
            {
                v.X = 0.0f;
            }
            if (v.Y <= 0.0f)
            {
                v.Y = 0.0f;
            }
            if (v.X >= screenposMax.X - shipTexture.Width)
            {
                v.X = screenposMax.X - shipTexture.Width;
            }
            if (v.Y >= screenposMax.Y - shipTexture.Height)
            {
                v.Y = screenposMax.Y - shipTexture.Height;
            }

            return v;
        }
    }
}
