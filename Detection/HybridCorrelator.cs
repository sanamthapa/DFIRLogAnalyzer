using DFIRLogAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIRLogAnalyzer.Detection
{
    public class HybridCorrelator
    {
        private const double AnomalyThreshold = 0.4;

        public bool IsSecurityIncident(LogEvent log)
        {
            return log.RuleMatched || log.AnomalyScore >= AnomalyThreshold;
        }
    }
}
