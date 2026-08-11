using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Entities
{
    public class DetectionRule
    {
        public Guid Id { get; set; } 
        public string RuleName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string RuleType { get; set; } = string.Empty;

        public string Severity { get; set; } = "Medium";

        public string MitreTechnique { get; set; } = string.Empty;

        public string MitreTactic { get; set; } = string.Empty;

        public string Condition { get; set; } = string.Empty;

        public bool IsEnabled { get; set; } = true;

        public int Priority { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public string Author { get; set; } = string.Empty;

        public string Version { get; set; } = "1.0";
    }
}
