using System;
using System.Text.RegularExpressions;


namespace PW_11
{
    internal class Program
    {
        static bool IsValidIP(string ip) { return Regex.IsMatch(ip, @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$"); }

        static void Main(string[] args)
        {
            // Задание 1: Только буквы и цифры
            string task1Str1 = "abc123XYZ";
            string task1str2 = "abc-123";
            Console.WriteLine($"Строка '{task1Str1}' содержит только буквы и цифры: {Regex.IsMatch(task1Str1, @"^[a-zA-Z0-9]+$")}"); // True
            Console.WriteLine($"Строка '{task1str2}' содержит только буквы и цифры: {Regex.IsMatch(task1str2, @"^[a-zA-Z0-9]+$")}"); // False

            // Задание 2: Извлечение дат dd.mm.yyyy
            string textWithDates = "Сегодня 24.10.2024, а завтра 25.10.2024.  Дата 01.01.1970 важна.";
            MatchCollection dates = Regex.Matches(textWithDates, @"\d{2}\.\d{2}\.\d{4}");
            Console.WriteLine("\nДаты:");

            foreach (Match date in dates)
            {
                Console.WriteLine(date.Value);
            }

            // Задание 3: Проверка email
            string email1 = "test@example.com";
            string email2 = "invalid-email";
            Console.WriteLine($"\nEmail '{email1}' правильный: {Regex.IsMatch(email1, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")}"); // True 
            Console.WriteLine($"Email '{email2}' правильный: {Regex.IsMatch(email2, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")}"); // False

            // Задание 4: Замена чисел на NUMBER
            string task4str1 = "123 abc 456 def 789";
            string replacedStr = Regex.Replace(task4str1, @"\d+", "NUMBER");
            Console.WriteLine($"\nЗаменённая строка: {replacedStr}");

            // Задание 5: Извлечение URL 
            string textWithUrls = "Посетите https://www.example.com и http://another-site.net";
            MatchCollection urls = Regex.Matches(textWithUrls, @"https?:\/\/[^\s]+");
            Console.WriteLine("\nСсылки:");

            foreach (Match url in urls)
            {
                Console.WriteLine(url.Value);
            }

            // Задание 6: Хотя бы одна заглавная буква
            string task6Str1 = "hello world";
            string task6Str2 = "Hello World";
            Console.WriteLine($"\nСтрока '{task6Str1}' содержит заглавную букву: {Regex.IsMatch(task6Str1, "[A-Z]")}"); // False
            Console.WriteLine($"Строка '{task6Str2}' содержит заглавную букву: {Regex.IsMatch(task6Str2, "[A-Z]")}"); // True

            // Задание 7: Извлечение номеров телефонов +X-XXX-XXXXXXX
            string textWithPhones = "Мой номер +7-123-4567890, а его +1-222-333-33-33";
            MatchCollection phones = Regex.Matches(textWithPhones, @"\+\d{1}-\d{3}-\d{7}");
            Console.WriteLine("\nНомера телефонов:");

            foreach (Match phone in phones)
            {
                Console.WriteLine(phone.Value);
            }

            // Задание 8: Хотя бы одно слово с заглавной буквой
            string task8Str1 = "hello world";
            string task8Str2 = "Hello world";
            string task8Str3 = "hello World"; 
            string task8Str4 = "Hello World!"; 

            Console.WriteLine($"\nСтрока '{task8Str1}' содержит слово с заглавной буквой: {Regex.IsMatch(task8Str1, @"\b[A-Z][a-z]+\b")}"); // False
            Console.WriteLine($"Строка '{task8Str2}' содержит слово с заглавной буквой: {Regex.IsMatch(task8Str2, @"\b[A-Z][a-z]+\b")}"); // True
            Console.WriteLine($"Строка '{task8Str3}' содержит слово с заглавной буквой: {Regex.IsMatch(task8Str3, @"\b[A-Z][a-z]+\b")}"); // True
            Console.WriteLine($"Строка '{task8Str4}' содержит слово с заглавной буквой: {Regex.IsMatch(task8Str4, @"\b[A-Z][a-z]+\b")}"); // True

            // Задание 9: Замена "apple" и "orange" на "fruit"

            string task9Str1 = "I like apple and orange.  APPLE is also a fruit.";
            string replacedStr9 = Regex.Replace(task9Str1, @"\b(apple|orange)\b", "fruit", RegexOptions.IgnoreCase); //IgnoreCase для учета регистра
            Console.WriteLine($"\nЗаменённая строка: {replacedStr9}");

            // Задание 10: Проверка IP-адреса

            string ip1 = "192.168.1.1";
            string ip2 = "256.256.256.256"; 
            string ip3 = "192.168.1.1.1"; 
            string ip4 = "192.168.1"; 


            Console.WriteLine($"\nIP '{ip1}' правильный: {IsValidIP(ip1)}"); // True
            Console.WriteLine($"IP '{ip2}' правильный: {IsValidIP(ip2)}"); // False
            Console.WriteLine($"IP '{ip3}' правильный: {IsValidIP(ip3)}"); // False
            Console.WriteLine($"IP '{ip4}' правильный: {IsValidIP(ip4)}"); // False

            Console.ReadLine();
        }
    }
}
