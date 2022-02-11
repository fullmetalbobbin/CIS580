using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FinickyFeline
{
    public class Tuna : IFood 
    {
        private Texture2D tunaTexture;

        private Vector2 tunaPosition;

        public void LoadContent(ContentManager content)
        {
            tunaTexture = content.Load<Texture2D>("foodspritesheet");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tunaTexture, new Vector2(514, 20), new Rectangle(64, 0, 64, 64), Color.White);
            spriteBatch.Draw(tunaTexture, new Vector2(514, 370), new Rectangle(64, 0, 64, 64), Color.White);
        }
    }
}
