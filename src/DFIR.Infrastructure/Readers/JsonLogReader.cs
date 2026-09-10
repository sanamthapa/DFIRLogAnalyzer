using DFIR.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Infrastructure.Readers
{
    public class JsonLogReader : ILogReader
    {
        public async Task<IEnumerable<string>> ReadAsync(string filePath, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException(
                    "Log source cannot be empty.",
                    nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException(
                    "Log file was not found.",
                    filePath);

            var lines = new List<string>();

            await using var stream = File.OpenRead(filePath);

            using var reader = new StreamReader(stream);

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
