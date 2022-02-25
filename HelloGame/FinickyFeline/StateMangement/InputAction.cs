using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FinickyFeline.StateMangement
{
    public class InputAction
    {
        private bool firstPress;

        private Keys[] keys;
        private Buttons[] buttons;

        public InputAction(bool first, Keys[] pressedKeys, Buttons[] pressedButtons)
        {
            firstPress = first;
            keys = pressedKeys != null ? pressedKeys.Clone() as Keys[]: new Keys[0];
            buttons = pressedButtons != null ? pressedButtons.Clone() as Buttons[] : new Buttons[0];
        }

        public bool InputOccured(InputState inputState)
        {
            Keys keyTest;
            Buttons buttonTest;

            if (firstPress)
            {
                keyTest = inputState
            }
            return false;
        }
    }
}
