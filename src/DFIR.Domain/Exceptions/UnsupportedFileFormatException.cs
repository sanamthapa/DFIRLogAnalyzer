using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Exceptions
{
    public class UnsupportedFileFormatException : DfirException
    {
        public string FileName { get; }

        public UnsupportedFileFormatException(
            string fileName)
            : base($"The file format of '{fileName}' is not supported.")
        {
            FileName = fileName;
        }
    }
}
