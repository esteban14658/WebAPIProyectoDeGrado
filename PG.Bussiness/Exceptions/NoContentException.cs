using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.Bussiness.Exceptions
{
    public class NoContentException: Exception
    {
        public NoContentException(string message): base(message)
        {
        }

        public NoContentException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
