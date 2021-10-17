using System;
using System.Collections.Generic;
using FluentAssertions;
using GeometricShapes.Shapes;
using Xunit;

namespace GeometricShapes.Tests
{
    public class TriangleTest
    {
        public static IEnumerable<object[]> IncorrectCountData =>
            new List<object[]>
            {
                new object[] { },
                new object[] { 1d },
                new object[] { 1d, 2d },
                new object[] { 1d, 2d, 3d, 4d }
            };

        public static IEnumerable<object[]> IncorrectRangeData =>
            new List<object[]>
            {
                new object[] { 1d, 2d, 3d },
                new object[] { -3d, 4d, 5d },
                new object[] { 3d, -4d, 5d },
                new object[] { 3d, 4d, -5d },
                new object[] { -3d, -4d, -5d }
            };

        public static IEnumerable<object[]> CorrectRangeData =>
            new List<object[]>
            {
                new object[] { 6d, 3d, 4d, 5d },
                new object[] { 5.332682251925386d, 6d, 4d, 3d }
            };

        [Theory]
        [MemberData(nameof(IncorrectCountData))]
        public void Create_IncorrectSidesCount_ReturnArgumentException(params double[] sides)
        {
            Action act = () => new Triangle(sides);
            act.Should().Throw<ArgumentException>()
                .WithParameterName(nameof(sides))
                .WithMessage("Количество сторон треугольника не соответствует числу 3 (Parameter 'sides')");
        }

        [Theory]
        [MemberData(nameof(IncorrectRangeData))]
        public void Create_IncorrectSides_ReturnArgumentException(params double[] sides)
        {
            Action act = () => new Triangle(sides);
            act.Should().Throw<ArgumentException>()
                .WithParameterName(nameof(sides))
                .WithMessage("Треугольника с заданными сторонами не существует (Parameter 'sides')");
        }

        [Theory]
        [MemberData(nameof(CorrectRangeData))]
        public void Create_CorrectSides_CalculateArea(double expectedArea, params double[] sides)
        {
            var triangle = new Triangle(sides);
            triangle.Area.Should().Be(expectedArea);
        }

        [Theory]
        [InlineData(3d, 4d, 5d)]
        public void Clone_CorrectSides_Equal(params double[] sides)
        {
            var triangle = new Triangle(sides);
            var newTriangle = triangle.Clone() as Triangle;

            ReferenceEquals(triangle, newTriangle).Should().BeFalse();
            triangle.Equals(newTriangle).Should().BeTrue();
        }

        [Theory]
        [InlineData(3d, 4d, 5d)]
        public void CheckIsRight_CorrectSides_True(params double[] sides)
        {
            var triangle = new Triangle(sides);
            triangle.IsRight.Should().BeTrue();
        }

        [Theory]
        [InlineData(3d, 6d, 4d)]
        public void CheckIsRight_IncorrectSides_False(params double[] sides)
        {
            var triangle = new Triangle(sides);
            triangle.IsRight.Should().BeFalse();
        }

        [Theory]
        [InlineData(3d, 5d, 4d)]
        public void CreateRight_CorrectSides_CalculateArea(params double[] sides)
        {
            var triangle = new RightTriangle(sides);
            triangle.IsRight.Should().BeTrue();
        }
    }
}