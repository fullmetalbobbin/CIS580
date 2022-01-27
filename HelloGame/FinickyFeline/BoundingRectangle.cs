using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;


namespace FinickyFeline
{
    public struct BoundingRectangle
    {
        public float X;

        public float Y;

        public float Width;

        public float Heigth;


        public float Left => X;

        public float Right => X + Width;

        public float Top => Y;

        public float Bottom => Y + Heigth;

        public BoundingRectangle(float x, float y, float width, float heigth)
        {
            X = x;
            Y = y;
            Width = width;
            Heigth = heigth;
        }

        public BoundingRectangle(Vector2 position, float width, float height)
        {
            X = position.X;
            Y = position.Y;
            Width = width;
            Heigth = height;
        }

        public bool Consumed(BoundingRectangle other)
        {
            return ConsumptionCollisionHelper.Consumed(this, other);
        }
    }
}
