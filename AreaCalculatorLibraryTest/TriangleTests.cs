using System;
using System.Collections.Generic;
using AreaCalculatorLibrary;
using AreaCalculatorLibrary.ShapeInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AreaCalculatorLibraryTest
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void Triangle_CheckSides_ShouldThrowArgumentOutOfRangeException()
        {
            double negativeValue = -2;
            double positiveValue = 2;
            
            CheckArgumentOutOfRangeException(negativeValue, positiveValue, positiveValue);
            CheckArgumentOutOfRangeException(positiveValue, negativeValue, positiveValue);
            CheckArgumentOutOfRangeException(positiveValue, positiveValue, negativeValue);
        }

        private void CheckArgumentOutOfRangeException(double sideA, double sideB, double sideC)
        {
            try
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => Shapes.Triangle(sideA, sideB, sideC));
            }
            catch (AssertFailedException e)
            {
                Assert.Fail($"Не получили ArgumentOutOfRangeException при вызове Shapes.Triangle({sideA}, {sideB}, {sideC}).", e);
            }
        }

        [TestMethod]
        public void Triangle_CheckSides_ShouldThrowArgumentException()
        {
            CheckArgumentException(9, 4, 4);
            CheckArgumentException(4, 9, 4);
            CheckArgumentException(4, 4, 9);
        }

        private void CheckArgumentException(double sideA, double sideB, double sideC)
        {
            try
            {
                Assert.ThrowsException<ArgumentException>(() => Shapes.Triangle(sideA, sideB, sideC));
            }
            catch (AssertFailedException e)
            {
                Assert.Fail($"Не получили ArgumentException при вызове Shapes.Triangle({sideA}, {sideB}, {sideC}).", e);
            }
        }


        [TestMethod]
        public void Triangle_CheckCalculationArea()
        {
            double sideA = 3;
            double sideB = 5;
            double sideC = 7;
            double perimeter = sideA + sideB + sideC;
            double p = perimeter / 2;
            double expected = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));

            ITriangle triangle = null;
            triangle = Shapes.Triangle(sideA, sideB, sideC);
            Assert.AreEqual(expected, triangle.Area, "Площадь треугольника вычисляется некорректно.");
        }

        [TestMethod]
        public void Triangle_CheckCalculationIsRightTriangle()
        {
            CheckCalculationIsRightTriangle(3, 5, 7);
            CheckCalculationIsRightTriangle(3, 6, 5);
        }

        private void CheckCalculationIsRightTriangle(double sideA, double sideB, double sideC)
        {
            List<double> sides = new List<double> { sideA, sideB, sideC };
            sides.Sort();
            bool expected = Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2) == 0;


            ITriangle triangle = Shapes.Triangle(sideA, sideB, sideC);
            Assert.AreEqual(expected, triangle.IsRightTriangle, "Проверка треугольника на прямой угол осуществляется некорректно");

        }
    }
}
