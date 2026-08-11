using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Entities
{
    public class Incident
    {
        public Guid Id { get; set; } 

        public string IncidentNumber { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = "Open";

        public string Priority { get; set; } = "Medium";

        public DateTime CreatedTime { get; set; }

        public DateTime? ClosedTime { get; set; }

        public string AssignedTo { get; set; } = string.Empty;

        public List<Alert> Alerts { get; set; } = new();

        public List<Evidence> Evidence { get; set; } = new();

        public List<TimelineEvent> Timeline { get; set; } = new();

        public RiskAssessment? RiskAssessment { get; set; }
    }
}
