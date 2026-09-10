using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Entities
{
    public class Evidence
    {
        public Guid Id { get; set; } 

        public string EvidenceName { get; set; } = string.Empty;

        public string EvidenceType { get; set; } = string.Empty;

        public string Source { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public string SHA256Hash { get; set; } = string.Empty;

        public long FileSize { get; set; }

        public DateTime CollectedTime { get; set; }

        public string CollectedBy { get; set; } = string.Empty;

        public string ChainOfCustody { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;

        public bool IsVerified { get; set; }
    }
}
