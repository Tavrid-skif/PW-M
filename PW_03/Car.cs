using System;

namespace PW_03
{
    internal class Car
    {
        private string make;
        private string model;
        private int year;

        public Car() { }
        public Car(string make, string model, int year)
        {
            this.make = make;
            this.model = model;
            this.year = year;
        }

        public string GetMake() { return make; }
        public string GetModel() { return model; }
        public int GetYear() { return year; }

        public void StartEngine() => Console.WriteLine($"Двигатель запущен.\n");
        public void DisplayInfo() => Console.WriteLine($"Марка - {GetMake()};\nМодель - {GetModel()};\nГод выпуска - {GetYear()}");
    }
}
