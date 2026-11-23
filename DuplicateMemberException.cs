using System;

namespace FirstProjectBook
{
    public class DuplicateMemberException : Exception
    {
        public DuplicateMemberException(string message)
            : base(message)
        {
        }
    }
}