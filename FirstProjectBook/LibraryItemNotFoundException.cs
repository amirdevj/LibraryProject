using System;

namespace FirstProjectBook
{
    public class LibraryItemNotFoundException : Exception
    {
        public LibraryItemNotFoundException(string message)
            : base(message)
        {
        }
    }
}