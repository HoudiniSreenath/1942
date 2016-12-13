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
        Rectangle lives;
        Rectangle pow;
        Rectangle shield;
        Rectangle back;
        List<Rectangle> bullet;
        int bcd;
        int score;
        int liveint;
        int screenW;
        int screenH;
        int playerSpeed;
        int playerl;
        int playerw;
        int bulletsize;
        Texture2D current;
        Texture2D playert;
        Texture2D GO;
        Texture2D blank;
        SpriteFont titlef;
        SpriteFont gui;
        Texture2D backg;
        string tittle;
        string livedis;
        string scoredis;
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
            liveint = 3;
            bulletsize = 20;
            scoredis = score.ToString();
            livedis = "x" + liveint.ToString();
            playerSpeed = 5;
            bcd = 0;
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
            playert = Content.Load<Texture2D>("player");
            titlef = this.Content.Load<SpriteFont>("title");
            gui = this.Content.Load<SpriteFont>("GUI");
            GO = this.Content.Load<Texture2D>("Game EndScreen");
            blank = this.Content.Load<Texture2D>("White Square");
            backg = this.Content.Load<Texture2D>("White Square");
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
                    if (kb.IsKeyDown(Keys.Space))
                    {
                        state = gamestate.play;
                    }

                    break;
                case gamestate.play:

                    backg = blank;
                    tittle = "";
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

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(backg, back, Color.White);
            spriteBatch.DrawString(titlef, tittle, tittleVector, Color.Green);
            spriteBatch.DrawString(gui, livedis, liveVector, Color.White);
            spriteBatch.DrawString(gui, scoredis, new Vector2(screenW / 2, 0), Color.White);
            spriteBatch.Draw(playert, pow, Color.White);
            spriteBatch.Draw(playert, player, Color.White);
            spriteBatch.Draw(playert, lives, Color.White);
            for(int x = 0; x < bullet.Count; x++)
            {
                spriteBatch.Draw(playert, bullet[x], Color.Yellow);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
