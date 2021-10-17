namespace GeometricShapes.Shapes
{
    /// <summary>
    /// Общий класс - Фигура
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Площадь фигуры
        /// </summary>
        public double Area => CalculateArea();

        protected abstract double CalculateArea();

        public virtual Shape Clone()
        {
            return MemberwiseClone() as Shape;
        }
    }
}