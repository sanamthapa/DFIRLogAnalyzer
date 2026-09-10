using DFIR.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Application.Interfaces
{
    public interface IFileFormatDetector
    {
        Task<LogFormat> DetectAsync(
            Stream fileStream,
            string fileName,
            CancellationToken cancellationToken = default);
    }
}