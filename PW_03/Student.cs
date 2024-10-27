using System;

namespace PW_03
{
    internal class Student
    {
        private string name;
        private int age;
        private string major;

        public Student() { }
        public Student(string name, int age, string major)
        {
            this.name = name;
            this.age = age;
            this.major = major;
        }

        public string GetName() { return name; }
        public int GetAge() { return age; }
        public string GetMajor() { return major; }

        public void Study() => Console.WriteLine($"Студент учиться.\n");
        public void DisplayInfo() => Console.WriteLine($"Студент - {GetName()};\nВозраст - {GetAge()};\nСпециальность - {GetMajor()}");
    }
}
