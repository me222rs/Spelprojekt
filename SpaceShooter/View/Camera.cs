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

        public Vector2 getViewPosPic(Vector2 modelpos, Texture2D a_texture)
        {

            float textureWidth = a_texture.Width / scale;
            float textureHeight = a_texture.Height / (scale + scaleDiff);

            float vx = scale * (modelpos.X - textureWidth);
            float vy = (scale + scaleDiff) * (modelpos.Y - textureHeight);

            return new Vector2(vx, vy);

        }

        public float getScale()
        {
            return scale;
        }
    }
}
