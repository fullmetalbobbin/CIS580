using System;
using System.Collections.Generic;
using System.Text;

namespace FinickyFeline.StateMangement
{
    public enum ScreenState
    {
        TransitionToActive,
        Active,
        TransitionToHidden,
        Hidden
    }
}
