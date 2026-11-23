
using System;

namespace FirstProjectBook
{
    public class MemberNotFoundException : Exception
    {
        public MemberNotFoundException(string message)
            : base(message)
        {
        }
    }
}
