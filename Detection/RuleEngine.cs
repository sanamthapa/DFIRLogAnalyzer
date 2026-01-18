using DFIRLogAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIRLogAnalyzer.Detection
{
    public class RuleEngine
    {
        private const int FailedLoginThreshold = 2;

        public void ApplyRules(List<LogEvent> logs)
        {
            var failedLoginGroups = logs
                .Where(l => l.EventType == "loginfailed")
                .GroupBy(l => l.User);

            foreach (var group in failedLoginGroups)
            {
                if (group.Count() >= FailedLoginThreshold)
                {
                    foreach (var log in group)
                    {
                        log.RuleMatched = true;
                    }
                }
            }
        }
    }
}