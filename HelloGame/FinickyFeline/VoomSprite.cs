using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FinickyFeline
{
    public enum Spread
    { 
        Small = 0,
        Medium = 1,
        Large = 2,
        Dried = 3
    }

    class VoomSprite
    {
        private Texture2D voomTexture;

        private short voomAnimationFrame = 0;

        private double voomAnimationTimer;

        public Vector2 VoomPosition;

        

        public void LoadContent(ContentManager content)
        {
            //voomTexture = content.Load<Texture2D>();
        }

        public void Update(GameTime gameTime)
        { 

        }

        public void Draw(GameTime gameTime, SpriteBatch sprite)
        {
            
        }

    }
}
