using System;
using System.Collections.Generic;

namespace PW_06
{
    internal class Borrower
    {
        public string Name { get; set; }
        public List<LibraryItem> BorrowedItems { get; set; } = new List<LibraryItem>();
        public double Fine { get; set; } = 0;

        public Borrower(string name) => Name = name;        

        public void BorrowItem(LibraryItem item)
        {
            BorrowedItems.Add(item);
            Console.WriteLine($"{Name} взял(а) {item.Title}");
        }

        public void ReturnItem(LibraryItem item, int daysOverdue)
        {
            if (BorrowedItems.Remove(item))
            {
                Fine += CalculateFine(daysOverdue);
                Console.WriteLine($"{Name} вернул(а) {item.Title} {(daysOverdue > 0 ? $"( количество дней просрочки {daysOverdue})" : "")}");
            }
        }

        public double CalculateFine(int daysOverdue) { return daysOverdue * 10; } //10 руб за день.
    }
}
