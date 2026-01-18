using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFIRLogAnalyzer.Models
{
    public class LogEvent
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("source")]
        public string? Source { get; set; }

        [JsonPropertyName("eventType")]
        public string? EventType { get; set; }

        [JsonPropertyName("user")]
        public string? User { get; set; }

        [JsonPropertyName("ipAddress")]
        public string? IpAddress { get; set; }

        public bool RuleMatched { get; set; }
        public double AnomalyScore { get; set; }
    }
}
