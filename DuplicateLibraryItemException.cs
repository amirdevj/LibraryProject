using System;

namespace FirstProjectBook
{
    public class DuplicateLibraryItemException : Exception
    {
        public DuplicateLibraryItemException(string message)
            : base(message)
        {
        }
    }
}