using DFIRLogAnalyzer.Alerting;
using DFIRLogAnalyzer.Detection;
using DFIRLogAnalyzer.Forensics;
using DFIRLogAnalyzer.LogIngestion;
using DFIRLogAnalyzer.Preprocessing;
using System.Diagnostics;


//var reader = new LogReader();
//var logs = reader.ReadFromFile("Data/logs.json");

//Console.WriteLine($"[INFO] Loaded {logs.Count} raw logs.");

//var normalizer = new Normalizer();
//normalizer.Normalize(logs);

//Console.WriteLine("[INFO] Logs normalized successfully.");

//var ruleEngine = new RuleEngine();
//ruleEngine.ApplyRules(logs);

//Console.WriteLine("[INFO] Rule-based detection completed.");

//var anomalyDetector = new AnomalyDetector();
//anomalyDetector.CalculateAnomalyScores(logs);

//var correlator = new HybridCorrelator();

//Console.WriteLine("[INFO] Hybrid correlation completed.");

//foreach (var log in logs)
//{
//    var incident = correlator.IsSecurityIncident(log);

//    Console.WriteLine(
//        $"{log.Timestamp} | {log.EventType} | {log.User} | " +
//        $"Rule={log.RuleMatched} | Anomaly={log.AnomalyScore:F2} | Incident={incident}"
//    );
//}

var stopwatch = Stopwatch.StartNew();
int totalProcessed = 0;

var batchReader = new BatchLogReader();
var normalizer = new Normalizer();
var ruleEngine = new RuleEngine();
var anomalyDetector = new AnomalyDetector();
var correlator = new HybridCorrelator();
var alertService = new AlertService();
var evidenceStore = new EvidenceStore();

const int BatchSize = 1000;

foreach (var batch in batchReader.ReadBatches("Data/logs.ndjson", BatchSize))
{
    normalizer.Normalize(batch);
    ruleEngine.ApplyRules(batch);
    anomalyDetector.CalculateAnomalyScores(batch);

    foreach (var log in batch)
    {
        if (correlator.IsSecurityIncident(log))
        {
            var incident = alertService.CreateIncident(log);
            evidenceStore.SaveIncident(incident);
        }
    }

    totalProcessed += batch.Count;
}

stopwatch.Stop();

Console.WriteLine($"[METRICS] Total Logs Processed: {totalProcessed}");
Console.WriteLine($"[METRICS] Total Time (ms): {stopwatch.ElapsedMilliseconds}");
Console.WriteLine($"[METRICS] Throughput (logs/sec): " +
    $"{totalProcessed / (stopwatch.ElapsedMilliseconds / 1000.0):F2}");
