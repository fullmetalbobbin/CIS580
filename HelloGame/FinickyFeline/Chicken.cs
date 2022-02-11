using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FinickyFeline
{
    public class Chicken : IFood 
    {
        private Texture2D chickenTexture;

        private Vector2 chickenPosition;

        public void LoadContent(ContentManager content)
        {
            chickenTexture = content.Load<Texture2D>("foodspritesheet");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(chickenTexture, new Vector2(628, 20), new Rectangle(0, 64, 64, 64), Color.White);
            spriteBatch.Draw(chickenTexture, new Vector2(628,370), new Rectangle(0, 64, 64, 64), Color.White);
        }
    }
}
