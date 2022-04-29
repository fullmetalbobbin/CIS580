using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameProjectThree.StateManagement;
using Microsoft.Xna.Framework.Audio;


namespace GameProjectThree.Screens
{
    public class MainMenuScreen : MenuScreen
    {

        public MainMenuScreen() : base("Main Menu")
        {            
            var playGameMenuEntry = new MenuEntry("Play");
            var optionsMenuEntry = new MenuEntry("Options");
            var exitMenuEntry = new MenuEntry("Exit");

           
            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            optionsMenuEntry.Selected += OptionsMenuEntrySelected;
            exitMenuEntry.Selected += OnCancel;

            MenuEntries.Add(playGameMenuEntry);
            MenuEntries.Add(optionsMenuEntry);
            MenuEntries.Add(exitMenuEntry);

        }

    private void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
    {
            //LoadingScreen.Load(ScreenManager, true, e.PlayerIndex, new GameplayScreen(), new CutSceneScreen());
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex, new GameplayScreen());
    }


    private void OptionsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
    {
            ScreenManager.AddScreen(new OptionsMenuScreen(), e.PlayerIndex);
    } 

    protected override void OnCancel(PlayerIndex playerIndex)
    {
        const string message = "Are you sure you want to fly away?";
        var confirmExitMessageBox = new MessageBoxScreen(message);

        confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;

        ScreenManager.AddScreen(confirmExitMessageBox, playerIndex);
    }

    private void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
    {
        ScreenManager.Game.Exit();
    }
}
}
