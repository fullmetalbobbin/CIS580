using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FinickyFeline
{
    public class Shrimp : IFood
    {
        private Texture2D shrimpTexture;

        private Vector2 shrimpPosition;

        public void LoadContent(ContentManager content)
        {
            shrimpTexture = content.Load<Texture2D>("foodspritesheet");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shrimpTexture, new Vector2(172, 20), new Rectangle(64, 64, 64, 64), Color.White);
            spriteBatch.Draw(shrimpTexture, new Vector2(172, 370), new Rectangle(64, 64, 64, 64), Color.White);

        }

    }
}
