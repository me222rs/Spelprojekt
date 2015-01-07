using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.View
{
    class MeteorView2
    {
        public MeteorView2() { 
            
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D meteorTexture, Vector2 position, bool isVisible)
        {
            

            if (isVisible)
            {

                //spriteBatch.Begin();
                spriteBatch.Draw(meteorTexture, position, null, Color.White);
                //spriteBatch.End();
            }
        }
    }
}
