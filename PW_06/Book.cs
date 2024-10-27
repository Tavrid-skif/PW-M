namespace PW_06
{
    internal class Book : LibraryItem
    {
        public string Genre { get; set; }

        public Book(string title, string author, int year, string genre) : base(title, author, year) => Genre = genre;

        public override string ToString() { return $"{base.ToString()}, Жанр: {Genre}"; }
    }
}
