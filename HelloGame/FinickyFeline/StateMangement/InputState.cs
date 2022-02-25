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
        public readonly GamePadState CurrentGamePadState;
        private readonly GamePadState previousGamePadState;

        // Initializing for keyboard input
        public readonly KeyboardState CurrentKeyboardState;
        private readonly KeyboardState previousKeyboardState;

        public InputState()
        {
            CurrentGamePadState = new GamePadState();
            previousGamePadState = new GamePadState();

            CurrentKeyboardState = new KeyboardState();
            previousKeyboardState = new KeyboardState();

        }
    }
}
