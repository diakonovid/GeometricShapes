using System;
using FluentAssertions;
using GeometricShapes.Extensions;
using GeometricShapes.Shapes;
using Xunit;

namespace GeometricShapes.Tests
{
    public class CircleTest
    {
        [Theory]
        [InlineData(double.PositiveInfinity)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(double.MinValue)]
        [InlineData(double.NegativeInfinity)]
        public void Create_IncorrectRadius_ReturnArgumentException(double radius)
        {
            Action act = () => new Circle(radius);
            act.Should().Throw<ArgumentException>()
                .WithParameterName(nameof(radius))
                .WithMessage("Радиус круга не соответствует установленным ограничениям (Parameter 'radius')");
        }

        [Theory]
        [InlineData(double.MaxValue, double.PositiveInfinity)]
        [InlineData(1, 3.1415926535897931)]
        [InlineData(125.49, 49472.984608801395)]
        public void Create_CorrectRadius_CalculateArea(double radius, double expectedArea)
        {
            var circle = new Circle(radius);
            MathExtensions.Equals(circle.Area, expectedArea).Should().BeTrue();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(125.49)]
        public void Clone_CorrectRadius_Equal(double radius)
        {
            var circle = new Circle(radius);
            var newCircle = circle.Clone() as Circle;

            ReferenceEquals(circle, newCircle).Should().BeFalse();
            circle.Equals(newCircle).Should().BeTrue();
        }
    }
}