using System;
using System.Collections.Generic;
using System.Text;

namespace FinickyFeline.StateManger
{
    public interface IScreenFactory
    {
        GameScreen CreateScreen(Type screenType);
    }
}
