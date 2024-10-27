using System;
using System.Collections.Generic;

namespace PW_09
{
    internal class Program
    {
        static void PrintStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        struct Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public double GPA { get; set; }

            public override string ToString() { return $"ID: {Id}, Имя: {Name}, Возраст: {Age}, Средний бал: {GPA}"; }
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            
            students.Add(new Student { Id = 1, Name = "Иван Иванов", Age = 19, GPA = 3.8 });
            students.Add(new Student { Id = 2, Name = "Мария Петрова", Age = 20, GPA = 3.5 });
            students.Add(new Student { Id = 3, Name = "Сергей Сидоров", Age = 21, GPA = 3.2 });
            students.Add(new Student { Id = 4, Name = "Анна Кузнецова", Age = 18, GPA = 4.0 });
                        
            Console.Write("Введите количество студентов (дополнительно): ");
            if (int.TryParse(Console.ReadLine(), out int numStudents))
            {
                for (int i = 0 + 1; i <= numStudents; i++) 
                {
                    Console.Write($"\nВведите данные для студента {i}:\n");    

                    Console.Write("ФИО: ");
                    string name = Console.ReadLine();

                    Console.Write("Возраст: ");

                    if (int.TryParse(Console.ReadLine(), out int age))
                    {
                        Console.Write("Средний балл (GPA): ");
                        if (double.TryParse(Console.ReadLine(), out double gpa))
                        {
                            int id = students.Count + 1;
                            students.Add(new Student { Id = id, Name = name, Age = age, GPA = gpa });
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат среднего балла.\n");
                            i--;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат возраста.\n");
                        i--; 
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный формат количества студентов.\n");
                return;
            }

            Console.WriteLine("\nНеотсортированный список студентов:");
            PrintStudents(students);

            students.Sort((s1, s2) => string.Compare(s1.Name, s2.Name)); 
            Console.WriteLine("\nОтсортированный список студентов (по имени):");
            PrintStudents(students);
                        
            students.Sort((s1, s2) => s1.Age.CompareTo(s2.Age)); 
            Console.WriteLine("\nОтсортированный список студентов (по возрасту):");
            PrintStudents(students);
                       
            students.Sort((s1, s2) => s2.GPA.CompareTo(s1.GPA)); 
            Console.WriteLine("\nОтсортированный список студентов (по среднему баллу):");
            PrintStudents(students);

            Console.ReadLine();
        }
    }
}
