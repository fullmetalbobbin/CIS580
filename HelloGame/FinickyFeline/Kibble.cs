using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FinickyFeline
{
    public class Kibble : IFood
    {
        private Texture2D kibbleTexture;

        private Vector2 kibblePosition = new Vector2(300,300);

        public void LoadContent(ContentManager content)
        {
            kibbleTexture = content.Load<Texture2D>("foodspritesheet");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(kibbleTexture, new Vector2(58, 20), new Rectangle(0, 0, 64, 64), Color.White);
            spriteBatch.Draw(kibbleTexture, new Vector2(58, 370), new Rectangle(0, 0, 64, 64), Color.White);
        }

           
            

    }
}
