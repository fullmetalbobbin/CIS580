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

        public BoundingRectangle BeefBounds => beefBounds;

        public Beef(Vector2 position)
        {
            this.beefPosition = position;
            this.beefBounds = new BoundingRectangle(new Vector2(this.beefPosition.X, this.beefPosition.Y), 40,40);
        }

        public void LoadContent(ContentManager content)
        {
            beefTexture = content.Load<Texture2D>("foodspritesheet");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Consumed) return;
            spriteBatch.Draw(beefTexture, beefPosition, new Rectangle(128, 64, 64, 64), Color.White);
        }

    }
}
