using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Enums
{
    public enum EvidenceType
    {
        LogFile,
        EventLog,
        Registry,
        MemoryDump,
        NetworkCapture,
        File,
        Process,
        Service,
        ScheduledTask,
        Email,
        RegistryKey,
        BrowserHistory,
        Screenshot,
        Hash,
        IOC,
        Other
    }
}
