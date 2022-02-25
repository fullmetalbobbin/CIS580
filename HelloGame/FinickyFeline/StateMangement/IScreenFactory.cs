using System;
using System.Collections.Generic;
using System.Text;

namespace FinickyFeline.StateMangement
{
    public interface IScreenFactory
    {
        GameScreen CreateScreen(Type screenType);
    }
}
