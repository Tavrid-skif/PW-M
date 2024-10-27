using System;

namespace PW_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите инструмент:");
            Console.WriteLine("1. Фортепиано");
            Console.WriteLine("2. Гитара\n");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":                   
                    (new Pino()).Play();

                    break;
                case "2":
                    (new Guitar()).Play();

                    break;
                default:

                    Console.WriteLine("\nНеверный выбор.");
                    break;
            }

            Console.ReadLine();
        }
    }
}
