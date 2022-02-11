using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace FinickyFeline
{
    public static class ConsumptionCollisionHelper
    {
        public static bool Consumed(BoundingRectangle aR, BoundingRectangle bR)
        {
            return !(aR.Right < bR.Left || aR.Left > bR.Right ||
                     aR.Top > bR.Bottom || aR.Bottom < bR.Top);
        }

        public static bool Consumed(BoundingCircle aC, BoundingCircle bC)
        {
            return Math.Pow(aC.Radius + bC.Radius, 2) >=
                   Math.Pow(aC.Center.X - bC.Center.X, 2) +
                   Math.Pow(aC.Center.Y - bC.Center.Y, 2);
        }


        public static bool Consumed(BoundingCircle aC, BoundingRectangle bR)
        {
            float nearestX = MathHelper.Clamp(aC.Center.X, bR.Left, bR.Right);
            float nearestY = MathHelper.Clamp(aC.Center.Y, bR.Top, bR.Bottom);
            return Math.Pow(aC.Radius, 2) >=
                   Math.Pow(aC.Center.X - nearestX, 2) +
                   Math.Pow(aC.Center.Y - nearestY, 2);
        }

        public static bool Consumed(BoundingRectangle aR, BoundingCircle bC)
        {
            return Consumed(bC, aR);
        }

    }
}
