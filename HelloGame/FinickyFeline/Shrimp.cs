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

        private BoundingRectangle shrimpBounds;

        public bool Consumed { get; set; } = false;

        public BoundingRectangle ShrimpBounds => shrimpBounds;

        public Shrimp(Vector2 position)
        {
            this.shrimpPosition = position;
            this.shrimpBounds = new BoundingRectangle(position + new Vector2(10, 10), 64, 64);
        }

        public void LoadContent(ContentManager content)
        {
            shrimpTexture = content.Load<Texture2D>("foodspritesheet");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Consumed) return;
            spriteBatch.Draw(shrimpTexture, shrimpPosition, new Rectangle(64, 64, 64, 64), Color.White);
        }

    }
}
