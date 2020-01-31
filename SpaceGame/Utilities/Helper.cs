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
            else if (radians < 2 * Math.PI)
                return radians + 2 * (float)Math.PI;
            else
                return radians;
        }
    }
}
