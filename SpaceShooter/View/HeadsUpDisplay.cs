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
        public int time = 1800;
        

        //Tydligen så har inte Monogame fullt stöd för spritefonts. 
        //Hittade en färdig spritefont-fil som är klar att användas
        //https://www.youtube.com/watch?v=BwtQn02oy6A

        public SpriteFont spriteFont;

        public Vector2 scorePosition;
        public bool hudIsVisible;
        public Vector2 hpPosition;
        public Vector2 levelPosition;
        public Vector2 timePosition;
        public Vector2 finalScorePosition;

        public HeadsUpDisplay(int level) {
            score = 0;
            hudIsVisible = true;
            spriteFont = null;
            hpPosition = new Vector2(0, 25);
            scorePosition = new Vector2(0, 50);
            levelPosition = new Vector2(0, 75);
            timePosition = new Vector2(0, 100);
            this.level = level;
            finalScorePosition = new Vector2(200, 300);
        }
        
        public void LoadContent(ContentManager Content) {
            spriteFont = Content.Load<SpriteFont>("MyFont");
        }

        public void Update(GameTime gameTime) {
            KeyboardState keyBoard = Keyboard.GetState();
            time -= 1;
            if (time == 0) {
                level += 1;
                time = 1800;
            }

        }

        public void DrawScore(SpriteBatch spritebatch) {
            spritebatch.DrawString(spriteFont, "Your score was " + score, finalScorePosition, Color.White);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            Vector2 v = new Vector2(200, 200);
            spritebatch.DrawString(spriteFont, "Score: " + score, scorePosition, Color.White);
            spritebatch.DrawString(spriteFont, "HP", hpPosition, Color.White);
            spritebatch.DrawString(spriteFont, "Time:  " + time/60, timePosition, Color.White);
            spritebatch.DrawString(spriteFont, "Level " + level, levelPosition, Color.White);
            
        }

    }
}
