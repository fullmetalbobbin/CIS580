using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;



namespace GameProjectThree
{
    public class Starlight
    {
        private Texture2D starlightTexture;
        private Vector2 starlightPosition;

        public Starlight(Vector2 position)
        {
            this.starlightPosition = position;
        }

        public void LoadContent(ContentManager content)
        {
            starlightTexture = content.Load<Texture2D>("starlight");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(starlightTexture, starlightPosition, Color.Fuchsia);
        }


    }
}
