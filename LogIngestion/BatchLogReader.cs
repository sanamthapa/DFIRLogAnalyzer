using DFIRLogAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DFIRLogAnalyzer.LogIngestion
{
    public class BatchLogReader
    {
        public IEnumerable<List<LogEvent>> ReadBatches(
            string relativePath,
            int batchSize)
        {
            var basePath = AppContext.BaseDirectory;
            var fullPath = Path.Combine(basePath, relativePath);

            using var stream = File.OpenRead(fullPath);
            using var reader = new StreamReader(stream);

            var batch = new List<LogEvent>(batchSize);

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                var log = JsonSerializer.Deserialize<LogEvent>(line);
                if (log == null) continue;

                batch.Add(log);

                if (batch.Count >= batchSize)
                {
                    yield return batch;
                    batch = new List<LogEvent>(batchSize);
                }
            }

            if (batch.Count > 0)
            {
                yield return batch;
            }
        }
    }
}
