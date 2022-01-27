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
        private Texture2D kibbles;
        private Texture2D shrimp;
        private Texture2D beef;
        private Texture2D salmon;
        private Texture2D tuna;
        private Texture2D chicken;
        


        public FinickyFelineGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            inputManager = new InputManager();
            cloveSprite = new CloveSprite();
            voomSprite = new VoomSprite();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            cloveSprite.LoadContent(Content);
            voomSprite.LoadContent(Content);
            kibbles = Content.Load<Texture2D>("foodspritesheet");
            shrimp = Content.Load<Texture2D>("foodspritesheet");
            beef = Content.Load<Texture2D>("foodspritesheet");
            salmon = Content.Load<Texture2D>("foodspritesheet");
            tuna = Content.Load<Texture2D>("foodspritesheet");
            chicken = Content.Load<Texture2D>("foodspritesheet");
        }

        protected override void Update(GameTime gameTime)
        {
            inputManager.Update(gameTime);
            if (inputManager.Exit) Exit();


            // TODO: Add your update logic here
            cloveSprite.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            cloveSprite.Draw(gameTime, spriteBatch);
            voomSprite.Draw(gameTime, spriteBatch);
            //spriteBatch.Draw(kibbles, new Vector2(10, 10), new Rectangle(0, 0, 64, 64), Color.White);
            //spriteBatch.Draw(shrimp, new Vector2(40,40), new Rectangle(64, 64, 64, 64), Color.White);
            //spriteBatch.Draw(beef, new Vector2(70,70), new Rectangle(128, 64, 64, 64), Color.White);
            //spriteBatch.Draw(salmon, new Vector2(100, 100), new Rectangle(128, 0, 64, 64), Color.White);
           // spriteBatch.Draw(tuna, new Vector2(130, 130), new Rectangle(0, 64, 64, 64), Color.White);
            spriteBatch.Draw(chicken, new Vector2(160, 160), new Rectangle(64, 0, 64, 64), Color.White);
            cloveSprite.Draw(gameTime, spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
