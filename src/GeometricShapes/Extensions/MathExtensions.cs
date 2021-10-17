using System;

namespace GeometricShapes.Extensions
{
    public static class MathExtensions
    {
        private const double TOLERANCE = 0.0000000001;
        
        /// <summary>
        /// Ограничение при сравнении double значений
        /// https://docs.microsoft.com/en-us/dotnet/api/system.double.equals
        /// </summary>
        public static bool Equals(double val1, double val2)
        {
            if (double.IsPositiveInfinity(val1) && double.IsPositiveInfinity(val2))
            {
                return true;
            }
            
            return Math.Abs(val1 - val2) < TOLERANCE;
        }
    }
}