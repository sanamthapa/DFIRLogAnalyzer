using DFIR.Domain.Entities;

namespace DFIR.Application.Interfaces
{
    public interface ILogParser
    {
        Task<IEnumerable<NormalizedLogEvent>> ParseAsync(
            IEnumerable<string> rawLogs,
            CancellationToken cancellationToken = default);
    }
}
