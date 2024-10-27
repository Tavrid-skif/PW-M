using System;

namespace PW_02
{
    internal class Program
    {
        // генерация случайного массива
        public static int[] GenerateArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(-999, 999);
            }
            return array;
        }

        // Линейный поиск
        static int LinearSearch(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    return i;
                }
            }
            return -1000;
        }

        // Бинарный поиск
        static int BinarySearch(int[] array, int target)
        {
            Array.Sort(array);            

            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (array[mid] == target)
                {
                    return array[mid];
                }

                else if (array[mid] < target)
                {
                    left = mid + 1;
                }

                else
                {
                    right = mid - 1;
                }
            }

            return -1000;
        }

       static void searchItem(int choice, int[] arr, int target )
        {
            int findTarget = -1000;

            findTarget = choice == 1 ? LinearSearch(arr, target) : BinarySearch(arr, target);
            Console.WriteLine(findTarget == -1000 ? $"\nДанные элемент {target} не найден" : $"\nЭлемент найден {findTarget}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] firstArr, secondArr, thirdArr;
            int[] sizeArr= { 100, 1_000, 10_000 };
            

            // Выбор метода поиска
            Console.WriteLine("Выберите метод поиска:");
            Console.WriteLine("1. Линейный поиск");
            Console.WriteLine("2. Бинарный поиск");
            Console.Write("\nВведите номер метода: ");
            int choice = int.Parse(Console.ReadLine());

            // Ввод элемента для поиска
            Console.WriteLine("\nВведите элемент для поиска от -999 до 999: ");
            int target = int.Parse(Console.ReadLine());

            // Выбор массива для поиска
            Console.WriteLine("\nВыберите массив для поиска:");
            Console.WriteLine("1. Массив из 100 элементов");
            Console.WriteLine("2. Массив из 1000 элементов");
            Console.WriteLine("3. Массив из 10000 элементов");
            Console.Write("\nВведите номер массива: ");
            int arrayChoice = int.Parse(Console.ReadLine()) - 1;

            switch (arrayChoice)
            {
                case 0:
                    firstArr = GenerateArray(sizeArr[arrayChoice]);
                    searchItem(choice, firstArr, target);
                    break;

                case 1:
                    secondArr = GenerateArray(sizeArr[arrayChoice]); 
                    searchItem(choice, secondArr, target);
                    break;

                case 2:
                    thirdArr = GenerateArray(sizeArr[arrayChoice]);
                    searchItem(choice, thirdArr, target);                     
                    break;

                default:
                    Console.WriteLine("Некорректный выбор массива.");
                    break;
            }
        }
    }
}
