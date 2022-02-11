using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FinickyFeline
{
    /// <summary>
    /// A class to represent an unfortunate upward-occuring digestional incident (delicately phrased but explicitly drawn) - "voom"
    /// </summary>
    public class VoomSprite
    {
        private Texture2D voomTexture;

        private short voomAnimationFrame = 0;

        private double voomAnimationTimer;

        public Vector2 VoomPosition = new Vector2(400, 250);

      

        public void LoadContent(ContentManager content)
        {
            voomTexture = content.Load<Texture2D>("voomspritesheet");
        }

        public void Update(GameTime gameTime)
        {

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
