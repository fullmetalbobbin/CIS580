﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HelloGame
{
    public class HelloGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Vector2 _ballPosition;
        private Vector2 _ballVelocity;
        private Texture2D _ballTexture;

        /// <summary>
        /// Construction of the game
        /// </summary>
        public HelloGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Hello Game";
        }

        /// <summary>
        /// Initalization of the game
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _ballPosition = new Vector2(
                GraphicsDevice.Viewport.Width/2,
                GraphicsDevice.Viewport.Height/2
                );

            System.Random randomChaos = new System.Random();
            _ballVelocity = new Vector2(
                (float)randomChaos.NextDouble(),
                (float)randomChaos.NextDouble()
                );

            base.Initialize();      //base refers back to this Game class
        }

        /// <summary>
        /// Loading the content of the game
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _ballTexture = Content.Load<Texture2D>("ball");
        }

        /// <summary>
        /// Game loop portion responsible for updating the game
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);      //base refers back to this Game class
        }

        /// <summary>
        /// Game loop portion responsible for drawing the game
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);        //base refers back to this Game class
        }
    }
}
