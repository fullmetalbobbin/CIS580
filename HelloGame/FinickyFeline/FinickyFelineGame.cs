using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinickyFeline
{
    public class FinickyFelineGame : Game
    {
        private InputManager inputManager;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private CloveSprite cloveSprite;
        private VoomSprite voomSprite;
        private MouseSprite mouseSprite;
        private Texture2D kibbles;
        private Texture2D shrimp;
        private Texture2D beef;
        private Texture2D salmon;
        private Texture2D tuna;
        private Texture2D chicken;
        private SpriteFont dosis;


        public FinickyFelineGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            Window.Title = "The Finicky Feline";
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 750;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            inputManager = new InputManager();
            cloveSprite = new CloveSprite();
            voomSprite = new VoomSprite();
            mouseSprite = new MouseSprite();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            cloveSprite.LoadContent(Content);
            voomSprite.LoadContent(Content);
            mouseSprite.LoadContent(Content);
            kibbles = Content.Load<Texture2D>("foodspritesheet");
            shrimp = Content.Load<Texture2D>("foodspritesheet");
            beef = Content.Load<Texture2D>("foodspritesheet");
            salmon = Content.Load<Texture2D>("foodspritesheet");
            tuna = Content.Load<Texture2D>("foodspritesheet");
            chicken = Content.Load<Texture2D>("foodspritesheet");
            dosis = Content.Load<SpriteFont>("dosis");
        }

        protected override void Update(GameTime gameTime)
        {
            inputManager.Update(gameTime);
            if (inputManager.Exit) Exit();


            // TODO: Add your update logic here
            cloveSprite.Update(gameTime);
            voomSprite.Update(gameTime);
            mouseSprite.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //cloveSprite.Draw(gameTime, spriteBatch);
            voomSprite.Draw(gameTime, spriteBatch);
            spriteBatch.Draw(kibbles, new Vector2(58, 20), new Rectangle(0, 0, 64, 64), Color.White);
            spriteBatch.Draw(shrimp, new Vector2(172, 20), new Rectangle(64, 64, 64, 64), Color.White);
            spriteBatch.Draw(beef, new Vector2(286, 20), new Rectangle(128, 64, 64, 64), Color.White);
            spriteBatch.Draw(salmon, new Vector2(400, 20), new Rectangle(128, 0, 64, 64), Color.White);
            spriteBatch.Draw(tuna, new Vector2(514, 20), new Rectangle(64, 0, 64, 64), Color.White);
            spriteBatch.Draw(chicken, new Vector2(628, 20), new Rectangle(0, 64, 64, 64), Color.White);
            spriteBatch.Draw(kibbles, new Vector2(58, 310), new Rectangle(0, 0, 64, 64), Color.White);
            spriteBatch.Draw(shrimp, new Vector2(172, 310), new Rectangle(64, 64, 64, 64), Color.White);
            spriteBatch.Draw(beef, new Vector2(286, 310), new Rectangle(128, 64, 64, 64), Color.White);
            spriteBatch.Draw(salmon, new Vector2(400, 310), new Rectangle(128, 0, 64, 64), Color.White);
            spriteBatch.Draw(tuna, new Vector2(514, 310), new Rectangle(64, 0, 64, 64), Color.White);
            spriteBatch.Draw(chicken, new Vector2(628, 310), new Rectangle(0, 64, 64, 64), Color.White);
            spriteBatch.DrawString(dosis, "The Finicky Feline", new Vector2(300, 110), Color.Black);
            spriteBatch.DrawString(dosis, "Exit game - Press Back or ESC", new Vector2(GraphicsDevice.Viewport.Width/3  + 10,GraphicsDevice.Viewport.Height - 40), Color.Black );
            mouseSprite.Draw(gameTime, spriteBatch);
            cloveSprite.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
