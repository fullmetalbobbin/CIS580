using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using FinickyFeline.StateMangement;

namespace FinickyFeline.Screens
{
    public class MainMenuScreen : MenuScreen
    {

        public MainMenuScreen() : base ("Main Menu")
        {
            var playGame = new MenuItem("Play Game");
            var tutorial = new MenuItem("Tutorial");
            var options = new MenuItem("Options");
            var exitGame = new MenuItem("Exit");

            MenuItems.Add(playGame);
            MenuItems.Add(tutorial);
            MenuItems.Add(options);
            MenuItems.Add(exitGame);
        }

    }
}
