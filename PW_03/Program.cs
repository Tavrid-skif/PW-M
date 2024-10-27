namespace PW_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Гарри Поттер и философский камень", "Джоан Роулинг", 1997);
            book.DisplayInfo();

            Student student = new Student("Влад", 25, "Экономика");            
            student.DisplayInfo();
            student.Study();

            Car car = new Car("Toyota", "Supra", 2011);            
            car.DisplayInfo();
            car.StartEngine();
        }
    }
}
