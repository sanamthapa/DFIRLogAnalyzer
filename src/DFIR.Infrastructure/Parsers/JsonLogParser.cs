using DFIR.Application.Interfaces;
using DFIR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DFIR.Infrastructure.Parsers
{
    public class JsonLogParser : ILogParser
    {
        public Task<IEnumerable<NormalizedLogEvent>> ParseAsync(
            IEnumerable<string> rawLogs,
            CancellationToken cancellationToken = default)
        {
            var events = new List<NormalizedLogEvent>();

            foreach (var rawLog in rawLogs)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (string.IsNullOrWhiteSpace(rawLog))
                    continue;

                try
                {
                    var logEvent = JsonSerializer.Deserialize<NormalizedLogEvent>(
                        rawLog);

                    if (logEvent is not null)
                    {
                        events.Add(logEvent);
                    }
                }
                catch (JsonException)
                {
                    // Invalid JSON log entry.
                    // Later we can add structured error handling and logging.
                }
            }

            return Task.FromResult<IEnumerable<NormalizedLogEvent>>(events);
        }
    }
}