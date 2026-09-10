using DFIR.Application.Interfaces;
using DFIR.Domain.Enums;
using DFIR.Domain.Exceptions;
using System.Text;

namespace DFIR.Infrastructure.Detection
{
    public class FileFormatDetector : IFileFormatDetector
    {
        public async Task<LogFormat> DetectAsync(
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

            if (!fileStream.CanRead)
            {
                throw new ValidationException(
                    "File stream cannot be read.");
            }

            cancellationToken.ThrowIfCancellationRequested();

            var extension = Path.GetExtension(fileName)
                .ToLowerInvariant();

            return extension switch
            {
                ".json" => LogFormat.Json,
                ".ndjson" => LogFormat.Ndjson,
                ".csv" => LogFormat.Csv,
                ".xml" => LogFormat.Xml,
                ".pcap" => LogFormat.Pcap,
                ".evtx" => LogFormat.WindowsEventLog,

                ".log" => await DetectLogFileAsync(
                    fileStream,
                    cancellationToken),

                _ => LogFormat.Unknown
            };
        }

        private static async Task<LogFormat> DetectLogFileAsync(
            Stream fileStream,
            CancellationToken cancellationToken)
        {
            if (fileStream.CanSeek)
            {
                fileStream.Position = 0;
            }

            using var reader = new StreamReader(
                fileStream,
                Encoding.UTF8,
                detectEncodingFromByteOrderMarks: true,
                leaveOpen: true);

            var firstLine = await reader.ReadLineAsync(
                cancellationToken);

            if (string.IsNullOrWhiteSpace(firstLine))
            {
                return LogFormat.Unknown;
            }

            var trimmed = firstLine.Trim();

            if (trimmed.StartsWith("{"))
            {
                return LogFormat.Ndjson;
            }

            if (trimmed.StartsWith("<"))
            {
                return LogFormat.Xml;
            }

            if (LooksLikeSyslog(trimmed))
            {
                return LogFormat.Syslog;
            }

            return LogFormat.Unknown;
        }

        private static bool LooksLikeSyslog(string line)
        {
            return line.StartsWith("<") ||
                   line.Contains("kernel:") ||
                   line.Contains("sshd:") ||
                   line.Contains("systemd:");
        }
    }
}