using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace FinickyFeline
{
    interface IFood
    {

        void LoadContent(ContentManager content);
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch);



    }
}
