using DFIR.Application.Interfaces;
using DFIR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Infrastructure.Normalization
{
    public class LogNormalizer : ILogNormalizer
    {
        public Task<IEnumerable<NormalizedLogEvent>> NormalizeAsync(
            IEnumerable<NormalizedLogEvent> events,
            CancellationToken cancellationToken = default)
        {
            foreach (var log in events)
            {
                log.Source = log.Source.Trim().ToLowerInvariant();

                log.User = log.User.Trim().ToLowerInvariant();

                log.EventType = log.EventType.Trim().ToLowerInvariant();
            }

            return Task.FromResult(events);
        }
    }
}
