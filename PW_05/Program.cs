using System;

namespace PW_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radius = 6, length = 7, width = 16, height = 5;

            Console.WriteLine($"Объем шара с радиусом ({radius}): {VolumeCalculator.CalculateVolume(radius)}\n");
            Console.WriteLine($"Площадь прямоугольного параллелепипеда со сторонами ({length}, {width}, {height}): {VolumeCalculator.CalculateVolume(length, width, height)}\n");
            Console.WriteLine($"Объем цилиндра с радиусом и высотой ({radius}, {height}): {VolumeCalculator.CalculateVolume(radius, height)}");
           
        }
    }
}
