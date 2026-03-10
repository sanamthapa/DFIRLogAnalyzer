using DFIRLogAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIRLogAnalyzer.Risk
{
    public class RiskEngine
    {
        private const double RuleWeight = 0.6;
        private const double AnomalyWeight = 0.4;

        public double CalculateRisk(LogEvent log, List<string> reasons)
        {
            double ruleScore = 0.0;

            if (log.RuleMatched)
            {
                ruleScore = 1.0;
                reasons.Add("Rule-based detection triggered");
            }

            if (log.AnomalyScore > 0.5)
            {
                reasons.Add("High anomaly score detected");
            }

            double finalRisk =
                (RuleWeight * ruleScore) +
                (AnomalyWeight * log.AnomalyScore);

            return Math.Round(finalRisk, 3);
        }
    }
}
   