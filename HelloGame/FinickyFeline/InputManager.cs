using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;



namespace FinickyFeline
{
    /// <summary>
    /// Manages the input for the game from both gamepad and keyboard
    /// </summary>
    class InputManager
    {
        // Initalizing for gamepad input
        GamePadState currentGamePadState;
        GamePadState previousGamePadState;

        // Initializing for keyboard input
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;


      
        /// <summary>
        /// The current direction
        /// </summary>
        public Vector2 ThisIsTheWay { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Exit { get; private set; } = false;


        public void Update(GameTime gameTime)
        {
            // Updating input
            previousGamePadState = currentGamePadState;
            currentGamePadState = GamePad.GetState(0);

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            // Directional input from gamepad
            ThisIsTheWay = 200 * currentGamePadState.ThumbSticks.Left * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Directional input from keyboard
            if (currentKeyboardState.IsKeyDown(Keys.Left) ||
                currentKeyboardState.IsKeyDown(Keys.A))
            {
                ThisIsTheWay += new Vector2(-200 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }
            if (currentKeyboardState.IsKeyDown(Keys.Right) ||
                currentKeyboardState.IsKeyDown(Keys.D))
            {
                ThisIsTheWay += new Vector2(200 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }
            if (currentKeyboardState.IsKeyDown(Keys.Up) ||
                currentKeyboardState.IsKeyDown(Keys.W))
            {
                ThisIsTheWay += new Vector2(0, -200 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (currentKeyboardState.IsKeyDown(Keys.Down) ||
                currentKeyboardState.IsKeyDown(Keys.S))
            {
                ThisIsTheWay += new Vector2(0, 200 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }


            // Exit the game
            if (currentGamePadState.Buttons.Back == ButtonState.Pressed || 
                currentKeyboardState.IsKeyDown(Keys.Escape))
            {
                Exit = true;
            }

        }

    }
}
