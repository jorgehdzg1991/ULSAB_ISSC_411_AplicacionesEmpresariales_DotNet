using System;

namespace PostsAppDAL.Exceptions
{
    public class DuplicateKeyException : Exception
    {
        public DuplicateKeyException()
        { }

        public DuplicateKeyException(string message) : base(message)
        { }
    }
}
