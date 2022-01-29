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

    public class MouseSprite
    {
        private Texture2D mouseTexture;

        private short mouseAnimationFrame = 0;

        private double mouseAnimationTimer;

        //private double mouseDirectionTimer;

        //private bool mouseTurned = false;

        public Vector2 MousePosition = new Vector2(500,380);

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
            //SpriteEffects spriteEffects = (mouseTurned) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            //spriteBatch.Draw(mouseTexture, MousePosition, source, Color.White, 0, new Vector2(64, 64), 1.0f, spriteEffects, 0);
            spriteBatch.Draw(mouseTexture, MousePosition, source, Color.White);
        }


    }
}
