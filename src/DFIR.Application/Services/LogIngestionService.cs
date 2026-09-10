using DFIR.Application.Interfaces;
using DFIR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Application.Services
{
    public class LogIngestionService
    {
        private readonly ILogReader _logReader;
        private readonly ILogParser _logParser;
        private readonly ILogNormalizer _logNormalizer;

        public LogIngestionService(
            ILogReader logReader,
            ILogParser logParser,
            ILogNormalizer logNormalizer)
        {
            _logReader = logReader;
            _logParser = logParser;
            _logNormalizer = logNormalizer;
        }

        public async Task<IEnumerable<NormalizedLogEvent>> IngestAsync(
            string filePath,
            CancellationToken cancellationToken = default)
        {
            var rawLogs = await _logReader.ReadAsync(
                filePath,
                cancellationToken);

            var parsedLogs = await _logParser.ParseAsync(
                rawLogs,
                cancellationToken);

            var normalizedLogs = await _logNormalizer.NormalizeAsync(
                parsedLogs,cancellationToken);

            return normalizedLogs;
        }
    }
}