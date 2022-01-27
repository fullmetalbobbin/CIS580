using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace FinickyFeline
{
    class CloveSprite
    {
        private GamePadState gamePadState;

        private KeyboardState keyboardState;

        private Texture2D cloveTexture;

        private Vector2 clovePosition = new Vector2(100, 300);

        private bool turned = false;


        public void LoadContent(ContentManager content)
        {
            cloveTexture = content.Load<Texture2D>("clovespritesheet");
        }

        public void Update(GameTime gameTime)
        {
            gamePadState = GamePad.GetState(0);
            keyboardState = Keyboard.GetState();

            clovePosition += gamePadState.ThumbSticks.Left * new Vector2(1, -1);
            if (gamePadState.ThumbSticks.Left.X < 0) turned = true;
            if (gamePadState.ThumbSticks.Left.X > 0) turned = false;

            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W)) clovePosition += new Vector2(0, -1);
            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S)) clovePosition += new Vector2(0, 1);
            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            { 
                clovePosition += new Vector2(-1, 0);
                turned = true;
            }
            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                clovePosition += new Vector2(1, 0);
                turned = false;
            }

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            SpriteEffects spriteEffects = (turned) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(cloveTexture, clovePosition, null,  Color.White, 0, new Vector2 (64,64), 1.0f, spriteEffects, 0);
        }

    }
}
