using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FinickyFeline
{
    public class Beef : IFood
    {
        private Texture2D beefTexture;

        private Vector2 beefPosition;

        private BoundingRectangle beefBounds;

        public bool Consumed { get; set; } = false;

        public Beef(Vector2 position)
        {
            this.beefPosition = position;
            this.beefBounds = new BoundingRectangle(position + new Vector2(10, 10), 64, 64);
        }

        public void LoadContent(ContentManager content)
        {
            beefTexture = content.Load<Texture2D>("foodspritesheet");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(beefTexture, new Vector2(286, 20), new Rectangle(128, 64, 64, 64), Color.White);
        }

    }
}
