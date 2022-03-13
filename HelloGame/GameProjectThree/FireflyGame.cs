using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProjectThree
{
    public class FireflyGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D background;
        private Texture2D midground;
        private Texture2D foreground;
        private Texture2D superground;

        private Firefly firefly;

        public FireflyGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.GraphicsProfile = GraphicsProfile.HiDef;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            firefly = new Firefly(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            firefly.LoadContent(Content);

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>("");
            midground = Content.Load<Texture2D>("");
            foreground = Content.Load<Texture2D>("");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            firefly.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);

            float fireflyY = MathHelper.Clamp(firefly.FireflyPosition.Y, 500, 135000);
            float offsetY = 500 - fireflyY;

            // TODO: Add your drawing code here
            Matrix transform;

            transform = Matrix.CreateTranslation(offsetY * 0.25f, 0, 0);
            _spriteBatch.Begin(transformMatrix: transform);
            _spriteBatch.Draw(background, Vector2.Zero, Color.White);
            _spriteBatch.End();

            transform = Matrix.CreateTranslation(offsetY * 0.5f, 0, 0);
            _spriteBatch.Begin(transformMatrix: transform);
            _spriteBatch.Draw(midground, Vector2.Zero, Color.White);
            _spriteBatch.End();

            transform = Matrix.CreateTranslation(offsetY, 0, 0);
            _spriteBatch.Begin(transformMatrix: transform);
            _spriteBatch.Draw(foreground, Vector2.Zero, Color.White);
            _spriteBatch.End();

            transform = Matrix.CreateTranslation(offsetY * 1.5f, 0, 0);
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, transformMatrix: transform);
            firefly.Draw(gameTime, _spriteBatch);
            _spriteBatch.Draw(superground, Vector2.Zero, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
