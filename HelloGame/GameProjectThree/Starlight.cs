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
        private BoundingCircle starlightBounds;

        public BoundingCircle StarlightBounds => starlightBounds;

        public bool Collected { get; set; } = false;

        public Starlight(Vector2 position)
        {
            this.starlightPosition = position;
            this.starlightBounds = new BoundingCircle(starlightPosition + new Vector2(16, 16), 16);
        }

        public void LoadContent(ContentManager content)
        {
            starlightTexture = content.Load<Texture2D>("starlight");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Collected) return;
            spriteBatch.Draw(starlightTexture, starlightPosition, Color.Fuchsia);
        }


    }
}
