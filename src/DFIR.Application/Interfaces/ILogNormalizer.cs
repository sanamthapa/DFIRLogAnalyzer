using DFIR.Domain.Entities;

namespace DFIR.Application.Interfaces
{
    public interface ILogNormalizer
    {
        Task<IEnumerable<NormalizedLogEvent>> NormalizeAsync(
            IEnumerable<NormalizedLogEvent> events,
            CancellationToken cancellationToken = default);
    }
}
