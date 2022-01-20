using Microsoft.Xna.Framework;
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
            _ballVelocity.Normalize();  //scales the vector so it is of length one
            _ballVelocity *= 100;       //100 pixals per second


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
            _ballPosition += _ballVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //if ball reaches X-axis (left/right) boundaries we want it to turn around
            // 64 subtracted on right to account for width of ball image
            if (_ballPosition.X < GraphicsDevice.Viewport.X ||
                _ballPosition.X > GraphicsDevice.Viewport.Width - 64)
            {
                _ballVelocity.X *= -1;  //will turn ball around!
            }

            //if ball reaches Y-axis (top/bottom) boundaries we want it to turn around
            // 64 subtracted on bottom to account for height of ball
            if (_ballPosition.Y < GraphicsDevice.Viewport.Y ||
                _ballPosition.Y > GraphicsDevice.Viewport.Height - 64)
            {
                _ballVelocity.Y *= -1;  //will turn ball around!
            }

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
