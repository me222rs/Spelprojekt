using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.View
{
    class HeadsUpDisplay
    {
        public int score;
        public int width;
        public int height;
        public int level;

        //Tydligen så har inte Monogame fullt stöd för spritefonts. 
        //Hittade att man kunde ladda ned ett projekt som gjorde om
        //en xna spritefont till en xnb fil så att monogame kan använda den.
        //https://www.youtube.com/watch?v=BwtQn02oy6A

        public SpriteFont spriteFont;

        public Vector2 scorePosition;
        public bool hudIsVisible;
        public Vector2 hpPosition;
        public Vector2 levelPosition;

        public HeadsUpDisplay(int level) {
            score = 0;
            hudIsVisible = true;
            height = 650;
            width = 500;
            spriteFont = null;
            hpPosition = new Vector2(0, 25);
            scorePosition = new Vector2(0, 50);
            levelPosition = new Vector2(0, 75);
            this.level = level;
        }
        
        public void LoadContent(ContentManager Content) {
            spriteFont = Content.Load<SpriteFont>("MyFont");
        }

        public void Update(GameTime gameTime) {
            KeyboardState keyBoard = Keyboard.GetState();



        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.DrawString(spriteFont, "Score: " + score, scorePosition, Color.White);
            spritebatch.DrawString(spriteFont, "HP", hpPosition, Color.White);
            spritebatch.DrawString(spriteFont, "Level " + level, levelPosition, Color.White);
        }
    }
}
