using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.Media;
using GameProjectThree.StateManagement;
using GameProjectThree.Screens;


namespace GameProjectThree
{
    public class FireflyGame : Game
    {
        private readonly ScreenManager screenManager;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Song backgroundMusic;
        public SoundEffect soundEffect;

        private Texture2D background;
        private Texture2D midground;
        private Texture2D foreground;
        private Texture2D superground;

        private Firefly firefly;
        private Starlight[] starlights;
        private int starlightLeft;

        

        public FireflyGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferHeight = 1500;
            //graphics.PreferredBackBufferHeight = GraphicsDevice.Viewport.Height; put in load?
            
            graphics.PreferredBackBufferWidth = 500;
            graphics.GraphicsProfile = GraphicsProfile.HiDef;

            var screenFactory = new ScreenFactory();
            Services.AddService(typeof(IScreenFactory), screenFactory);

            screenManager = new ScreenManager(this);
            Components.Add(screenManager);

            AddInitialScreens();

        }

        private void AddInitialScreens()
        {
            screenManager.AddScreen(new BackgroundScreen(), null);
            screenManager.AddScreen(new MainMenuScreen(), null);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            firefly = new Firefly(this);

            //Components.Add("firefly");
            Color color = Color.Fuchsia;
            System.Random chaos = new System.Random();
            starlights = new Starlight[]
                {
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color)
                };
            starlightLeft = starlights.Length;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            firefly.LoadContent(Content);
            backgroundMusic = Content.Load<Song>("Firefly4");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);
            soundEffect = Content.Load<SoundEffect>("PowerupSoft");
            // Now resize the height here

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>("background");
            midground = Content.Load<Texture2D>("midground");
            foreground = Content.Load<Texture2D>("foreground");
            superground = Content.Load<Texture2D>("superground");

            foreach (var star in starlights) star.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            firefly.Update(gameTime);

            //firefly.FireflyColor = Color.White;
            foreach (var star in starlights)
            {
                if (!star.Collected && star.StarlightBounds.WhenStarsCollide(firefly.FireflyBounds))
                {
                    //firefly.FireflyColor = Color.Fuchsia;
                    star.Collected = true;
                    starlightLeft--;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);

            float fireflyY = MathHelper.Clamp(firefly.FireflyPosition.Y, 500, 135000);
            float offsetY = 500 - fireflyY;

            // TODO: Add your drawing code here
            Matrix transform;

            transform = Matrix.CreateTranslation(0, offsetY * 0.1f, 0);
            spriteBatch.Begin(transformMatrix: transform);
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.End();

            transform = Matrix.CreateTranslation(0, offsetY * 0.5f, 0);
            spriteBatch.Begin(transformMatrix: transform);
            spriteBatch.Draw(midground, Vector2.Zero, Color.White);
            spriteBatch.End();

            transform = Matrix.CreateTranslation(0, offsetY, 0);
            spriteBatch.Begin(transformMatrix: transform);
            foreach (var star in starlights) star.Draw(gameTime, spriteBatch);
            firefly.Draw(gameTime, spriteBatch);
            spriteBatch.Draw(foreground, Vector2.Zero, Color.White);            
            spriteBatch.End();

            transform = Matrix.CreateTranslation(0, offsetY * 1.25f, 0);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, transformMatrix: transform);
            spriteBatch.Draw(superground, Vector2.Zero, Color.YellowGreen);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
