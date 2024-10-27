using System;
using System.Collections.Generic;

namespace PW_10
{
    internal class UniversalCollection<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item) => items.Add(item);        

        public void Remove(T item) => items.Remove(item);        

        public T Get(int index)
        {
            if (index >= 0 && index < items.Count)            
                return items[index];
            
            else            
                throw new IndexOutOfRangeException("\nИндекс вне диапазона.");
            
        }

        public void PrintCollection()
        {
            Console.WriteLine("\nЭлементы коллекции:");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public int Count { get { return items.Count; } }

       
    }
}
