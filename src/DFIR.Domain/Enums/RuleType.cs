using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Domain.Enums
{
    public enum RuleType
    {
        Signature,
        Behaviour,
        Threshold,
        Correlation,
        AnomalyDetection,
        MachineLearning,
        ThreatIntelligence,
        Custom
    }
}
