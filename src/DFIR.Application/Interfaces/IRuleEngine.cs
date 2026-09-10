using DFIR.Domain.Entities;

namespace DFIR.Application.Interfaces
{
    public interface IRuleEngine
    {
        Task<IEnumerable<Alert>> EvaluateAsync(
            IEnumerable<NormalizedLogEvent> events,
            CancellationToken cancellationToken = default);
    }
}
