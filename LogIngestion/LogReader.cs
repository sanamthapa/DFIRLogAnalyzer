using DFIRLogAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DFIRLogAnalyzer.LogIngestion
{
    public class LogReader
    {
        public List<LogEvent> ReadFromFile(string relativePath)
        {
            var basePath = AppContext.BaseDirectory;
            var fullPath = Path.Combine(basePath, relativePath);

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"Log file not found: {fullPath}");
            }

            var json = File.ReadAllText(fullPath);

            return JsonSerializer.Deserialize<List<LogEvent>>(json)
                   ?? new List<LogEvent>();
        }
    }
}
