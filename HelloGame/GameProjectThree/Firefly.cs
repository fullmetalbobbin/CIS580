using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace GameProjectThree
{
    public class Firefly
    {
        const float LINEAR_ACCELERATION = 1;
        const float ANGULAR_ACCELERATION = 1;


        //private Rectangle firelyBounds = new Rectangle(0,0, 64,64);

        private BoundingCircle fireflyBounds = new BoundingCircle(new Vector2(250,250), 32);

        public BoundingCircle FireflyBounds => fireflyBounds;

        public Color FireflyColor = Color.White;

        Game game;
        Texture2D fireflyTexture;
        public Vector2 FireflyPosition;
        Vector2 fireflyDirection;
        Vector2 fireflyVelocity;

        float fireflyAngle;
        float fireflyAngularVelocity;

        BlendState BlendState;

        public Firefly(Game game)
        {
            this.game = game;
            this.FireflyPosition = new Vector2(250, 250);
            this.fireflyDirection = -Vector2.UnitY;
            this.fireflyBounds.Center = FireflyPosition;
            BlendState = BlendState.Additive;
        }


        public void LoadContent(ContentManager content)
        {
            fireflyTexture = content.Load<Texture2D>("firefly");
        }

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 fireflyAcceleration = new Vector2(0,0);
            float fireflyAngularAcceleration = 0;

            if (keyboardState.IsKeyDown(Keys.Up)) FireflyPosition -= Vector2.UnitY * time * 85;
            if (keyboardState.IsKeyDown(Keys.Down)) FireflyPosition += Vector2.UnitY * time * 125;

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                fireflyAcceleration += fireflyDirection * LINEAR_ACCELERATION;
                fireflyAngularAcceleration += ANGULAR_ACCELERATION;
            }

            //fireflyPosition -= Vector2.UnitX * time * 100;

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                fireflyAcceleration += fireflyDirection * LINEAR_ACCELERATION;
                fireflyAngularAcceleration -= ANGULAR_ACCELERATION;
            }
                
                //fireflyPosition += Vector2.UnitX * time * 100;

            fireflyAngularVelocity += fireflyAngularAcceleration * time;
            fireflyAngle += fireflyAngularVelocity * time;
            fireflyDirection.X = (float)Math.Sin(fireflyAngle);
            fireflyDirection.Y = (float)-Math.Cos(fireflyAngle);

            fireflyVelocity += fireflyAcceleration * time;
            FireflyPosition += fireflyVelocity * time;

            fireflyBounds.Center = FireflyPosition;

            var viewport = game.GraphicsDevice.Viewport;
            if (FireflyPosition.X < 0 || FireflyPosition.X > 500) FireflyPosition.X = viewport.Width;

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fireflyTexture, FireflyPosition, null, FireflyColor, fireflyAngle, new Vector2(64,64), 1f, SpriteEffects.FlipVertically, 0);
        }

    }
}
