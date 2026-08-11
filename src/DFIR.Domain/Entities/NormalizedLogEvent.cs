using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Entities
{
    public class NormalizedLogEvent
    {
        public Guid Id { get; set; } 

        public DateTime Timestamp { get; set; }

        public string Source { get; set; } = string.Empty;

        public string HostName { get; set; } = string.Empty;

        public string User { get; set; } = string.Empty;

        public string EventType { get; set; } = string.Empty;

        public string Severity { get; set; } = "Information";
        public string Message { get; set; } 

        public string? SourceIp { get; set; }

        public string? DestinationIp { get; set; }

        public string? ProcessName { get; set; }

        public Dictionary<string, string> Metadata { get; set; } = new();
    }
}
