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
        PivotFromLeftToRight,
        Right,
        PivotFromRightToLeft
        
    }
    public class MouseSprite
    {
        private Texture2D mouseTexture;

        private short mouseAnimationFrame = 0;

        private double mouseAnimationTimer;

        private double mouseDirectionTimer;

        private bool mouseTurned = false;

        public Vector2 MousePosition = new Vector2(700,300);

        public MouseDirection MouseDirection;

        public void LoadContent(ContentManager content)
        {
            mouseTexture = content.Load<Texture2D>("mousespritesheet");
        }

        public void Update(GameTime gameTime)
        { 
            mouseDirectionTimer = gameTime.ElapsedGameTime.TotalSeconds;

            if (mouseDirectionTimer > 1.0)
            {
                switch (MouseDirection)
                {
                    case MouseDirection.Left:
                        MouseDirection = MouseDirection.PivotFromLeftToRight;
                        break;
                    case MouseDirection.PivotFromLeftToRight:
                        MouseDirection = MouseDirection.Right;
                        mouseAnimationFrame = 4;
                        break;
                    case MouseDirection.Right:
                        MouseDirection = MouseDirection.PivotFromRightToLeft;
                        break;
                    case MouseDirection.PivotFromRightToLeft:
                        MouseDirection = MouseDirection.Left;
                        mouseAnimationFrame = 9;
                        break;               
                }
                mouseDirectionTimer -= 1.0;
            }

            switch (MouseDirection)
            {
                case MouseDirection.Left:
                    MousePosition += new Vector2(-1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case MouseDirection.PivotFromLeftToRight:
                    MousePosition += new Vector2(1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case MouseDirection.Right:
                    MousePosition += new Vector2(1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case MouseDirection.PivotFromRightToLeft:
                    MousePosition += new Vector2(-1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            mouseAnimationTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (mouseAnimationTimer > 1.0)
            {
                mouseAnimationFrame++;
                if (mouseAnimationFrame > 9) mouseAnimationFrame = 0;
                mouseAnimationTimer -= 1.0;
            }
            var source = new Rectangle(mouseAnimationFrame * 64, 0, 64, 64);  //Write over with position of undesired food
            //SpriteEffects spriteEffects = (mouseTurned) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            //spriteBatch.Draw(mouseTexture, MousePosition, source, Color.White, 0, new Vector2(64, 64), 1.0f, spriteEffects, 0);
            spriteBatch.Draw(mouseTexture, MousePosition, source, Color.White);
        }


    }
}
