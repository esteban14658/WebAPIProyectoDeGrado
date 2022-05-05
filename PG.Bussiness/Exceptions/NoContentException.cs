using System;
using System.Globalization;

namespace PG.Bussiness.Exceptions
{
    [Serializable]
    public class NoContentException : Exception
    {
        public NoContentException(string message) : base(message)
        {
        }

        public NoContentException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
