using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.Bussiness.Exceptions
{
    public class CustomConflictException: Exception
    {
        public CustomConflictException() : base()
        {
        }

        public CustomConflictException(string message): base(message)
        {
        }

        public CustomConflictException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
