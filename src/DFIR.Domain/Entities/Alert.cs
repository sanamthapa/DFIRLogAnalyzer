using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Entities
{
    public class Alert
    {
        public Guid Id { get; set; } 

        public Guid RuleId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Severity { get; set; } = "Medium";

        public DateTime Timestamp { get; set; }

        public double ConfidenceScore { get; set; }

        public string Status { get; set; } = "New";

        public string MitreTechnique { get; set; } = string.Empty;

        public List<Guid> RelatedLogIds { get; set; } = new();

        public List<string> Tags { get; set; } = new();
    }
}
