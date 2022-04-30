using System;
using System.Collections.Generic;
using System.Text;
using GameProjectThree.StateManagement;

namespace GameProjectThree.Screens
{
    public class OptionsMenuScreen : MenuScreen
    {
        public OptionsMenuScreen() : base("Options") 
        {
            var back = new MenuEntry("Back");
            back.Selected += OnCancel;
        }
    }
}
