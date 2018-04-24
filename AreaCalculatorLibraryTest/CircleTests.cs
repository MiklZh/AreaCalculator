using System;
using AreaCalculatorLibrary;
using AreaCalculatorLibrary.ShapeInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AreaCalculatorLibraryTest
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void Circle_CheckRadius_ShouldThrowArgumentException()
        {
            double radius = -5;
            try
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => Shapes.Circle(radius));                
            }
            catch (AssertFailedException e)
            {
                Assert.Fail($"Не получили ArgumentOutOfRangeException при вызове Shapes.Circle({radius}).", e);
            }           
        }

        [TestMethod]
        public void Circle_CheckCalculationArea()
        {
            double radius = 5;
            double expected = Math.PI * Math.Pow(radius, 2);

            ICircle circle = Shapes.Circle(radius);               
            Assert.AreEqual(expected, circle.Area, "Площадь круга вычисляется некорректно");
        }
    }
}
