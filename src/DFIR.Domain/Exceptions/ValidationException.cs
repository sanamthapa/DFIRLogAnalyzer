using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Exceptions
{
    public class ValidationException : DfirException
    {
        public ValidationException(string message)
            : base(message)
        {
        }
    }
}
