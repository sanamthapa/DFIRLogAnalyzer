using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Enums
{
    public enum IncidentStatus
    {
        Open,
        Investigating,
        Contained,
        Eradicated,
        Recovered,
        Closed
    }
}
