using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.View
{
    class Camera
    {
        private float scale;
        private int width;
        private int height;
        private float scaleDiff;
        public Camera() { 
        
        }
        public Camera(int width, int height)
        {
                float ScaleY = (height);
                float ScaleX = (width);

                scale = ScaleX;
                if (ScaleY < ScaleX)
                {
                    scale = ScaleY;
                }

                scaleDiff = ScaleY - ScaleX;

            }

        

        public void setDimensions(int width, int height)
        {
            this.width = width;
            this.height = height;

            int scaleX = width;
            int scaleY = height;

            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }
        public float getScale()
        {
            return scale;
        }
    }
}
