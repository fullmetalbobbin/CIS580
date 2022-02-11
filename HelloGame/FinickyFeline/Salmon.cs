using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FinickyFeline
{
    public class Salmon : IFood 
    {
        private Texture2D salmonTexture;

        private Vector2 salmonPosition;

        public void LoadContent(ContentManager content)
        {
            salmonTexture = content.Load<Texture2D>("foodspritesheet");
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(salmonTexture, new Vector2(400, 20), new Rectangle(128, 0, 64, 64), Color.White);
            spriteBatch.Draw(salmonTexture, new Vector2(400, 370), new Rectangle(128, 0, 64, 64), Color.White);
        }
    }
}
