using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameProjectThree.StateManagement
{
    class InputAction
    {
        private readonly Keys[] _keys;
        private readonly Buttons[] _buttons; 
        
        private readonly bool _firstPressOnly;
        private delegate bool ButtonPress(Buttons button, PlayerIndex? controllingPlayer, out PlayerIndex player);
        private delegate bool KeyPress(Keys key, PlayerIndex? controllingPlayer, out PlayerIndex player);


        public InputAction(Buttons[] triggerButtons, Keys[] triggerKeys, bool firstPressOnly)
        {
            _keys = triggerKeys != null ? triggerKeys.Clone() as Keys[] : new Keys[0];
            _buttons = triggerButtons != null ? triggerButtons.Clone() as Buttons[] : new Buttons[0];            
            _firstPressOnly = firstPressOnly;
        }

        public bool Occurred(InputState stateToTest, PlayerIndex? playerToTest, out PlayerIndex player)
        {
            KeyPress keyTest;
            ButtonPress buttonTest;
            
            if (_firstPressOnly)
            {
                keyTest = stateToTest.IsNewKeyPress;
                buttonTest = stateToTest.IsNewButtonPress;               
            }
            else
            {
                keyTest = stateToTest.IsKeyPressed;
                buttonTest = stateToTest.IsButtonPressed;               
            }

            foreach (var button in _buttons)
            {
                if (buttonTest(button, playerToTest, out player))
                return true;
            }
            foreach (var key in _keys)
            {
                if (keyTest(key, playerToTest, out player))
                return true;
            }

            player = PlayerIndex.One;
            return false;
        }
    }
}
