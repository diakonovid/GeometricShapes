namespace GeometricShapes.Shapes
{
    /// <summary>
    /// Прямоугольный треугольник
    /// </summary>
    public class RightTriangle : Triangle
    {
        /// <summary>
        /// Создание прямоугольного треугольника
        /// </summary>
        /// <param name="sides">Стороны треугольника - удовлетворяют неравенству треугольника</param>
        /// <exception cref="ArgumentException">Валидация значения сторон</exception>
        public RightTriangle(params double[] sides) : base(sides)
        {
            GuardClauses.IsValidRightTriangle(IsRight);
        }

        /// <summary>
        /// Вычиcление площади прямоугольного треугольника
        /// </summary>
        protected sealed override double CalculateArea()
        {
            return Sides[0] * Sides[1] / 2;
        }
    }
}