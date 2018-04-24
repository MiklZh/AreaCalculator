using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AreaCalculatorLibrary.ShapeInterfaces;
using AreaCalculatorLibrary.ShapeModels;

namespace AreaCalculatorLibrary
{
    public class Shapes
    {
        public static ICircle Circle(double radius)
        {
            return new Circle(radius);
        }

        public static ITriangle Triangle(double sideA, double sideB, double sideC)
        {
            return new Triangle(sideA, sideB, sideC);
        }
    }
}
