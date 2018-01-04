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

namespace Pong
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState kb = Keyboard.GetState();
        Texture2D ballTex;
        Rectangle ballRect;

        Texture2D whitesquareTex;
        Rectangle whitesquareRect;
        Texture2D whitesquare2Tex;
        Rectangle whitesquare2Rect;
        int ballSpeedX;
        int ballSpeedY;

        Rectangle bottom;
        Rectangle top;
        Rectangle right;
        Rectangle left;

        SpriteFont Font1;
        SpriteFont Font2;
        SpriteFont Font3;
        SpriteFont Font4;
        SpriteFont Font5;
        int player1Score;
        int player2Score;
        enum State { play,start,quit};
        State state = new Game1.State;
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
            int screenWidth = graphics.GraphicsDevice.Viewport.Width;
            int screenHeight = graphics.GraphicsDevice.Viewport.Height;
            bottom = new Rectangle(0, screenHeight, screenWidth, 20);
            top = new Rectangle(0, 0, screenWidth, 0);
            right = new Rectangle(800, 0, 0, screenHeight);
            left = new Rectangle(0, 0, 0, screenHeight);
            whitesquareRect = new Rectangle(-100, -100, -100, -100);
            whitesquare2Rect = new Rectangle(-100, -100, -100, -100);
            ballRect = new Rectangle(-100, -100, -100, -100);
            ballSpeedX = 0;
            ballSpeedY = 0;
            state =State.start;
            
            


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

            // TODO: use this.Content to load your game content here
            ballTex = Content.Load<Texture2D>("orange ping pong ball"); 
            whitesquareTex = Content.Load<Texture2D>("whitesquare");
            whitesquare2Tex = Content.Load<Texture2D>("whitesquare2");
            Font1 = Content.Load<SpriteFont>("SpriteFont1");
            Font2 = Content.Load<SpriteFont>("SpriteFont2");
            Font3 = Content.Load<SpriteFont>("SpriteFont3");
            Font4 = Content.Load<SpriteFont>("SpriteFont4");
            Font5 = Content.Load<SpriteFont>("SpriteFont5");
            
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
            KeyboardState kb = Keyboard.GetState();
            
            // Allows the game to exit

            // whitesquareRect = new Rectangle(50, 200, 10, 100);
            // whitesquare2Rect = new Rectangle(745, 200, 10, 100);
            // ballRect = new Rectangle(300, 250, 20, 20);
            // ballSpeedX = 2;
            // ballSpeedY = 3;
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || kb.IsKeyDown(Keys.Escape))
                this.Exit();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            switch (state)
            {
                case state.play:
                    ballRect.X += ballSpeedX;
                    ballRect.Y += ballSpeedY;

                    if (ballRect.Intersects(bottom))
                    {
                        ballSpeedY *= -1;
                    }
                    if (ballRect.Intersects(top))
                    {
                        ballSpeedY *= -1;
                    }
                    if (ballRect.Intersects(right))
                    {
                        ballRect.X = 500;
                        ballSpeedX *= -1;
                        player1Score++;
                    }
                    if (ballRect.Intersects(left))
                    {
                        ballRect.X = 300;
                        ballSpeedX *= -1;
                        player2Score++;
                    }
                    if (ballRect.Intersects(whitesquareRect))
                    {
                        ballSpeedX *= -1;
                    }
                    if (ballRect.Intersects(whitesquare2Rect))
                    {
                        ballSpeedX *= -1;
                    }
                    break;
                case state.start:
                    break;
                case state.quit:
                    break;
                default:
                    break;
            }|
            // TODO: Add your update logic here
            


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            string s = Convert.ToString(player1Score);
            spriteBatch.Begin();
            spriteBatch.Draw(whitesquareTex, whitesquareRect, Color.White);
            spriteBatch.Draw(whitesquare2Tex, whitesquare2Rect, Color.White);
            spriteBatch.DrawString(Font1, ""+player1Score, new Vector2(150, 100), Color.White);
            spriteBatch.DrawString(Font2, ""+player2Score, new Vector2(575, 100), Color.White);
            spriteBatch.Draw(ballTex, ballRect, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
