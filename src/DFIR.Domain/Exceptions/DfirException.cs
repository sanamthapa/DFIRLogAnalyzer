using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Exceptions
{
    public abstract class DfirException : Exception
    {
        protected DfirException(string message)
            : base(message)
        {
        }

        protected DfirException(
            string message,
            Exception innerException)
            : base(message, innerException)
        {
        }
    }
}