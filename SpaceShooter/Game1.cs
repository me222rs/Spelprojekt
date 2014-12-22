﻿#region Using Statements
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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PlayerView playerView;
        //MeteorView meteorView;
        BulletView bulletView;
        //MeteorSimulation meteorSimulation;
        PlayerSimulation playerSImulation;
        MeteorSimulation meteorSimulation;

        //lista med meteorer
        List<MeteorView> meteorList = new List<MeteorView>();
        List<EnemyView> enemyList = new List<EnemyView>();
        Random random = new Random();

        private int windowWidth;
        private int windowHeight;
        public int enemyBulletDamage;

        SpaceBackgroundView sbv;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 650;
            Content.RootDirectory = "Content";
            enemyBulletDamage = 20;
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

            this.sbv = new SpaceBackgroundView(this.windowWidth, this.windowHeight);
            this.meteorSimulation = new MeteorSimulation(this.windowWidth, this.windowHeight);
            //this.meteorView = new MeteorView(this.windowWidth, this.windowHeight);
            this.playerView = new PlayerView(this.windowWidth, this.windowHeight);
            
            //this.meteorSimulation = new MeteorSimulation(this.windowWidth, this.windowHeight);
            //this.playerSImulation = new PlayerSimulation(this.windowWidth, this.windowHeight);
            
            

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //this.meteorView.LoadContent(Content);
            this.playerView.LoadContent(this.Content);
            this.sbv.LoadContent(Content);
            //this.playerSImulation.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        
        public void LoadMeteors()
        {
            int randomY = random.Next(-600, -50);
            int randomX = random.Next(0, 550);

            if (meteorList.Count < 5)
            {
                meteorList.Add(new MeteorView(this.windowWidth, this.windowHeight, Content.Load<Texture2D>("asteroid"), new Vector2(randomX, randomY)));
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
            int randomY = random.Next(-75, -50);
            int randomX = random.Next(0, 450);

            if (enemyList.Count < 3)
            {
                enemyList.Add(new EnemyView(Content.Load<Texture2D>("enemyship"), new Vector2(randomX, randomY), Content.Load<Texture2D>("playerbullet")));
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

            foreach (EnemyView ev in enemyList)
            {
                if (ev.enemyHitBox.Intersects(playerView.shipHitBox))
                {
                    playerView.health -= 40;
                    ev.isVisible = false;
                }

                for (int i = 0; i > ev.bulletList.Count; i++)
                {
                    if (playerView.shipHitBox.Intersects(ev.bulletList[i].bulletHitBox))
                    {
                        playerView.health -= enemyBulletDamage;
                        ev.bulletList[i].isVisible = false;
                    }
                }

                for (int i = 0; i < playerView.bulletList.Count; i++)
                {
                    if (playerView.bulletList[i].bulletHitBox.Intersects(ev.enemyHitBox))
                    {
                        playerView.bulletList[i].isVisible = false;
                        ev.isVisible = false;
                    }

                }
                ev.update(gameTime);
                
            }

                // TODO: Add your update logic here
                foreach (MeteorView m in meteorList)
                {
                    // Kollar om meteorerna kolliderar med skeppet och i så fall tas meteorerna bort
                    if (m.meteorHitBox.Intersects(playerView.shipHitBox))
                    {
                        playerView.health -= 20;
                        m.isVisible = false;
                    }




                    // Kollar om meteorerna kolliderar med kulorna och i så fall tas de bort
                    for (int i = 0; i < playerView.bulletList.Count; i++)
                    {
                        if (m.meteorHitBox.Intersects(playerView.bulletList[i].bulletHitBox))
                        {
                            m.isVisible = false;
                            playerView.bulletList.ElementAt(i).isVisible = false;
                        }
                    }

                    m.Update(gameTime);
                }



                this.sbv.Update(gameTime);
                LoadMeteors();
                LoadEnemies();
                this.meteorSimulation.Update(gameTime);
                this.playerView.Update(gameTime);

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
            sbv.Draw(spriteBatch);
            foreach (MeteorView mv in meteorList)
            {
                mv.Draw(spriteBatch);
            }
            //meteorView.Draw(spriteBatch);
            playerView.Draw(spriteBatch);
            foreach (EnemyView ev in enemyList)
            {
                ev.Draw(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}