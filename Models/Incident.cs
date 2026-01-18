using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIRLogAnalyzer.Models
{
    public class Incident
    {
        public Guid IncidentId { get; set; }
        public DateTime DetectedAt { get; set; } = DateTime.UtcNow;

        public string DetectionType { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;

        public bool RuleMatched { get; set; }
        public double AnomalyScore { get; set; }

        // Forensic metadata
        public string EvidenceHash { get; set; } = string.Empty;
        public string SourceSystem { get; set; } = "LogAnalyzer";
    }
}
