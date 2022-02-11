﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FinickyFeline
{
    public class Chicken : IFood 
    {
        private Texture2D chickenTexture;

        private Vector2 chickenPosition;

        private BoundingRectangle chickenBounds;

        public bool Consumed { get; set; } = false;

        public Chicken(Vector2 position)
        {
            this.chickenPosition = position;
            this.chickenBounds = new BoundingRectangle(position + new Vector2(10,10), 64, 64);
        }

        public void LoadContent(ContentManager content)
        {
            chickenTexture = content.Load<Texture2D>("foodspritesheet");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(chickenTexture, chickenPosition, new Rectangle(0, 64, 64, 64), Color.White);
        }
    }
}