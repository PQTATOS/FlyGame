using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FlyGame.Entities
{
    public class Extensions
    {
        public static Tuple<bool, bool> IsInGameBounds(Point cord)
        {
            var x = cord.X >= -64 && cord.X + 64 <= 1736;
            var y = cord.Y >= -64 && cord.Y + 64 <= 939;
            return Tuple.Create(x, y);
        }

        public static bool IsInObjectBounds(Point objectCord, Point cord)
        {
            var x = objectCord.X - cord.X;
            var y = objectCord.X - cord.X;
            return Math.Sqrt(x*x + y*y) < 500;
        }

        public static bool IsInCustomBounds(Point cord ,int[] bounds)
        {
            var x = cord.X >= bounds[2] && cord.X <= bounds[3];
            var y = cord.Y >= bounds[0] && cord.Y <= bounds[1];
            return x&&y;
        }

        public static bool IsHitObject(Point cord1, Point cord2)
        {
            var x = cord1.X > cord2.X && cord1.X < cord2.X + 64;
            var y = cord1.Y > cord2.Y && cord1.Y < cord2.Y + 64;
            return x && y;
        }
    }
}
