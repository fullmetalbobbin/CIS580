using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace FinickyFeline
{
    public struct BoundingCircle
    {
        public Vector2 Center;

        public float Radius;

        public BoundingCircle(Vector2 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        public bool Consumed(BoundingCircle other)
        {
            return ConsumptionCollisionHelper.Consumed(this, other);
        }

    }
}
