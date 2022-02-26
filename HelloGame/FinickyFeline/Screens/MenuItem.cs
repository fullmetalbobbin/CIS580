using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FinickyFeline.StateMangement;

namespace FinickyFeline
{
    public class MenuItem
    {
        private string itemText;
        private Vector2 itemPosition;

        public MenuItem(string incomingText)
        {
            itemText = incomingText;
        }

        public string ItemText
        {
            get => itemText;
            set => itemText = value;
        }

        public Vector2 ItemPosition
        {
            get => itemPosition;
            set => itemPosition = value;
        }
    }
}
