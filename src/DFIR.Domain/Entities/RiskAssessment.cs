using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Entities
{
    public class RiskAssessment
    {
        public Guid Id { get; set; } 

        public double RiskScore { get; set; }

        public double ConfidenceScore { get; set; }

        public string Severity { get; set; } = "Medium";

        public double Likelihood { get; set; }

        public double Impact { get; set; }

        public string RiskLevel { get; set; } = "Medium";

        public string Recommendation { get; set; } = string.Empty;

        public DateTime AssessedOn { get; set; } = DateTime.UtcNow;

        public string AssessedBy { get; set; } = "DFIR Engine";
    }
}
