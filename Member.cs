//; کد های Member.cs
using System.Collections.Generic;
namespace FirstProjectBook
{
    public class Member
    {
        public int Id { get; }

        public string Name { get; set; } = "";

        public Member(int id, string name)
        {
            if (id == 0)
            {
                throw new ArgumentOutOfRangeException(
            nameof(id),
            "Member ID must be greater than zero."
        );
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
            "Member name cannot be empty."
        );
            }
            Id = id;
            Name = name; 
    }
            private readonly List<IBorrowable> borrowedBooks = new();
        public IReadOnlyList<IBorrowable> BorrowedBooks => borrowedBooks;


        public bool BorrowBook(IBorrowable item)
        {
            if (!item.Borrow())
            {
                return false;
            }

            borrowedBooks.Add(item);

            return true;
        }
        public bool ReturnBook(IBorrowable item)
        {
            if (!borrowedBooks.Contains(item))
            {
                return false;
            }

            item.ReturnBook();

            borrowedBooks.Remove(item);

            return true;
        }
    }
}