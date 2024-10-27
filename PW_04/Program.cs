using System;

namespace PW_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radius = 6, recA = 7, recB = 16, triaA = 5, triaB = 12;

            Console.WriteLine($"Площадь круга с радиусом ({radius}): {Shape.CalculateArea(radius)}\n");
            Console.WriteLine($"Площадь прямоугольника со сторонами ({recA}, {recB}): {Shape.CalculateArea(recA, recB)}\n");
            Console.WriteLine($"Площадь прямоугольного треугольника ({triaA}, {triaB}): {Shape.CalculateArea(triaA, triaB, true)}"); 
            Console.WriteLine($"Площадь непрямоугольного треугольника ({triaA}, {triaB}, примерная третья сторона): {Shape.CalculateArea(triaA, triaB, false)}\n"); 
        }
    }
}
