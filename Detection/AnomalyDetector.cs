using DFIRLogAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIRLogAnalyzer.Detection
{
    public class AnomalyDetector
    {
        public void CalculateAnomalyScores(List<LogEvent> logs)
        {
            var totalEvents = logs.Count;

            var eventTypeFrequency = logs.Where(x => !string.IsNullOrWhiteSpace(x.EventType))
                .GroupBy(l => l.EventType!)
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (var log in logs)
            {
                if (log.EventType == null || !eventTypeFrequency.ContainsKey(log.EventType))
                {
                    log.AnomalyScore = 1.0;
                    continue;
                }

                var frequency = eventTypeFrequency[log.EventType];
                log.AnomalyScore = 1.0 - ((double)frequency / totalEvents);
            }
        }
    }
}
