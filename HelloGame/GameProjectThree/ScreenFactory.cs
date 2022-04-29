using System;
using System.Collections.Generic;
using System.Text;
using GameProjectThree.StateManagement;
using GameProjectThree.Screens;

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
