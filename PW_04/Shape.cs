using System;

namespace PW_04
{
    internal class Shape
    {
        static public double CalculateArea(double radius) { return Math.PI * Math.Pow(radius, 2); }
        static public double CalculateArea(double width, double height) { return width * height; }
        static public double CalculateArea(double baseLength, double height, bool isRightTriangle) { return isRightTriangle?0.5*baseLength*height: HeronArea(baseLength,height, Math.Sqrt(baseLength * baseLength + height * height)); }

        static private double HeronArea(double a, double b, double c) {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

    }
}
