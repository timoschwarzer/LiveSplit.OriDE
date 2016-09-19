using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OriMap {
    abstract class MapCalc {
        public const double FACTOR_X = 4.11;
        public const double FACTOR_Y = 4.10;
        public const float TRANSFORM_TO_ORIGIN_X = -4499;
        public const float TRANSFORM_TO_ORIGIN_Y = -3955;

        public static Point mapToIngame(Point point) {
            return new Point(
                (point.X + TRANSFORM_TO_ORIGIN_X) / FACTOR_X,
                -(point.Y + TRANSFORM_TO_ORIGIN_Y) / FACTOR_Y
            );
        }

        public static Point ingameToMap(Point point) {
            return new Point(
                (point.X) * FACTOR_X - TRANSFORM_TO_ORIGIN_X,
                -(point.Y) * FACTOR_Y - TRANSFORM_TO_ORIGIN_Y
            );
        }

        public static double distance(Point p1, Point p2) {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
    }
}
