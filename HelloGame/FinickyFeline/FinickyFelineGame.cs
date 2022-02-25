using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FinickyFeline.StateMangement;

namespace FinickyFeline
{
    public class FinickyFelineGame : Game
    {
        private readonly ScreenManager screenManager;



        private InputManager inputManager;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private CloveSprite cloveSprite;
        private VoomSprite voomSprite;
        private MouseSprite mouseSprite;
        private Texture2D title;
        private SpriteFont dosis;
        private Kibble[] kibbles;
        private Shrimp[] shrimps;
        private Beef[] beefs;
        private Salmon[] salmons;
        private Tuna[] tunas;
        private Chicken[] chickens;
        //private IFood[] foods;

        private Texture2D ref32;



        public FinickyFelineGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "The Finicky Feline";
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 750;

            var screenFactory = new ScreenFactory();
            Services.AddService(typeof(IScreenFactory), screenFactory);

            screenManager = new ScreenManager(this);
            //Components.Add(screenManager);

            //AddInitalScreens();
        }

        protected override void Initialize()
        {
 
            // TODO: Add your initialization logic here
            inputManager = new InputManager();
            cloveSprite = new CloveSprite();
            voomSprite = new VoomSprite();
            mouseSprite = new MouseSprite();
            kibbles = new Kibble[]
                { 
                    new Kibble(new Vector2(58, 20)),
                    new Kibble(new Vector2(58, 370))
                };
            shrimps = new Shrimp[]
                { 
                    new Shrimp(new Vector2(172, 20)),
                    new Shrimp(new Vector2(172, 370))
                };
            beefs = new Beef[]
                { 
                    new Beef(new Vector2(286, 20)),
                    new Beef(new Vector2(286, 370))
                };
            salmons = new Salmon[]
                { 
                    new Salmon(new Vector2(400, 20)),
                    new Salmon(new Vector2(400, 370))
                };
            tunas = new Tuna[]
                { 
                    new Tuna(new Vector2(514, 20)),
                    new Tuna(new Vector2(514, 370))
                };
            chickens = new Chicken[]
                {
                    new Chicken(new Vector2(628, 20)),
                    new Chicken(new Vector2(628, 370))
                };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            cloveSprite.LoadContent(Content);
            voomSprite.LoadContent(Content);
            mouseSprite.LoadContent(Content);
            title = Content.Load<Texture2D>("finickyfelinetitle");
            dosis = Content.Load<SpriteFont>("dosis");

            foreach(var kibble in kibbles) kibble.LoadContent(Content);
            foreach(var shrimp in shrimps) shrimp.LoadContent(Content);
            foreach(var beef in beefs) beef.LoadContent(Content);
            foreach(var salmon in salmons) salmon.LoadContent(Content);
            foreach(var tuna in tunas) tuna.LoadContent(Content);
            foreach(var chicken in chickens) chicken.LoadContent(Content);

            ref32 = Content.Load<Texture2D>("32x32");
        }

        protected override void Update(GameTime gameTime)
        {
            inputManager.Update(gameTime);
            if (inputManager.Exit) Exit();


            // TODO: Add your update logic here
            cloveSprite.Update(gameTime);
            //cloveSprite.CloveColor = Color.White;
            voomSprite.Update(gameTime);
            mouseSprite.Update(gameTime);

            foreach (var kibble in kibbles) 
            {
                if (!kibble.Consumed && kibble.KibbleBounds.Consumed(cloveSprite.CloveBounds))
                {
                    kibble.Consumed = true;
                    //PLAY VOOM ANIMATION HERE
                    cloveSprite.CloveColor = Color.OliveDrab;
                }
            }
            foreach (var shrimp in shrimps)
            {
                if(!shrimp.Consumed && shrimp.ShrimpBounds.Consumed(cloveSprite.CloveBounds))
                {
                    shrimp.Consumed = true;
                    //PLAY PURR AUDIO HERE... whenever you make it
                    cloveSprite.CloveColor = Color.White;
                }
            }
            foreach (var beef in beefs)
            {
                if (!beef.Consumed && beef.BeefBounds.Consumed(cloveSprite.CloveBounds))
                {
                    beef.Consumed = true;
                    //PLAY VOOM ANIMATION HERE
                    cloveSprite.CloveColor = Color.GreenYellow;
                }
            }
            foreach (var salmon in salmons)
            {
                if (!salmon.Consumed && salmon.SalmonBounds.Consumed(cloveSprite.CloveBounds))
                {
                    salmon.Consumed = true;
                    //PLAY PURR AUDIO HERE... whenever you make it
                    cloveSprite.CloveColor = Color.White;
                }
            }
            foreach (var tuna in tunas)
            {
                if (!tuna.Consumed && tuna.TunaBounds.Consumed(cloveSprite.CloveBounds))
                {
                    tuna.Consumed = true;
                    //PLAY PURR AUDIO HERE... whenever you make it
                    cloveSprite.CloveColor = Color.White;
                }
            }
            foreach (var chicken in chickens)
            {
                if (!chicken.Consumed && chicken.ChickenBounds.Consumed(cloveSprite.CloveBounds))
                {
                    chicken.Consumed = true;
                    //PLAY VOOM ANIMATION HERE
                    cloveSprite.CloveColor = Color.YellowGreen;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            
            spriteBatch.Draw(title, new Vector2(120, 100), Color.White);
            foreach (var kibble in kibbles) kibble.Draw(gameTime, spriteBatch);
            foreach (var shrimp in shrimps) shrimp.Draw(gameTime, spriteBatch);
            foreach (var beef in beefs) beef.Draw(gameTime, spriteBatch);
            foreach (var salmon in salmons) salmon.Draw(gameTime, spriteBatch);
            foreach (var tuna in tunas) tuna.Draw(gameTime, spriteBatch);
            foreach (var chicken in chickens) chicken.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(dosis, "Exit game - Press Back or ESC", new Vector2(GraphicsDevice.Viewport.Width/3  + 10,GraphicsDevice.Viewport.Height - 30), Color.Black );
            mouseSprite.Draw(gameTime, spriteBatch);
            cloveSprite.Draw(gameTime, spriteBatch);

            //spriteBatch.Draw(ref32, new Vector2(350,325), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
