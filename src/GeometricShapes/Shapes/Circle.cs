using System;

namespace GeometricShapes.Shapes
{
    /// <summary>
    /// Круг
    /// </summary>
    public class Circle : Shape
    {
        public double Radius { get; }
        
        /// <summary>
        /// Создание круга
        /// </summary>
        /// <param name="radius">Радиус круга - положительное число</param>
        /// <exception cref="ArgumentException">Валидация значения радиуса</exception>
        public Circle(double radius)
        {
            GuardClauses.IsValidCircle(radius);
            Radius = radius;
        }
        
        /// <summary>
        /// Вычиcление площади круга
        /// </summary>
        protected sealed override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        protected bool Equals(Circle other)
        {
            return Radius.Equals(other.Radius);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Circle)obj);
        }

        public override int GetHashCode()
        {
            return Radius.GetHashCode();
        }
    }
}