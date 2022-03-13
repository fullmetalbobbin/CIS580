using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace GameProjectThree
{
    public class Firefly
    {
        private Texture2D fireflyTexture;
        private Vector2 fireflyPosition;
        private Rectangle firelyBounds = new Rectangle(0,0, 64,64);

        public Vector2 FireflyPosition => fireflyPosition;

        public void LoadContent(ContentManager content)
        {
            fireflyTexture = content.Load<Texture2D>("");
        }

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyboardState.IsKeyDown(Keys.Up)) fireflyPosition -= Vector2.UnitY * time * 75;
            if (keyboardState.IsKeyDown(Keys.Down)) fireflyPosition += Vector2.UnitY * time * 125;
            if (keyboardState.IsKeyDown(Keys.Left)) fireflyPosition -= Vector2.UnitX * time * 100;
            if (keyboardState.IsKeyDown(Keys.Right)) fireflyPosition += Vector2.UnitX * time * 100;

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fireflyTexture, fireflyPosition, firelyBounds, Color.White);
        }

    }
}
