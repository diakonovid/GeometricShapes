using System;
using System.Collections.Generic;
using System.Linq;
using GeometricShapes.Extensions;

namespace GeometricShapes.Shapes
{
    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Стороны треугольника в порядке возрастания
        /// </summary>
        public IReadOnlyList<double> Sides { get; }
        
        public bool IsRight => CheckIsRight();

        /// <summary>
        /// Создание треугольника
        /// </summary>
        /// <param name="sides">Стороны треугольника - удовлетворяют неравенству треугольника</param>
        /// <exception cref="ArgumentException">Валидация значения сторон</exception>
        public Triangle(double[] sides)
        {
            GuardClauses.IsValidTriangle(sides);
            Array.Sort(sides);
            Sides = sides;
        }

        private bool CheckIsRight()
        {
            return MathExtensions.Equals(Sides[0] * Sides[0] + Sides[1] * Sides[1], Sides[2] * Sides[2]);
        }

        /// <summary>
        /// Вычиcление площади треугольника по формуле Герона
        /// </summary>
        protected override double CalculateArea()
        {
            var semiPerimeter = Sides.Sum() / 2;

            var firstSideCoefficient = semiPerimeter - Sides[0];
            var secondSideCoefficient = semiPerimeter - Sides[1];
            var thirdSideCoefficient = semiPerimeter - Sides[2];

            return Math.Sqrt(semiPerimeter * firstSideCoefficient * secondSideCoefficient * thirdSideCoefficient);
        }

        public override Shape Clone()
        {
            var sides = new double[Sides.Count];
            Array.Copy(Sides.ToArray(), sides, Sides.Count);
            return new Triangle(Sides.ToArray());
        }

        protected bool Equals(Triangle other)
        {
            return Sides.SequenceEqual(other.Sides);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Triangle)obj);
        }

        public override int GetHashCode()
        {
            return Sides != null ? Sides.GetHashCode() : 0;
        }
    }
}