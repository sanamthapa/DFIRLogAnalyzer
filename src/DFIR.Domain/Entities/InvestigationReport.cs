using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Entities
{
    public class InvestigationReport
    {
        public Guid Id { get; set; } 
        public string ReportTitle { get; set; } = string.Empty;

        public string ExecutiveSummary { get; set; } = string.Empty;

        public string Findings { get; set; } = string.Empty;

        public string Recommendations { get; set; } = string.Empty;

        public string Conclusion { get; set; } = string.Empty;

        public string GeneratedBy { get; set; } = string.Empty;

        public DateTime GeneratedTime { get; set; } = DateTime.UtcNow;

        public Incident? Incident { get; set; }

        public List<Evidence> Evidence { get; set; } = new();

        public List<TimelineEvent> Timeline { get; set; } = new();
    }
}
