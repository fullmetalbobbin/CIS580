using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FinickyFeline.StateMangement
{
    public class ScreenManager
    {
        private readonly ContentManager content;


        public ScreenManager(Game game)
        {
            content = new ContentManager(game.Services, "Content");
        }
    }
}
