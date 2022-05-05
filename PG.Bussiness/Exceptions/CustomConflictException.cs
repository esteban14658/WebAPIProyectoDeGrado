using System;
using System.Globalization;

namespace PG.Bussiness.Exceptions
{
    [Serializable]
    public class CustomConflictException : Exception
    {
        public CustomConflictException() : base()
        {
        }

        public CustomConflictException(string message) : base(message)
        {
        }

        public CustomConflictException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
