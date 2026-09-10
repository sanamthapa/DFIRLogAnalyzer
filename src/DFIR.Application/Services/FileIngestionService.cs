using DFIR.Application.Interfaces;
using DFIR.Domain.Entities;
using DFIR.Domain.Enums;
using DFIR.Domain.Exceptions;

namespace DFIR.Application.Services
{
    public class FileIngestionService : IFileIngestionService
    {
        private readonly IFileFormatDetector _formatDetector;
        private readonly ILogParser _logParser;
        private readonly ILogNormalizer _logNormalizer;

        public FileIngestionService(
            IFileFormatDetector formatDetector,
            ILogParser logParser,
            ILogNormalizer logNormalizer)
        {
            _formatDetector = formatDetector;
            _logParser = logParser;
            _logNormalizer = logNormalizer;
        }

        public async Task<IEnumerable<NormalizedLogEvent>> ProcessAsync(
            Stream fileStream,
            string fileName,
            CancellationToken cancellationToken = default)
        {
            if (fileStream is null)
            {
                throw new ValidationException(
                    "File stream cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ValidationException(
                    "File name cannot be empty.");
            }

            cancellationToken.ThrowIfCancellationRequested();

            var format = await _formatDetector.DetectAsync(
                fileStream,
                fileName,
                cancellationToken);

            if (format == LogFormat.Unknown)
            {
                throw new UnsupportedFileFormatException(fileName);
            }

            if (fileStream.CanSeek)
            {
                fileStream.Position = 0;
            }

            var rawLogs = await ReadLinesAsync(
                fileStream,
                cancellationToken);

            var parsedLogs = await _logParser.ParseAsync(
                rawLogs,
                cancellationToken);

            var normalizedLogs = await _logNormalizer.NormalizeAsync(
                parsedLogs);

            return normalizedLogs;
        }

        private static async Task<IEnumerable<string>> ReadLinesAsync(
            Stream stream,
            CancellationToken cancellationToken)
        {
            var lines = new List<string>();

            using var reader = new StreamReader(
                stream,
                leaveOpen: true);

            while (!reader.EndOfStream)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var line = await reader.ReadLineAsync(
                    cancellationToken);

                if (!string.IsNullOrWhiteSpace(line))
                {
                    lines.Add(line);
                }
            }

            return lines;
        }
    }
}