using DFIRLogAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIRLogAnalyzer.Alerting
{
    public class AlertService
    {
        public Incident CreateIncident(LogEvent log)
        {
            return new Incident
            {
                DetectionType = log.RuleMatched ? "Rule-Based" : "Anomaly-Based",
                EventType = log.EventType ?? "unknown",
                User = log.User ?? "unknown",
                IpAddress = log.IpAddress ?? "unknown",
                RuleMatched = log.RuleMatched,
                AnomalyScore = log.AnomalyScore
            };
        }
    }
}