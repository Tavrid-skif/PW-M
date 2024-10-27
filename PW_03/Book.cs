using System;

namespace PW_03
{
    internal class Book
    {
        private string title { get; }
        private string author { get; }
        private int yearPublished { get; }


        public Book() { }
        public Book(string title, string author, int yearPublished)
        {
            this.title = title;
            this.author = author;
            this.yearPublished = yearPublished;
        }

        public string GetTitle() { return title; }
        public string GetAuthor() { return author; }
        public int GetYearPublished() { return yearPublished; }

        public void DisplayInfo() => Console.WriteLine($"Книга - {GetTitle()};\nАвтор - {GetAuthor()};\nГод выпуска - {GetYearPublished()}\n");
        
    }
}
