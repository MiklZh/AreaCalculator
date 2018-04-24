using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculatorLibrary
{
    public interface IShape
    {
        /// <summary>
        /// Вычисление периметра фигуры
        /// </summary>
        double Perimeter { get; }

        /// <summary>
        /// Вычисление площади фигуры
        /// </summary>
        double Area { get; }

        /// <summary>
        /// Метод для проверки на валидность параметров конструктора
        /// </summary>
        void CheckConstructorParametrs();
    }
}
