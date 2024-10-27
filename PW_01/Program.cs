using System;
using System.Diagnostics;

public class SortingAlgorithms
{
  
    // генерация случайного массива
    public static int[] GenerateArray(int size)
    {
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(-50_000 ,50_000 ); 
        }
        return array;
    }

    // пузырьковая сортировка
    public static (long, uint) BubbleSort(int[] array)
    {
        uint swaps = 0;
        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(array, j, j + 1);
                    swaps++;
                }
            }
        }

        sw.Stop();
        return (sw.ElapsedMilliseconds, swaps);
    }

    // сортировка вставкой
    public static (long, uint) InsertionSort(int[] array)
    {
        uint swaps = 0;
        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                swaps++;
                j--;
            }
            array[j + 1] = key;
        }

        sw.Stop();
        return (sw.ElapsedMilliseconds, swaps);
    }
      
    // сортировка выбором
    public static (long, uint) SelectionSort(int[] array)
    {
        uint swaps = 0;
        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                Swap(array, i, minIndex);
                swaps++;
            }
        }

        sw.Stop();
        return (sw.ElapsedMilliseconds, swaps);
    }

    // Функция для быстрой сортировки
    public static (long, uint) QuickSort(int[] array, int left, int right)
    {
        uint swaps = 0;
        Stopwatch sw = Stopwatch.StartNew();

        if (left < right)
        {
            int pivotIndex = Partition(array, left, right, ref swaps); 
            (long _, uint subSwaps) = QuickSort(array, left, pivotIndex - 1);
            swaps += subSwaps;
            (long _, uint subSwaps2) = QuickSort(array, pivotIndex + 1, right);
            swaps += subSwaps2;
        }
        sw.Stop();
        return (sw.ElapsedMilliseconds, swaps);
    }

    private static int Partition(int[] array, int left, int right, ref uint swaps)
    {
        int pivot = array[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                Swap(array, i, j);
                swaps++; 
            }
        }
        Swap(array, i + 1, right);
        swaps++; 
        return i + 1;
    }

    // сортировка слиянием
    public static (long, uint) MergeSort(int[] array)
    {
        uint swaps = 0;
        Stopwatch sw = Stopwatch.StartNew();
        MergeSort(array, 0, array.Length - 1, ref swaps);
        sw.Stop();
        return (sw.ElapsedMilliseconds, swaps);
    }

    private static void MergeSort(int[] array, int left, int right, ref uint swaps)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(array, left, mid, ref swaps);
            MergeSort(array, mid + 1, right, ref swaps);
            Merge(array, left, mid, right, ref swaps);
        }
    }

    private static void Merge(int[] array, int left, int mid, int right, ref uint swaps)
    {
        int[] leftArray = new int[mid - left + 1];
        int[] rightArray = new int[right - mid];

        Array.Copy(array, left, leftArray, 0, mid - left + 1);
        Array.Copy(array, mid + 1, rightArray, 0, right - mid);

        int i = 0, j = 0, k = left;

        while (i < leftArray.Length && j < rightArray.Length)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
                
            }
            else
            {
                array[k] = rightArray[j];
                j++;
                
            }
            k++;
            swaps++;
        }

        while (i < leftArray.Length)
        {
            array[k] = leftArray[i];
            i++;
            k++;
            swaps++;
        }

        while (j < rightArray.Length)
        {
            array[k] = rightArray[j];
            j++;
            k++;
            swaps++;
        }
    }

    // шейкерная сортировка
    public static (long, uint) ShakerSort(int[] array)
    {
        uint swaps = 0;
        Stopwatch sw = Stopwatch.StartNew();

        bool swapped = true;
        int start = 0;
        int end = array.Length - 1;

        while (swapped)
        {
            swapped = false;

            for (int i = start; i < end; i++)
            {
                if (array[i] > array[i + 1])
                {
                    Swap(array, i, i + 1);
                    swaps++;
                    swapped = true;
                }
            }

            end--;

            if (!swapped)
            {
                break;
            }

            swapped = false;

            for (int i = end; i > start; i--)
            {
                if (array[i] < array[i - 1])
                {
                    Swap(array, i, i - 1);
                    swaps++;
                    swapped = true;
                }
            }

            start++;
        }

        sw.Stop();
        return (sw.ElapsedMilliseconds, swaps);
    }

    // Функция для обмена элементов массива
    private static void Swap(int[] array, int i, int j)
    {
        (array[j], array[i]) = (array[i], array[j]);
    }


    public static void Main(string[] args)
    {
        int[] sizeArrey = { 1_000, 10_000, 100_000 }; // Размер массива
        int numRuns = 5; // Количество запусков

        foreach (int size in sizeArrey)
        {
            Console.WriteLine($"Размер массива: {size}");

            // Пузырьковая сортировка
            long bestBubbleTime = long.MaxValue;
            uint bestBubbleSwaps = int.MaxValue;
            for (int i = 0; i < numRuns; i++)
            {
                int[] array = GenerateArray(size);
                int[] bubbleArray = new int[size];
                Array.Copy(array, bubbleArray, size);
                (long time, uint swaps) = BubbleSort(bubbleArray);
                if (time < bestBubbleTime)
                {
                    bestBubbleTime = time;
                    bestBubbleSwaps = swaps;
                }
            }
            Console.WriteLine($"Лучшее время пузырьковой сортировки: {bestBubbleTime} мс, Перестановок: {bestBubbleSwaps}");
        

            // Сортировка вставкой
            long bestInsertionTime = long.MaxValue;
            uint bestInsertionSwaps = int.MaxValue;
            for (int i = 0; i < numRuns; i++)
            {
                int[] array = GenerateArray(size);
                int[] insertionArray = new int[size];
                Array.Copy(array, insertionArray, size);
                (long time, uint swaps) = InsertionSort(insertionArray);
                if (time < bestInsertionTime)
                {
                    bestInsertionTime = time;
                    bestInsertionSwaps = swaps;
                }
            }
            Console.WriteLine($"Лучшее время сортировки вставкой: {bestInsertionTime} мс, Перестановок: {bestInsertionSwaps}");

            // Сортировка выбором
            long bestSelectionTime = long.MaxValue;
            uint bestSelectionSwaps = int.MaxValue;
            for (int i = 0; i < numRuns; i++)
            {
                int[] array = GenerateArray(size);
                int[] selectionArray = new int[size];
                Array.Copy(array, selectionArray, size);
                (long time, uint swaps) = SelectionSort(selectionArray);
                bestSelectionTime = Math.Min(bestSelectionTime, time);
                bestSelectionSwaps = Math.Min(bestSelectionSwaps, swaps);
            }
            Console.WriteLine($"Лучшее время сортировки выбором: {bestSelectionTime} мс, Перестановок: {bestSelectionSwaps}");

            // Быстрая сортировка
            long bestQuickTime = long.MaxValue;
            uint bestQuickSwaps = int.MaxValue;
            for (int i = 0; i < numRuns; i++)
            {
                int[] array = GenerateArray(size);
                int[] quickArray = new int[size];
                Array.Copy(array, quickArray, size);
                (long time, uint swaps) = QuickSort(quickArray, 0, size - 1);
                bestQuickTime = Math.Min(bestQuickTime, time);
                bestQuickSwaps = Math.Min(bestQuickSwaps, swaps);
            }
            Console.WriteLine($"Лучшее время быстрой сортировки: {bestQuickTime} мс, Перестановок: {bestQuickSwaps}");

            // Сортировка слиянием
            long bestMergeTime = long.MaxValue;
            uint bestMergeSwaps = int.MaxValue;
            for (int i = 0; i < numRuns; i++)
            {
                int[] array = GenerateArray(size);
                int[] mergeArray = new int[size];
                Array.Copy(array, mergeArray, size);
                (long time, uint swaps) = MergeSort(mergeArray);
                bestMergeTime = Math.Min(bestMergeTime, time);
                bestMergeSwaps = Math.Min(bestMergeSwaps, swaps);
            }
            Console.WriteLine($"Лучшее время сортировки слиянием: {bestMergeTime} мс, Перестановок: {bestMergeSwaps}");

            // Шейкерная сортировка
            long bestShakerTime = long.MaxValue;
            uint bestShakerSwaps = int.MaxValue;
            for (int i = 0; i < numRuns; i++)
            {
                int[] array = GenerateArray(size);
                int[] shakerArray = new int[size];
                Array.Copy(array, shakerArray, size);
                (long time, uint swaps) = ShakerSort(shakerArray);
                bestShakerTime = Math.Min(bestShakerTime, time);
                bestShakerSwaps = Math.Min(bestShakerSwaps, swaps);
            }
            Console.WriteLine($"Лучшее время шейкерной сортировки: {bestShakerTime} мс, Перестановок: {bestShakerSwaps} \n");
        }
    }
}

 