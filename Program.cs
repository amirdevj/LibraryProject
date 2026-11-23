//کد های Program.cs
using System;
using System.Linq.Expressions;
using System.Transactions;

namespace FirstProjectBook
{
    public class Program
    {
        ///.////////////.
        
        static int ReadPositiveInt(string message)
        {
            while (true)
            {
                Console.WriteLine(message);

                string? input = Console.ReadLine();

                if(!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Please enter a valid number");
                    continue;
                }
                if(number <= 0)
                {
                    Console.WriteLine("Number must be greater than zero.");
                    continue;
                }
                return number;
            }
        }
        ///.////
        

        static void Main(string[] args)
        {

            Library library = new Library();

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n===== Library Management System =====");

                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Member");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. Show Library Items");
                Console.WriteLine("6. Show Library Members");
                Console.WriteLine("7. Search Book");
                Console.WriteLine("8. Search Book By Title");
                Console.WriteLine("9. Show Borrowed Books");
                Console.WriteLine("0. Exit");

                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            try
                            {
                                int id = ReadPositiveInt("Enter book ID: ");

                                Console.WriteLine("Enter book title: ");
                                string title = Console.ReadLine() ?? "";

                                Console.WriteLine("Enter author name: ");
                                string author = Console.ReadLine() ?? "";

                                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
                                {
                                    Console.WriteLine("Title and author cannot be empty.");
                                    break;
                                }
                                Book book = new Book(
                                    id,
                                    title,
                                    author,
                                    true
                                    );
                                library.AddItem(book);

                                Console.WriteLine("Book added successfully!");

                            }
                            catch (DuplicateLibraryItemException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            break;
                        }



                    case "2":
                        {
                            try
                            {
                                int id = ReadPositiveInt("Enter member ID: ");

                                Console.Write("Enter member name: ");
                                string name = Console.ReadLine() ?? "";

                                if (string.IsNullOrWhiteSpace(name))
                                {
                                    Console.WriteLine("Member name cannot be empty.");
                                    break;
                                }

                                Member member = new Member(id, name);
                                
                                library.AddMember(member);

                                Console.WriteLine("Member added successfully!");
                            }
                            catch (DuplicateMemberException ex)
                            {
                                Console.WriteLine("Duplicate Member: " + ex.Message);
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine("Invalid ID: " + ex.Message);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine("Invalid Argument: " + ex.Message);
                            }

                            break;
                        }


                    case "3":
                        {
                            try
                            {
                                int memberId = ReadPositiveInt("Enter member ID: ");
                                int bookId = ReadPositiveInt("Enter book ID: ");

                                bool result = library.BorrowBook(memberId, bookId);

                                if (result)
                                {
                                    Console.WriteLine("Book borrowed successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Book could not be borrowed!");
                                }
                            }
                            catch (MemberNotFoundException ex)
                            {
                                Console.WriteLine("Member Error: " + ex.Message);
                            }
                            catch (LibraryItemNotFoundException ex)
                            {
                                Console.WriteLine("Book Error: " + ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Unexpected Error: " + ex.Message);
                            }
                            break;
                        }

                    case "4":
                        {
                            try
                            {
                                int memberId = ReadPositiveInt("Enter member ID: ");
                                int bookId = ReadPositiveInt("Enter book ID: ");
                                bool result = library.ReturnBook(memberId, bookId);

                                if (result)
                                {
                                    Console.WriteLine("Book returned successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Book could not be returned!");
                                }
                            }

                            catch (MemberNotFoundException ex)
                            {
                                Console.WriteLine("Member Error: " + ex.Message);
                            }
                            catch (LibraryItemNotFoundException ex)
                            {
                                Console.WriteLine("Book Error: " + ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Unexpected Error: " + ex.Message);
                            }
                            break;
                        }

                    case "5":
                        {
                            if(library.Books.Count == 0)
                            {
                                Console.WriteLine("Libray is empty.");
                                break;
                            }
                            foreach(LibraryItem item in library.Books)
                            {
                                Console.WriteLine(item.GetInfo());
                            }
                            break;
                        }

                    case "6":
                        {
                            if(library.Members.Count == 0)
                            {
                                Console.WriteLine("No Members registered.");
                                break;
                            }
                            Console.WriteLine("Library Members:");

                            foreach(Member member in library.Members)
                            {
                                Console.WriteLine($"ID: {member.Id} | Name: {member.Name} | Borrowed Item:" +
                                    $"{member.BorrowedBooks.Count}");
                            }
                            break;
                        }

                    case "7":
                        {
                            int bookId = ReadPositiveInt("Enter book ID: ");
                            LibraryItem? selectedItem = library.FindItemById(bookId);

                            if(selectedItem == null)
                            {
                                Console.WriteLine("Book not fount!");
                            }
                            else
                            {
                                Console.WriteLine(selectedItem.GetInfo());
                            }
                            break;
                        }

                    case "8":
                        {
                            try
                            {
                                Console.Write("Enter book title: ");

                                string title = Console.ReadLine() ?? "";

                                IReadOnlyList<LibraryItem> foundItems =
                                    library.FindItemsByTitle(title);

                                if (foundItems.Count == 0)
                                {
                                    Console.WriteLine("No books found!");
                                    break;
                                }

                                foreach (LibraryItem book in foundItems)
                                {
                                    Console.WriteLine(book.GetInfo());
                                }
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine("Search Error: " + ex.Message);
                            }

                            break;
                        }

                    case "9":
                        {
                            if (library.Members.Count == 0)
                            {
                                Console.WriteLine("No members registered.");
                                break;
                            }

                            foreach (Member member in library.Members)
                            {
                                Console.WriteLine(
                                    $"\nMember: {member.Name} | ID: {member.Id}"
                                );

                                if (member.BorrowedBooks.Count == 0)
                                {
                                    Console.WriteLine("No borrowed books.");
                                    continue;
                                }

                                foreach (IBorrowable borrowedItem in member.BorrowedBooks)
                                {
                                    if (borrowedItem is LibraryItem libraryItem)
                                    {
                                        Console.WriteLine(libraryItem.GetInfo());
                                    }
                                }
                            }

                            break;
                        }




                    case "0":   
                        isRunning = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }

        }

    }
}

