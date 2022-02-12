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

        private BoundingRectangle salmonBounds;

        public bool Consumed { get; set; } = false;

        public BoundingRectangle SalmonBounds => salmonBounds;

        public Salmon(Vector2 position)
        {
            this.salmonPosition = position;
            //this.salmonBounds = new BoundingRectangle(position + new Vector2(10, 10), 64, 64);
            this.salmonBounds = new BoundingRectangle(new Vector2(this.salmonPosition.X -20, this.salmonPosition.Y -15), 64, 32);
        }

        public void LoadContent(ContentManager content)
        {
            salmonTexture = content.Load<Texture2D>("foodspritesheet");
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Consumed) return;
            spriteBatch.Draw(salmonTexture, salmonPosition, new Rectangle(128, 0, 64, 64), Color.White); ;
        }
    }
}
