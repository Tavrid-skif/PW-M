using System;

namespace PW_05
{
    internal class VolumeCalculator
    {

        public static double CalculateVolume(double radius) { return (4 / 3) * Math.PI * Math.Pow(radius, 3); }

        public static double CalculateVolume(double length, double width, double height) { return length * width * height; }

        public static double CalculateVolume(double radius, double height) { return Math.PI * Math.Pow(radius, 2) * height; }
    }
}
