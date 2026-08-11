using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Enums
{
    public enum MitreTactic
    {
        InitialAccess,
        Execution,
        Persistence,
        PrivilegeEscalation,
        DefenseEvasion,
        CredentialAccess,
        Discovery,
        LateralMovement,
        Collection,
        CommandAndControl,
        Exfiltration,
        Impact
    }
}
