using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FinickyFeline.StateMangement
{
    public class ScreenManager : DrawableGameComponent
    {
        private readonly List<GameScreen> currentScreens = new List<GameScreen>();
        private List<GameScreen> tempCurrentScreens = new List<GameScreen>();

        private readonly ContentManager content;
        private readonly InputState input = new InputState();

        private bool isInitalized;

 

        public SpriteBatch SpriteBatch { get; set; }

        public SpriteFont SpriteFont { get; set; }

        //public Texture2D BaseTexture { get; set; }


        public ScreenManager(Game game) : base(game)
        {
            content = new ContentManager(game.Services, "Content");
        }



        public override void Initialize()
        {
            base.Initialize();
            isInitalized = true;
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFont = content.Load<SpriteFont>("dosis");
            //BaseTexture = content.Load<Texture2D>();

            foreach (var screen in currentScreens)
            {
                screen.ActivateScreen();
            }
        
        }

        protected override void UnloadContent()
        {
            foreach (var screen in currentScreens)
            {
                screen.UnloadScreen();
            }
        }

        public override void Update(GameTime gameTime)
        {
            input.Update();
        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }




        public bool ActivateScreen()
        {
            return false;
        }

        public void DeactivateScreen()
        { }

        public GameScreen[] GetCurrentScreens()
        {
            return currentScreens.ToArray();
        }

        public void RemoveScreen(GameScreen gameScreen)
        {
            if (isInitalized)
            {
                gameScreen.UnloadScreen();
            }


        }
    }
}
