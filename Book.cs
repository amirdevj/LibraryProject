
namespace FirstProjectBook
{
    public class Book : LibraryItem, IBorrowable
    {
        public string Author { get; set; } = "";

        public bool IsAvailable { get; private set; }

        public Book(
            int id,
            string title,
            string author,
            bool isAvailable)
            : base(id, title)
        {
            Author = author;
            IsAvailable = isAvailable;
        }

        public bool Borrow()
        {
            if (!IsAvailable)
            {
                return false;
            }

            IsAvailable = false;
            return true;
        }

        public void ReturnBook()
        {
            IsAvailable = true;
        }

        public override string GetInfo()
        {
            string status = IsAvailable ? "Avaliable" : "Borrowed";
            return $"ID: {Id} | Title: {Title} | Author: {Author} | Status: {status}";
        }
    }
}
