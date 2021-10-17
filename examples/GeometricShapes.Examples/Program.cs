using System;
using System.Collections.Generic;
using GeometricShapes.Shapes;

namespace GeometricShapes.Examples
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var shapes = new List<Shape>();
            shapes.Add(new Circle(5));
            shapes.Add(new Triangle(new[] { 3d, 5d, 4d }));

            foreach (var shape in shapes)
                Console.WriteLine("Shape {0} with area {1}", shape.GetType().Name, shape.Area);
        }
    }
}