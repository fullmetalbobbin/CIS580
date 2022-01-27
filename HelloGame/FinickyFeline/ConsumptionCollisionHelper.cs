using System;
using System.Collections.Generic;
using System.Text;

namespace FinickyFeline
{
    public static class ConsumptionCollisionHelper
    {
        public static bool Consumed(BoundingRectangle a, BoundingRectangle b)
        {
            return !(a.Right < b.Left || a.Left > b.Right ||
                     a.Top > b.Bottom || a.Bottom < b.Top);
        }
    }
}
