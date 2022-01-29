using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FinickyFeline
{

    class VoomSprite
    {
        private Texture2D voomTexture;

        //private Vector2 testVoom = new Vector2(200, 50);

        private short voomAnimationFrame = 0;

        private double voomAnimationTimer;

        public Vector2 VoomPosition = new Vector2(350, 50);

      

        public void LoadContent(ContentManager content)
        {
            voomTexture = content.Load<Texture2D>("voomspritesheet");
        }

        public void Update(GameTime gameTime)
        {
            /*
            voomAnimationTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if(voomAnimationTimer > 2.0 && voomAnimationFrame < 4)
            {
                voomAnimationFrame++;
                VoomSpread++;
                voomAnimationTimer -= 2.0;
            }
            */
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            
            voomAnimationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (voomAnimationTimer > 2.0 && voomAnimationFrame < 4)
            {
                voomAnimationFrame++;
                voomAnimationTimer -= 2.0;
            }
            

            var source = new Rectangle(voomAnimationFrame * 64, 0, 64, 64);  //Write over with position of undesired food
            spriteBatch.Draw(voomTexture, VoomPosition, source, Color.White);
        }

    }
}
