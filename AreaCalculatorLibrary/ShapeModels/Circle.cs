using System;
using AreaCalculatorLibrary.ShapeInterfaces;

namespace AreaCalculatorLibrary.ShapeModels
{
    internal class Circle : ICircle
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
            CheckConstructorParametrs();
        }

        public double Perimeter => 2 * Math.PI * Radius;

        public double Area => Math.PI * Math.Pow(Radius, 2);

        public void CheckConstructorParametrs()
        {
            if (Radius <= 0)
                throw new ArgumentOutOfRangeException("radius", Radius, "Невозможно построить круг: радиус меньше или равен 0");
        }
    }
}
