using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Utilities
{
    public class Helper
    {
        public static int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        public static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        public static float SimplifyRadians(float radians)
        {
            if (radians > 2 * Math.PI)
                return radians - 2 * (float)Math.PI;
            else if (radians < 0)
                return radians + 2 * (float)Math.PI;
            else
                return radians;
        }

        public static Vector2 Vector2RandomDirecAndLength(int maxLength)
        {
            float angle = LimitsEdgeGame.r.Next(0, (int)(Math.PI * 200) + 1) / 100f;
            return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * LimitsEdgeGame.r.Next(0, maxLength + 1);
        }

        public static Vector2 Vector2RandomDirection(int length)
        {
            float angle = LimitsEdgeGame.r.Next(0, (int)(Math.PI * 200) + 1) / 100f;
            return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * length;
        }

        public static Vector2 RotateVector(Vector2 vector, float angle)
        {
            return new Vector2(
                vector.X * (float)Math.Cos(angle) - vector.Y * (float)Math.Sin(angle), 
                vector.X * (float)Math.Sin(angle) + vector.Y * (float)Math.Cos(angle));
        }

        public static Vector2 RandomPosInRectangle(Rectangle rectangle)
        {
            return new Vector2(
                rectangle.X + LimitsEdgeGame.r.Next(0, rectangle.Width + 1),
                rectangle.Y + LimitsEdgeGame.r.Next(rectangle.Height + 1));
        }

        public static Vector2 PointToVector2(Point point)
        {
            return new Vector2(point.X, point.Y);
        }
    }
}
