using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Enums
{
    public enum TimelineCategory
    {
        Authentication,
        Process,
        Network,
        FileSystem,
        Registry,
        Persistence,
        PrivilegeEscalation,
        LateralMovement,
        Execution,
        Discovery,
        Collection,
        Exfiltration,
        Alert,
        Evidence,
        Other
    }
}
