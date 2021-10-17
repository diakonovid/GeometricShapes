using System;

namespace GeometricShapes
{
    public static class GuardClauses
    {
        public static void IsValidCircle(double radius)
        {
            if (radius <= 0 || double.IsPositiveInfinity(radius))
                throw new ArgumentException("Радиус круга не соответствует установленным ограничениям", nameof(radius));
        }

        public static void IsValidTriangle(double[] sides)
        {
            const int count = 3;
            if (sides.Length != count)
                throw new ArgumentException($"Количество сторон треугольника не соответствует числу {count}",
                    nameof(sides));

            var isValid = sides[0] < sides[1] + sides[2]
                          && sides[1] < sides[0] + sides[2]
                          && sides[2] < sides[1] + sides[0];
            if (!isValid)
                throw new ArgumentException("Треугольника с заданными сторонами не существует", nameof(sides));
        }

        public static void IsValidRightTriangle(bool isRight)
        {
            if (!isRight) throw new ArgumentException("Треугольник не является прямоугольным");
        }
    }
}