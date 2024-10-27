using System;
using System.Collections.Generic;

namespace PW_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>()
            {
            new Book("Война и мир", "Лев Толстой", 1869, "Исторический роман"),
            new Book("Преступление и наказание", "Фёдор Достоевский", 1866, "Психологический роман"),
            new Book("Мастер и Маргарита", "Михаил Булгаков", 1966, "Фантастический роман"),
            new Book("Евгений Онегин", "Александр Пушкин", 1833, "Роман в стихах"),
            new Book("Мёртвые души", "Николай Гоголь", 1842, "Сатира"),
            new Book("Обломов", "Иван Гончаров", 1859, "Социальный роман"),
            new Book("Идиот", "Фёдор Достоевский", 1868, "Психологический роман"),
            new Book("Братья Карамазовы", "Фёдор Достоевский", 1880, "Философский роман"),
            new Book("Тихий Дон", "Михаил Шолохов", 1940, "Эпический роман"),
            new Book("1984", "Джордж Оруэлл", 1949, "Антиутопия"),
            new Book("Убить пересмешника", "Харпер Ли", 1960, "Социальный роман"),
            new Book("Над пропастью во ржи", "Джером Сэлинджер", 1951, "Роман взросления"),
            new Book("Лолита", "Владимир Набоков", 1955, "Психологический роман"),
            new Book("Портрет Дориана Грея", "Оскар Уайльд", 1890, "Готический роман"),
            new Book("Сто лет одиночества", "Габриэль Гарсиа Маркес", 1967, "Магический реализм")
            };

            List<Magazine> magazines = new List<Magazine>()
            {
            new Magazine("Scientific American", "Various", 2024, 1),
            new Magazine("National Geographic", "Various", 2024, 2),
            new Magazine("Popular Mechanics", "Various", 2024, 3),
            new Magazine("Vogue", "Various", 2024, 4),
            new Magazine("GQ", "Various", 2024, 5),
            new Magazine("Cosmopolitan", "Various", 2024, 6),
            new Magazine("Time", "Various", 2024, 7),
            new Magazine("Forbes", "Various", 2024, 8),
            new Magazine("The Economist", "Various", 2024, 9),
            new Magazine("Wired", "Various", 2024, 10)
            };

            List<Borrower> borrowers = new List<Borrower>()
            {
            new Borrower("Иван Иванов"),
            new Borrower("Петр Петров"),
            new Borrower("Сидор Сидоров"),
            new Borrower("Мария Иванова"),
            new Borrower("Ольга Петрова"),
            new Borrower("Анна Сидорова"),
            new Borrower("Дмитрий Иванов"),
            new Borrower("Сергей Петров"),
            new Borrower("Алексей Сидоров"),
            new Borrower("Елена Иванова")
            };

            Random random = new Random();
            foreach (var borrower in borrowers)
            {
                if (random.Next(0, 15) % 2 == 0)
                {
                    int bookIndex = random.Next(books.Count);
                    borrower.BorrowItem(books[bookIndex]);
                }
                else
                {
                    int magazineIndex = random.Next(magazines.Count);
                    borrower.BorrowItem(magazines[magazineIndex]);
                }

            }


            Console.WriteLine("\nИнформация о клиентах:");
            foreach (var borrower in borrowers)
            {
                Console.WriteLine($"\nКлиент: {borrower.Name}");
                Console.WriteLine("Взятые книги:");

                foreach (var item in borrower.BorrowedItems)
                {
                    Console.WriteLine($"- {item}");
                }
            }

            Console.WriteLine();

            foreach (var borrower in borrowers)
            {

                borrower.ReturnItem(borrower.BorrowedItems[0], random.Next(0, 5));

                if (borrower.Fine != 0)
                    Console.WriteLine($"Штраф: {borrower.Fine} руб\n");
                else
                    Console.WriteLine($"Книга еще на руках или вернули вовремя\n");
            }

            Console.WriteLine($"Добавить: \n1. Книги \n2. Жунраналы\n");

            if (int.TryParse(Console.ReadLine(), out int digit))
                if (digit == 1)
                {
                    Console.Write("\nВведите количество книг для добавления: ");
                    if (int.TryParse(Console.ReadLine(), out int numBooks))
                    {
                        for (int i = 0; i < numBooks; i++)
                        {
                            Console.Write($"\nНазвание книги {i + 1}: ");
                            string title = Console.ReadLine();

                            Console.Write($"Автор книги {i + 1}: ");
                            string author = Console.ReadLine();

                            Console.Write($"Жанр книги {i + 1}: ");
                            string genre = Console.ReadLine();

                            Console.Write($"Год издания книги {i + 1}: ");

                            if (int.TryParse(Console.ReadLine(), out int year))
                                books.Add(new Book(title, author, year, genre));

                            else
                                Console.WriteLine("Некорректный год издания. Книга не добавлена.");

                        }
                    }
                }

                else if (digit == 2)
                {
                    Console.Write("\nВведите количество журналов для добавления: ");
                    if (int.TryParse(Console.ReadLine(), out int numMagazine))
                    {
                        for (int i = 0; i < numMagazine; i++)
                        {
                            Console.Write($"\nНазвание Журнала {i + 1}: ");
                            string title = Console.ReadLine();

                            Console.Write($"Автор Журнала {i + 1}: ");
                            string author = Console.ReadLine();

                            Console.Write($"Год издания Журнала {i + 1}: ");

                            if (int.TryParse(Console.ReadLine(), out int year))
                            {
                                Console.Write($"Номер Журнала {i + 1}: ");
                                if (int.TryParse(Console.ReadLine(), out int IssueNumber))
                                    magazines.Add(new Magazine(title, author, year, IssueNumber));
                                else
                                    Console.WriteLine("Некорректный номер выпуска. Журнал не добавлен.");
                            }

                            else
                                Console.WriteLine("Некорректный год издания. Журнал не добавлен.");

                        }
                    }
                }

                else
                    Console.WriteLine("Не правилный выбор.");

                Console.WriteLine("\nСписко книг:");
                foreach (Book book in books)                    
                    Console.WriteLine(book.Title);

                Console.WriteLine("\nСписко журанлов:");
                foreach(Magazine magazine in magazines)
                    Console.WriteLine(magazine.Title);

                Console.ReadKey();
            
        }
    }
}
