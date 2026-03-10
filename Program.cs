using DFIRLogAnalyzer.Alerting;
using DFIRLogAnalyzer.Detection;
using DFIRLogAnalyzer.Forensics;
using DFIRLogAnalyzer.LogIngestion;
using DFIRLogAnalyzer.Preprocessing;
using DFIRLogAnalyzer.Risk;
using System.Diagnostics;

var stopwatch = Stopwatch.StartNew();
int totalProcessed = 0;

var batchReader = new BatchLogReader();
var normalizer = new Normalizer();
var ruleEngine = new RuleEngine();
var anomalyDetector = new AnomalyDetector();
var alertService = new AlertService();
var evidenceStore = new EvidenceStore();
var riskEngine = new RiskEngine();

const int BatchSize = 1000;

foreach (var batch in batchReader.ReadBatches("Data/logs.ndjson", BatchSize))
{
    normalizer.Normalize(batch);
    ruleEngine.ApplyRules(batch);
    anomalyDetector.CalculateAnomalyScores(batch);

    foreach (var log in batch)
    {
        var reasons = new List<string>();
        double risk = riskEngine.CalculateRisk(log, reasons);

        if (risk >= 0.7)
        {
            var incident = alertService.CreateIncident(log);
            incident.FinalRiskScore = risk;
            incident.DetectionReasons = reasons;

            evidenceStore.SaveIncident(incident);
        }
    }

    totalProcessed += batch.Count;
}

stopwatch.Stop();

Console.WriteLine($"[METRICS] Total Logs Processed: {totalProcessed}");
Console.WriteLine($"[METRICS] Total Time (ms): {stopwatch.ElapsedMilliseconds}");
Console.WriteLine($"[METRICS] Throughput (logs/sec): {totalProcessed / (stopwatch.ElapsedMilliseconds / 1000.0):F2}");
