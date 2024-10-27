namespace PW_06
{
    internal class Magazine : LibraryItem
    {
        public int IssueNumber { get; set; }

        public Magazine(string title, string author, int year, int issueNumber) : base(title, author, year) => IssueNumber = issueNumber;

        public override string ToString() { return $"{base.ToString()}, Номер выпуска: {IssueNumber}"; }
    }
}

