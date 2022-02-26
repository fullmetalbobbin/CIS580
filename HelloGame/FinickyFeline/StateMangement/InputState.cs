using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FinickyFeline.StateMangement
{
    public class InputState
    {
        // Initalizing for gamepad input
        public  GamePadState CurrentGamePadState;
        private  GamePadState previousGamePadState;

        // Initializing for keyboard input
        public  KeyboardState CurrentKeyboardState;
        private  KeyboardState previousKeyboardState;

        /*
        public InputState()
        {
            CurrentGamePadState = new GamePadState();
            previousGamePadState = new GamePadState();

            CurrentKeyboardState = new KeyboardState();
            previousKeyboardState = new KeyboardState();
        }
        */

        /*
        // Initalizing for gamepad input
        GamePadState currentGamePadState;
        GamePadState previousGamePadState;

        // Initializing for keyboard input
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        */


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
            previousGamePadState = CurrentGamePadState;
            CurrentGamePadState = GamePad.GetState(0);

            previousKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();

            // Directional input from gamepad
            ThisIsTheWay = 300 * CurrentGamePadState.ThumbSticks.Left * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Directional input from keyboard
            if (CurrentKeyboardState.IsKeyDown(Keys.Left) ||
                CurrentKeyboardState.IsKeyDown(Keys.A))
            {
                ThisIsTheWay += new Vector2(-300 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }
            if (CurrentKeyboardState.IsKeyDown(Keys.Right) ||
                CurrentKeyboardState.IsKeyDown(Keys.D))
            {
                ThisIsTheWay += new Vector2(300 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }
            if (CurrentKeyboardState.IsKeyDown(Keys.Up) ||
                CurrentKeyboardState.IsKeyDown(Keys.W))
            {
                ThisIsTheWay += new Vector2(0, -300 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (CurrentKeyboardState.IsKeyDown(Keys.Down) ||
                CurrentKeyboardState.IsKeyDown(Keys.S))
            {
                ThisIsTheWay += new Vector2(0, 300 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }


            // Exit the game
            if (CurrentGamePadState.Buttons.Back == ButtonState.Pressed ||
                CurrentKeyboardState.IsKeyDown(Keys.Escape))
            {
                Exit = true;
            }

        }
    }
}
