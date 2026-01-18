using DFIRLogAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIRLogAnalyzer.Preprocessing
{
    public class Normalizer
    {
        public void Normalize(List<LogEvent> logs)
        {
            foreach (var log in logs)
            {
                log.Source = log.Source?.ToLowerInvariant() ?? "unknown";
                log.EventType = log.EventType?.ToLowerInvariant() ?? "unknown";
                log.User = log.User?.ToLowerInvariant() ?? "unknown";
            }
        }
    }
}
