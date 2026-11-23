
using System;
using System.Collections.Generic;
using System.Data;

namespace FirstProjectBook
{
    public class Library
    {
        private readonly List<LibraryItem> books = new();

        private readonly List<Member> members = new();

        public IReadOnlyList<LibraryItem> Books => books;

        public IReadOnlyList<Member> Members => members;

        public void AddItem(LibraryItem item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            foreach (LibraryItem existingItem in books)
            {
                if (existingItem.Id == item.Id)
                {
                    throw new DuplicateLibraryItemException(
                        $"Item with ID {item.Id} already exists!"
                    );
                }
            }

            books.Add(item);
        }

        ///./////////////////////////

        public bool AddMember(Member member)
        {
            if (member is null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            foreach (Member existingMember in members)
            {
                if (existingMember.Id == member.Id)
                {
                    throw new DuplicateMemberException(
                         $"Member with ID {member.Id} already exists!"
                        );
                }
            }

            members.Add(member);

            return true;
        }
        ///.///
        public LibraryItem? FindItemById(int bookId)
        {
            foreach (LibraryItem book in books)
            {
                if (book.Id == bookId)
                {
                    return book;
                }
            }

            return null;
        }
        //./////
        public IReadOnlyList<LibraryItem> FindItemsByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty.");
            }
            List<LibraryItem> foundItems = new();

            foreach(LibraryItem book in books)
            {
                if(book.Title.Contains(
                    title, StringComparison.OrdinalIgnoreCase))
                {
                    foundItems.Add(book);
                }
            }
            return foundItems;
        }

        //        - BorrowBook برای امانت دادن کتاب
        //- ReturnBook برای پس گرفتن کتاب


        public bool BorrowBook(int memberId, int bookId)
        {
            Member? selectedMember = null;
            LibraryItem? selectedItem = null;

            foreach (Member member in members)
            {
                if (member.Id == memberId)
                {
                    selectedMember = member;
                    break;
                }
            }

            foreach (LibraryItem item in books)
            {
                if (item.Id == bookId)
                {
                    selectedItem = item;
                    break;
                }
            }

            if (selectedMember == null)
            {
                throw new MemberNotFoundException(
                    $"Member with ID {memberId} was not found."
                );
            }

            if (selectedItem == null)
            {
                throw new LibraryItemNotFoundException(
                    $"Item with ID {bookId} was not found."
                );
            }

            if (selectedItem is IBorrowable borrowable)
            {
                return selectedMember.BorrowBook(borrowable);
            }

            return false;
        }



        public bool ReturnBook(int memberId, int bookId)
        {
            Member? selectedMember = null;
            LibraryItem? selectedItem = null;

            foreach (Member member in members)
            {
                if (member.Id == memberId)
                {
                    selectedMember = member;
                    break;
                }
            }

            foreach (LibraryItem item in books)
            {
                if (item.Id == bookId)
                {
                    selectedItem = item;
                    break;
                }
            }

            if (selectedMember == null)
            {
                throw new MemberNotFoundException(
                    $"Member with ID {memberId} was not found."
                );
            }

            if (selectedItem == null)
            {
                throw new LibraryItemNotFoundException(
                    $"Item with ID {bookId} was not found."
                );
            }

            if (selectedItem is IBorrowable borrowable)
            {
                return selectedMember.ReturnBook(borrowable);
            }

            return false;
        }

    }
}
