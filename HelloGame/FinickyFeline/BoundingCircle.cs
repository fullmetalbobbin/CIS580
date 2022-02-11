using System;
using System.Collections.Generic;
using System.Text;

namespace FinickyFeline
{
    public struct BoundingCircle
    {
        public float X;

        public float Y;

        public float Radius;

        public BoundingCircle(float x, float y, float radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

    }
}
