using System;
using System.Collections.Generic;
using AreaCalculatorLibrary.ShapeInterfaces;

namespace AreaCalculatorLibrary.ShapeModels
{
    internal class Triangle : ITriangle
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        /// <summary>
        /// Проверка, что треугольник прямоугольный
        /// </summary>
        public bool IsRightTriangle
        {
            get
            {
                List<double> sides = new List<double> {SideA, SideB, SideC};
                sides.Sort();
                //Проверка осуществляется с помощью теоремы Пафагора
                return Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2) == 0;
            }
        }

        /// <summary>
        /// Создание объекта "Треугольник" по длинам 3-х его сторон. 
        /// </summary>
        /// <param name="sideA">Сторона треагольника a</param>
        /// <param name="sideB">Сторона треагольника b</param>
        /// <param name="sideC">Сторона треагольника c</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            CheckConstructorParametrs();
        }

        public double Perimeter => (SideA + SideB + SideC);

        public double Area
        {
            get
            {
                double p = Perimeter / 2;
                return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
            }
        }


        public void CheckConstructorParametrs()
        {
            const string ArgumentNotPositiveMessage = "Невозможно построить треугольник: одна из сторон меньше или равна 0";
            if (SideA <= 0)
                throw new ArgumentOutOfRangeException("sideA", SideA, ArgumentNotPositiveMessage);
            if (SideB <= 0)
                throw new ArgumentOutOfRangeException("sideB", SideB, ArgumentNotPositiveMessage);
            if (SideC <= 0)
                throw new ArgumentOutOfRangeException("sideC", SideC, ArgumentNotPositiveMessage);

            if (SideA + SideB <= SideC ||
                SideB + SideC <= SideA ||
                SideC + SideA <= SideB)
                throw new ArgumentException(
                    $"Невозможно построить треугольник с со сторонами a={SideA}, b={SideB}, c={SideC}");
        }
    }
}
