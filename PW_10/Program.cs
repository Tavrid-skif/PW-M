using System;

namespace PW_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите тип данных (int или string): ");
            string dataType = Console.ReadLine().ToLower();

            UniversalCollection<int> collectionInt = new UniversalCollection<int>();
            UniversalCollection<string> collectionStr = new UniversalCollection<string>();

            if (dataType == "int")
            {
                collectionInt = new UniversalCollection<int>();
            }
            else if (dataType == "string")
            {
                collectionStr = new UniversalCollection<string>();
            }
            else
            {
                Console.WriteLine("Неверный тип данных.");
                return;
            }


            Console.Write("Введите количество элементов для добавления: ");
            if (int.TryParse(Console.ReadLine(), out int numElements))
            {
                for (int i = 0; i < numElements; i++)
                {
                    Console.Write($"Введите элемент {i + 1}: ");
                    string input = Console.ReadLine();

                    try
                    {
                        if (dataType == "int")
                        {
                            collectionInt.Add(int.Parse(input));
                        }
                        else
                        {
                            collectionStr.Add(input);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nНеверный формат ввода. Попробуйте ещё раз.");
                        i--; 
                    }
                }
            }
            else
            {
                Console.WriteLine("\nНеверное количество элементов.");
                return;
            }

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Вывести все элементы");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Получить элемент по индексу");
                Console.WriteLine("4. Выйти");

                Console.Write("\nВаш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (dataType == "int")
                        {
                            collectionInt.PrintCollection();
                        }
                        else
                        {
                            collectionStr.PrintCollection();
                        }                       
                        
                        break;
                    case "2":
                        Console.Write("\nВведите элемент для удаления: ");
                        string elementToRemove = Console.ReadLine();
                        try
                        {
                            if (dataType == "int")
                            {
                                collectionInt.Remove(int.Parse(elementToRemove));
                            }
                            else
                            {
                                collectionStr.Remove(elementToRemove);
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\nНеверный формат ввода.");
                        }
                        break;
                    case "3":
                        Console.Write("\nВведите индекс элемента: ");
                        if (int.TryParse(Console.ReadLine(), out int index))
                        {
                            try
                            {

                                if (dataType == "int")
                                {
                                    Console.WriteLine($"\nЭлемент по индексу {index}: {collectionInt.Get(index)}");
                                }
                                else
                                {
                                    Console.WriteLine($"\nЭлемент по индексу {index}: {collectionStr.Get(index)}");
                                }
                               
                            }
                            catch (IndexOutOfRangeException ex)
                            {
                                Console.WriteLine($"\nОшибка: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nНеверный формат индекса.");
                        }
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("\nНеверный выбор.");
                        break;
                }
            }
        }
    }
}
  
