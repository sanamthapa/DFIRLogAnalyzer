using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Enums
{
    public enum LogFormat
    {
        Unknown = 0,
        Json = 1,
        Ndjson = 2,
        Csv = 3,
        Xml = 4,
        Syslog = 5,
        WindowsEventLog = 6,
        Pcap = 7
    }
}
