using System;
using System.Collections.Generic;
using System.Text;

namespace GameProjectThree.StateManagement
{
    public interface IScreenFactory
    {
        GameScreen CreateScreen(Type screenType);
    }
}
