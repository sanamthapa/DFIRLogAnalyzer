using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Entities
{
    public class TimelineEvent
    {
        public Guid Id { get; set; } 

        public DateTime Timestamp { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Source { get; set; } = string.Empty;

        public Guid? AlertId { get; set; }

        public Guid? EvidenceId { get; set; }

        public Guid? LogEventId { get; set; }
    }
}
