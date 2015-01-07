#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using SpaceShooter.Model;
using SpaceShooter.View;
using System.Linq;
#endregion

namespace SpaceShooter
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {

        public enum State { 
            Menu, Play, Gameover, Pause, LevelComplete, Win
        }


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PlayerModel playerModel;
        PlayerView playerView;
        PlayerView2 playerView2;
        MeteorSimulation meteorSimulation;
        Texture2D menuTexture;
        MeteorView2 mv2;

        
        //Listor
        List<MeteorSimulation> meteorList = new List<MeteorSimulation>();
        List<EnemyView> enemyList = new List<EnemyView>();
        List<Destroyer> destroyerList = new List<Destroyer>();
        List<Explosion> explosionList = new List<Explosion>();

        //Texturer
        public Texture2D menu;
        public Texture2D pauseTexture;
        public Texture2D gameOverTexture;

        Random random = new Random();
        Camera camera;
        private int windowWidth;
        private int windowHeight;
        public int enemyBulletDamage;
        public int playerBulletDamage;
        public int level;
        public int currentLevel;
        HeadsUpDisplay hud;

        SpaceBackgroundView sbv;

        State gameState = State.Menu;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);

            
            graphics.PreferredBackBufferWidth = 700;
            graphics.PreferredBackBufferHeight = 950;
            Content.RootDirectory = "Content";
            enemyBulletDamage = 20;
            playerBulletDamage = 20;
            menu = null;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            
            // TODO: Add your initialization logic here
            this.windowWidth = GraphicsDevice.Viewport.Width;
            this.windowHeight = GraphicsDevice.Viewport.Height;
            

            mv2 = new MeteorView2();

            //Textures
            menuTexture = Content.Load<Texture2D>("Menu");
            pauseTexture = Content.Load<Texture2D>("Pause");
            gameOverTexture = Content.Load<Texture2D>("GameOver");

            this.sbv = new SpaceBackgroundView(this.windowWidth, this.windowHeight);
            //this.meteorSimulation = new MeteorSimulation(this.windowWidth, this.windowHeight);
            playerModel = new PlayerModel(this.windowWidth, this.windowHeight, sbv.space);
            //this.playerView = new PlayerView(this.windowWidth, this.windowHeight, sbv.space);
            playerView2 = new PlayerView2();
            camera = new Camera(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            camera.setDimensions(this.windowWidth, this.windowHeight);
            level = 2;
            hud = new HeadsUpDisplay(level);
            currentLevel = 1;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            hud.LoadContent(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.playerModel.LoadContent(this.Content);
            //this.playerView.LoadContent(this.Content);
            this.sbv.LoadContent(Content);
            menu = Content.Load<Texture2D>("space");
        }

        
        public void LoadMeteors()
        {
            int randomY = random.Next(GraphicsDevice.Viewport.Height * -1, -50);
            int randomX = random.Next(0, GraphicsDevice.Viewport.Width);

            if (meteorList.Count < 5)
            {

                    //Slumpar ut en stor eller liten meteor, dom gör lika mkt skada, men det kan vara svårt att undvika en stor
                    meteorList.Add(new MeteorSimulation(this.windowWidth, this.windowHeight, Content.Load<Texture2D>("meteorBrown_med1"), new Vector2(randomX, randomY)));
                
            }

            //Rensar listan
            for (int i = 0; i < meteorList.Count; i++)
            {
                if (!meteorList[i].isVisible)
                {
                    meteorList.RemoveAt(i);
                    i--;
                }
            }
        }

        public void LoadEnemies()
        {
            int randomY = random.Next(-75, -30);
            int randomX = random.Next(-50, GraphicsDevice.Viewport.Width);

            if(hud.level == 2 || hud.level == 3){
                
                if (enemyList.Count < 3)
                {
                    enemyList.Add(new EnemyView(Content.Load<Texture2D>("enemyRed3"), new Vector2(randomX, randomY), Content.Load<Texture2D>("playerbullet"), GraphicsDevice.Viewport));
                }

                if (hud.level == 3)
                {
                    //Om spelaren har lite liv kvar så spawnar en destroyer för att avsluta det hela.
                    if (hud.level == 3)
                    {
                        if (destroyerList.Count < 1)
                        {
                            randomY = random.Next(-75, -50);
                            randomX = random.Next(-50, GraphicsDevice.Viewport.Width - 50);
                            destroyerList.Add(new Destroyer(Content.Load<Texture2D>("enemyBlack1"), new Vector2(randomX, randomY), Content.Load<Texture2D>("playerbullet"), GraphicsDevice.Viewport));
                        }

                    }
                }
                }
    

            //Rensar listan
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (!enemyList[i].isVisible)
                {
                    enemyList.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < destroyerList.Count; i++) {
                if (!destroyerList[i].isVisible)
                {
                    destroyerList.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Explosions() {
            for (int i = 0; i < explosionList.Count; i++) {
                if (!explosionList[i].isVisible)
                {
                    explosionList.RemoveAt(i);
                    i++;
                }
            }
        }



        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch (gameState) {
                case State.Play: {

                    //collision.CheckEnemyCollision(enemyList);

                    //Hanerar kollision mellan fiendeskepp och spelarskepp
                    foreach (EnemyView ev in enemyList)
                    {
                        if (ev.enemyHitBox.Intersects(playerModel.shipHitBox))
                        {
                            playerModel.health -= 40;
                            ev.isVisible = false;
                        }

                        //Om spelarskeppet kolliderar med en fiendekula
                        for (int i = 0; i < ev.bulletList.Count; i++)
                        {
                            if (playerModel.shipHitBox.Intersects(ev.bulletList[i].bulletHitBox))
                            {
                                playerModel.health -= enemyBulletDamage;
                                ev.bulletList[i].isVisible = false;
                            }
                        }

                        //Om spelarkulorna kolliderar med fiendeskepp
                        for (int i = 0; i < playerModel.bulletList.Count; i++)
                        {
                            if (playerModel.bulletList[i].bulletHitBox.Intersects(ev.enemyHitBox))
                            {
                                ev.health -= playerBulletDamage;
                                if (ev.health < 1)
                                {
                                    explosionList.Add(new Explosion(Content.Load<Texture2D>("explosion3"), new Vector2(ev.position.X, ev.position.Y)));
                                }
                                hud.score += 20;
                                playerModel.bulletList[i].isVisible = false;

                                if (ev.health < 1)
                                {
                                    ev.isVisible = false;
                                }
                            }

                        }
                        ev.update(gameTime, playerModel);


                    }

                    foreach (Destroyer d in destroyerList)
                    {
                        if (d.enemyHitBox.Intersects(playerModel.shipHitBox))
                        {
                            playerModel.health -= 80;
                            d.isVisible = false;
                        }

                        for (int i = 0; i < d.bulletList.Count; i++)
                        {
                            if (playerModel.shipHitBox.Intersects(d.bulletList[i].bulletHitBox))
                            {
                                playerModel.health -= enemyBulletDamage;
                                d.bulletList[i].isVisible = false;
                            }
                        }

                        for (int i = 0; i < playerModel.bulletList.Count; i++)
                        {
                            if (playerModel.bulletList[i].bulletHitBox.Intersects(d.enemyHitBox))
                            {
                                d.health -= playerBulletDamage;
                                if (d.health < 1)
                                {
                                    explosionList.Add(new Explosion(Content.Load<Texture2D>("explosion3"), new Vector2(d.position.X, d.position.Y)));
                                }
                                hud.score += 20;
                                playerModel.bulletList[i].isVisible = false;

                                if (d.health < 1)
                                {
                                    d.isVisible = false;
                                }
                            }

                        }

                        d.update(gameTime, playerModel);
                    }


                    foreach (Explosion ex in explosionList)
                    {
                        ex.Update(gameTime);
                    }

                    // TODO: Add your update logic here
                    foreach (MeteorSimulation m in meteorList)
                    {
                        // Kollar om meteorerna kolliderar med skeppet och i så fall tas meteorerna bort
                        if (m.meteorHitBox.Intersects(playerModel.shipHitBox))
                        {
                            hud.score += 5;
                            playerModel.health -= 20;
                            m.isVisible = false;
                        }




                        // Kollar om meteorerna kolliderar med kulorna och i så fall tas de bort
                        for (int i = 0; i < playerModel.bulletList.Count; i++)
                        {
                            if (m.meteorHitBox.Intersects(playerModel.bulletList[i].bulletHitBox))
                            {
                                explosionList.Add(new Explosion(Content.Load<Texture2D>("explosion3"), new Vector2(m.position.X, m.position.Y)));
                                hud.score += 5;
                                m.isVisible = false;
                                playerModel.bulletList.ElementAt(i).isVisible = false;
                            }
                        }

                        m.Update(gameTime);
                    }

                    hud.Update(gameTime);


                    this.sbv.Update(gameTime);
                    LoadMeteors();
                    LoadEnemies();
                    //this.meteorSimulation.Update(gameTime);
                    this.playerModel.Update(gameTime);
                    Explosions();

                    if (playerModel.health < 1)
                    {
                        gameState = State.Gameover;
                    }

                    KeyboardState kState = Keyboard.GetState();
                    if (kState.IsKeyDown(Keys.P))
                    {
                        gameState = State.Pause;

                    }

                    if (hud.level > 3)
                    {
                        gameState = State.Win;
                    }

                    else if(currentLevel + 1 == hud.level)
                    {
                        gameState = State.LevelComplete;
                        playerModel.health += 50;
                        enemyList.Clear();
                        meteorList.Clear();
                        destroyerList.Clear();
                    }
                    currentLevel = hud.level;
                    break;
                }

                case State.Menu:
                {
                    KeyboardState kState = Keyboard.GetState();
                    if (kState.IsKeyDown(Keys.Enter)) {
                        gameState = State.Play;
                    }
                    break;
                }

                case State.Gameover: 
                {
                    KeyboardState kState = Keyboard.GetState();
                    if (kState.IsKeyDown(Keys.Enter))
                    {
                        gameState = State.Menu;
                        playerModel.health = 200;
                        hud.score = 0;
                        enemyList.Clear();
                        meteorList.Clear();
                        destroyerList.Clear();
                        playerModel.position.Y = graphics.PreferredBackBufferHeight + 100;
                        hud.time = 1800;

                    }
                    else if (kState.IsKeyDown(Keys.Tab))
                    {
                        Exit();
                    }
                    break;
                }

                case State.Pause: {
                    KeyboardState kState = Keyboard.GetState();
                    if (kState.IsKeyDown(Keys.Enter))
                    {
                        gameState = State.Play;
                    }
                    break;
                }

                case State.LevelComplete: {
                    KeyboardState kState = Keyboard.GetState();
                    if (kState.IsKeyDown(Keys.Enter))
                    {
                        gameState = State.Play;
                    }
                    break;
                }

                case State.Win:
                    {
                        KeyboardState kState = Keyboard.GetState();
                        if (kState.IsKeyDown(Keys.Enter))
                        {
                            gameState = State.Play;
                        }
                        break;
                    }
            }

            
            


            
                base.Update(gameTime);
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here



            spriteBatch.Begin();

            switch (gameState) {
                case State.Play: 
                {
                    
                    sbv.Draw(spriteBatch);
                    hud.Draw(spriteBatch);
                    foreach (Explosion e in explosionList)
                    {
                        e.Draw(spriteBatch);
                    }

                    foreach (MeteorSimulation mv in meteorList)
                    {
                        
                        mv2.Draw(spriteBatch, mv.meteorTexture, mv.position, mv.isVisible);
                    }
                    playerView2.Draw(spriteBatch, playerModel.shipTexture, playerModel.position, playerModel.bulletList, playerModel.healthBox, playerModel.healthTexture, playerModel.bulletTexture);
                    foreach (EnemyView ev in enemyList)
                    {
                        ev.Draw(spriteBatch);
                    }
                    foreach (Destroyer d in destroyerList)
                    {
                        d.Draw(spriteBatch);
                    }
                    break;
                }
                case State.Menu:
                {
                    spriteBatch.Draw(menuTexture,
                    new Rectangle(0, 0,
                    windowWidth, windowHeight), null,
                    Color.White, 0, Vector2.Zero,
                    SpriteEffects.None, 0);

                    GraphicsDevice.Clear(Color.Black);
                    break;
                }
                case State.Gameover:
                {
                    spriteBatch.Draw(gameOverTexture,
                    new Rectangle(0, 0,
                    windowWidth, windowHeight), null,
                    Color.White, 0, Vector2.Zero,
                    SpriteEffects.None, 0);

                    GraphicsDevice.Clear(Color.Red);

                    hud.DrawScore(spriteBatch);
                    break;
                }
                case State.Pause: {
                    spriteBatch.Draw(pauseTexture,
                    new Rectangle(0, 0,
                    windowWidth, windowHeight), null,
                    Color.White, 0, Vector2.Zero,
                    SpriteEffects.None, 0);

                    GraphicsDevice.Clear(Color.Blue);
                    break;
                }
                case State.Win:
                    {
                        GraphicsDevice.Clear(Color.White);
                        break;
                    }
            }


            spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}