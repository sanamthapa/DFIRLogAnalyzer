using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Enums
{
    public enum EventSourceType
    {
        WindowsEventLog,
        LinuxSyslog,
        Apache,
        IIS,
        Firewall,
        Zeek,
        Suricata,
        Sysmon,
        ActiveDirectory,
        Microsoft365,
        Azure,
        AWS,
        GCP,
        EndpointDetection,
        Other
    }
}
