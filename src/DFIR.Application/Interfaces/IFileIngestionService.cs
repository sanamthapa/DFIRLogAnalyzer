using DFIR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Application.Interfaces
{
    public interface IFileIngestionService
    {
        Task<IEnumerable<NormalizedLogEvent>> ProcessAsync(
            Stream fileStream,
            string fileName,
            CancellationToken cancellationToken = default);
    }
}
