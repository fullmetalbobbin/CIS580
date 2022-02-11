using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace FinickyFeline
{
    public enum MouseDirection
    { 
        Left,
        Right       
    }

    /// <summary>
    /// A class representing a tiny Jerry, doin' laps by the exit.
    /// I mean mouse.
    /// </summary>
    public class MouseSprite
    {
        private Texture2D mouseTexture;

        private short mouseAnimationFrame = 0;

        private double mouseAnimationTimer;

        public Vector2 MousePosition = new Vector2(480, 400);

        public MouseDirection MouseDirection = MouseDirection.Left;

        public void LoadContent(ContentManager content)
        {
            mouseTexture = content.Load<Texture2D>("mousespritesheet");
        }

        public void Update(GameTime gameTime)
        { 
            if (mouseAnimationFrame < 5)
            {
                 MouseDirection = MouseDirection.Left;
            }
            else
            {
                MouseDirection = MouseDirection.Right;
            }

            
            switch (MouseDirection)
            {
                case MouseDirection.Left:
                    MousePosition += new Vector2(-1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case MouseDirection.Right:
                    MousePosition += new Vector2(1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            mouseAnimationTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (mouseAnimationTimer > 0.5)
            {
                mouseAnimationFrame++;
                if (mouseAnimationFrame > 9) mouseAnimationFrame = 0;
                mouseAnimationTimer -= 0.5;
            }
            var source = new Rectangle(mouseAnimationFrame * 64, 0, 64, 64);  //Write over with position of undesired food
            spriteBatch.Draw(mouseTexture, MousePosition, source, Color.White);
        }


    }
}
