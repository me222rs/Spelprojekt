using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.View
{
    class Camera
    {
        private float scale;

        public Camera(int width, int height)
        {

            float ScaleY = (height);
            float ScaleX = (width);

            scale = ScaleX;
            if (ScaleY < ScaleX)
            {
                scale = ScaleY;
            }

        }

        public float getScale()
        {
            return scale;
        }
    }
}
