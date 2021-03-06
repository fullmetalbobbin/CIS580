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

        private BoundingRectangle tunaBounds;

        public bool Consumed { get; set; } = false;

        public BoundingRectangle TunaBounds => tunaBounds;

        public Tuna(Vector2 position)
        {
            this.tunaPosition = position;
            this.tunaBounds = new BoundingRectangle(new Vector2(this.tunaPosition.X - 20, this.tunaPosition.Y -15), 64, 32);
        }

        public void LoadContent(ContentManager content)
        {
            tunaTexture = content.Load<Texture2D>("foodspritesheet");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Consumed) return;
            spriteBatch.Draw(tunaTexture, tunaPosition, new Rectangle(64, 0, 64, 64), Color.White);
        }
    }
}
