using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Utilities
{
    /// <summary>
    /// Helper class.
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// Will filter out values based on maximum and minimum inputs.
        /// </summary>
        /// <param name="value">Value to filter.</param>
        /// <param name="min">Minimum the value can be.</param>
        /// <param name="max">Maximum the value can be.</param>
        public static int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        /// <summary>
        /// Will filter out values based on maximum and minimum inputs.
        /// </summary>
        /// <param name="value">Value to filter.</param>
        /// <param name="min">Minimum the value can be.</param>
        /// <param name="max">Maximum the value can be.</param>
        public static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        /// <summary>
        /// Will make sure any number is between 0 and 2 x PI. Any number larger or smaller will loop around.
        /// </summary>
        /// <param name="radians">Number to check (in radians).</param>
        public static float SimplifyRadians(float radians)
        {
            if (radians > 2 * Math.PI)
                return radians - 2 * (float)Math.PI;
            else if (radians < 0)
                return radians + 2 * (float)Math.PI;
            else
                return radians;
        }

        /// <summary>
        /// Will return a 2-dimensional vector with a random angle and length.
        /// </summary>
        /// <param name="maxLength">The maximum value of the length.</param>
        public static Vector2 Vector2RandomDirecAndLength(int maxLength)
        {
            float angle = LimitsEdgeGame.r.Next(0, (int)(Math.PI * 200) + 1) / 100f;
            return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * LimitsEdgeGame.r.Next(0, maxLength + 1);
        }

        /// <summary>
        /// Will return a 2-dimensional vector with a random direction.
        /// </summary>
        /// <param name="length">Length of the vector.</param>
        public static Vector2 Vector2RandomDirection(int length)
        {
            float angle = LimitsEdgeGame.r.Next(0, (int)(Math.PI * 200) + 1) / 100f;
            return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * length;
        }

        /// <summary>
        /// Rotates a given vector by a given angle.
        /// </summary>
        /// <param name="vector">Vector to rotate.</param>
        /// <param name="angle">Angle to rotate the vector.</param>
        /// <returns></returns>
        public static Vector2 RotateVector(Vector2 vector, float angle)
        {
            return new Vector2(
                vector.X * (float)Math.Cos(angle) - vector.Y * (float)Math.Sin(angle), 
                vector.X * (float)Math.Sin(angle) + vector.Y * (float)Math.Cos(angle));
        }

        /// <summary>
        /// Generates a random 2-dimensional vector placed inside of a rectangle.
        /// </summary>
        /// <param name="rectangle">Rectangle to place vector inside of.</param>
        public static Vector2 RandomPosInRectangle(Rectangle rectangle)
        {
            return new Vector2(
                rectangle.X + LimitsEdgeGame.r.Next(0, rectangle.Width + 1),
                rectangle.Y + LimitsEdgeGame.r.Next(rectangle.Height + 1));
        }
    }
}
