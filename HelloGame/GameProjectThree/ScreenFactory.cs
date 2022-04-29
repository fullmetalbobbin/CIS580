using System;
using System.Collections.Generic;
using System.Text;
using GameProjectThree.StateManagement;

namespace GameProjectThree
{
    class ScreenFactory: IScreenFactory
    {
        public GameScreen CreateScreen(Type screenType)
        {
            return Activator.CreateInstance(screenType) as GameScreen;
        }
    }
}
