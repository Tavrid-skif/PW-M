using System;

namespace PW_06
{
    internal class LibraryItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public LibraryItem(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public override string ToString() { return $"Название: {Title}, Автор: {Author}, Год: {Year}"; }
    }
}
