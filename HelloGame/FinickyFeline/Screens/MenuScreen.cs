using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FinickyFeline.StateMangement;


namespace FinickyFeline
{
    public abstract class MenuScreen : GameScreen
    {
        private readonly List<MenuItem> menuItems = new List<MenuItem>();
        private int selectedMenuItemIndex;

        private string menuTitle;

        //private InputAction

        protected IList<MenuItem> MenuItems => menuItems;

        protected MenuScreen(string title)
        {
            menuTitle = title;
        }

    }
}
