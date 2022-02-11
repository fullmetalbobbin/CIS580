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

        private Vector2 kibblePosition;

        private BoundingRectangle kibbleBounds;

        public bool Consumed { get; set; } = false;

        public Kibble(Vector2 position)
        {
            this.kibblePosition = position;
            this.kibbleBounds = new BoundingRectangle(position + new Vector2(10, 10), 64, 64);
        }

        public void LoadContent(ContentManager content)
        {
            kibbleTexture = content.Load<Texture2D>("foodspritesheet");
        }


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(kibbleTexture, kibblePosition, new Rectangle(0, 0, 64, 64), Color.White);
        }

                      

    }
}
