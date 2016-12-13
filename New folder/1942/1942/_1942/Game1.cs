using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _1942
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState oldKB;
        Rectangle player;
        Rectangle cover;
        Rectangle lives;
        Rectangle pow;
        Rectangle shield;
        Rectangle back;
        List<Rectangle> bullet;
        List<Enemy> enemies;
        List<Rectangle> ebullet;
        int bcd;
        int score;
        int liveint;
        int screenW;
        int screenH;
        int playerSpeed;
        int playerl;
        int playerw;
        int bulletsize;
        int spawn;
        int roll;
        int timer;
        int cooldown;
        int rollsAvailable;
        Texture2D current;
        Texture2D playert;
        Texture2D playertr01;
        Texture2D playertr02;
        Texture2D playertr03;
        Texture2D playertr04;
        Texture2D playertr05;
        Texture2D playertr06;
        Texture2D playertr07;
        Texture2D playertr08;
        Texture2D playertr09;
        Texture2D playertr10;
        Texture2D playertr11;
        Texture2D playertr12;
        Texture2D playertr13;
        Texture2D playert000;
        Texture2D black;
        Texture2D GO;
        Texture2D blank;
        SpriteFont titlef;
        SpriteFont gui;
        SpriteFont basic;
        Texture2D backg;
        string tittle;
        string livedis;
        string scoredis;
        string playMsg;
        Boolean Invulnerable;
        Random r = new Random();
        Vector2 tittleVector = new Vector2(250, 200);
        Vector2 liveVector = new Vector2(60, 0);

        enum gamestate { start, play, quit };
        gamestate state;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            screenH = GraphicsDevice.Viewport.Height;
            screenW = GraphicsDevice.Viewport.Width;
            oldKB = Keyboard.GetState();
            playerw = 100;
            playerl = 50;
            shield = new Rectangle(0, -40, screenW, 20);
            player = new Rectangle(screenW / 2 - playerw / 2, screenH - 300, playerw, playerl);
            pow = new Rectangle(120, 0, 50, 50);
            lives = new Rectangle(0, 0, 50, 50);
            back = new Rectangle(0, 0, screenW, screenH);
            bullet = new List<Rectangle>();
            ebullet = new List<Rectangle>();
            liveint = 3;
            bulletsize = 20;
            scoredis = score.ToString();
            livedis = "x" + liveint.ToString();
            playerSpeed = 5;
            bcd = 0;
            spawn = 0;
            timer = 0;
            cooldown = 30;
            rollsAvailable = 3;
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
            playert = Content.Load<Texture2D>("00");
            playertr01 = Content.Load<Texture2D>("01");
            playertr02 = Content.Load<Texture2D>("02");
            playertr03 = Content.Load<Texture2D>("03");
            playertr04 = Content.Load<Texture2D>("04");
            playertr05 = Content.Load<Texture2D>("05");
            playertr06 = Content.Load<Texture2D>("06");
            playertr07 = Content.Load<Texture2D>("07");
            playertr08 = Content.Load<Texture2D>("08");
            playertr09 = Content.Load<Texture2D>("09");
            playertr10 = Content.Load<Texture2D>("10");
            playertr11 = Content.Load<Texture2D>("11");
            playertr12 = Content.Load<Texture2D>("12");
            playertr13 = Content.Load<Texture2D>("13");
            playert000 = Content.Load<Texture2D>("00");
            black = Content.Load<Texture2D>("black");
            titlef = this.Content.Load<SpriteFont>("title");
            gui = this.Content.Load<SpriteFont>("GUI");
            GO = this.Content.Load<Texture2D>("Game EndScreen");
            blank = this.Content.Load<Texture2D>("White Square");
            backg = this.Content.Load<Texture2D>("White Square");
            basic = this.Content.Load<SpriteFont>("basic");
            // TODO: use this.Content to load your game content here
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
            // Allows the game to exit
            KeyboardState kb = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || kb.IsKeyDown(Keys.Escape))
                this.Exit();
            // TODO: Add your update logic here
            switch (state)
            {
                case gamestate.start:
                    tittle = "1942";
                    playMsg = "Press 'F' to Play";
                    if (kb.IsKeyDown(Keys.Space))
                    {
                        state = gamestate.play;
                    }

                    break;
                case gamestate.play:

                    backg = blank;
                    tittle = "";
                    playMsg = "";
                    livedis = "x" + liveint.ToString();
                    scoredis = score.ToString();
                    if (kb.IsKeyDown(Keys.S))
                    {
                        player.Y += playerSpeed;
                    }
                    if (kb.IsKeyDown(Keys.W))
                    {
                        player.Y -= playerSpeed / 2;
                    }
                    if (kb.IsKeyDown(Keys.A))
                    {
                        player.X -= playerSpeed;
                    }
                    if (kb.IsKeyDown(Keys.D))
                    {
                        player.X += playerSpeed;
                    }
                    if (kb.IsKeyDown(Keys.Space) && bcd == 0)
                    {
                        bullet.Add(new Rectangle(player.X + playerw/2 - bulletsize/2, player.Y - 20, bulletsize, bulletsize));
                        bcd += 5;
                    }

                    kb = oldKB;

                    if (bcd > 0)
                    { bcd--; }

                    for (int x = 0; x < bullet.Count; x++)
                    {
                        int z = bullet[x].X;
                        int y = bullet[x].Y;
                        bullet[x] = new Rectangle(z, y - 20, bulletsize, bulletsize);
                        if (bullet[x].Intersects(shield))
                        {
                            bullet.RemoveAt(x);
                        }

                    }
                    if (timer > 0)
                    {
                        timer--;
                    }
                    if (cooldown > 0)
                    {
                        cooldown--;
                    }
                    if (kb.IsKeyDown(Keys.F) && cooldown == 0 && rollsAvailable > 0)
                    {
                        timer = 50;
                        cooldown = 60;
                        rollsAvailable -= 1;
                    }
                    if (timer > 0)
                    {
                        Invulnerable = true;
                        if (timer > 51)
                        {
                            playert = playertr01;
                        }
                        else if (timer > 48)
                        {
                            playert = playertr02;
                        }
                        else if (timer > 45)
                        {
                            playert = playertr03;
                        }
                        else if (timer > 42)
                        {
                            playert = playertr04;
                        }
                        else if (timer > 39)
                        {
                            playert = playertr05;
                        }
                        else if (timer > 36)
                        {
                            playert = playertr06;
                        }
                        else if (timer > 33)
                        {
                            playert = playertr07;
                        }
                        else if (timer > 30)
                        {
                            playert = playertr08;
                        }
                        else if (timer > 27)
                        {
                            playert = playertr09;
                        }
                        else if (timer > 24)
                        {
                            playert = playertr11;
                        }
                        else if (timer > 21)
                        {
                            playert = playertr12;
                        }
                        else if (timer > 18)
                        {
                            playert = playertr13;
                        }
                        else if (timer < 5)
                        {
                            playert = playert000;
                        }
                    }
                    else
                    {
                        Invulnerable = false;
                    }
                    if (Invulnerable)
                    {
                        //PLAYER IS INVISIBLE LIKE BRUCE WILLIS IN THE MOVIE INVISIBLE
                    }
                    break;
                case gamestate.quit:
                    backg = GO;
                    break;
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
            Vector2 tittleVector = new Vector2(275, 125);
            Vector2 lowerMid = new Vector2(275, 275);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(backg, back, Color.Blue);
            
            spriteBatch.DrawString(basic, playMsg, lowerMid, Color.Yellow);
            spriteBatch.DrawString(titlef, tittle, tittleVector, Color.Green);
            spriteBatch.DrawString(gui, livedis, liveVector, Color.White);
            spriteBatch.DrawString(gui, scoredis, new Vector2(screenW / 2, 0), Color.White);
            spriteBatch.Draw(playert, pow, Color.White);
            spriteBatch.Draw(playert, player, Color.White);
            spriteBatch.Draw(playert, lives, Color.White);
            spriteBatch.Draw(black, cover, Color.Black);
            for (int x = 0; x < bullet.Count; x++)
            {
                spriteBatch.Draw(playert, bullet[x], Color.Yellow);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
