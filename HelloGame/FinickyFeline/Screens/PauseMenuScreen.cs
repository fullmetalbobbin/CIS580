using System;
using System.Collections.Generic;
using System.Text;
using FinickyFeline.Screens;
using FinickyFeline.StateMangement;

namespace FinickyFeline.Screens
{
    public class PauseMenuScreen : MenuScreen
    {
        public PauseMenuScreen() : base("Paused")
        {
            var resumeGame = new MenuItem("Resume Game");
            var quitGame = new MenuItem("Quit Game");



            MenuItems.Add(resumeGame);
            MenuItems.Add(quitGame);
        }

        private void QuitGameSelected(object sender, EventArgs e)
        {
            //Make popup message box to confirm or cancel
        }
    }
}
