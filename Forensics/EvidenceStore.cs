using DFIRLogAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DFIRLogAnalyzer.Forensics
{
    public class EvidenceStore
    {
        private const string EvidenceFolder = "Evidence";

        public void SaveIncident(Incident incident)
        {
            Directory.CreateDirectory(EvidenceFolder);

            var filePath = Path.Combine(
                EvidenceFolder,
                $"incident_{incident.IncidentId}.json"
            );

            var json = JsonSerializer.Serialize(
                incident,
                new JsonSerializerOptions { WriteIndented = true }
            );

            File.WriteAllText(filePath, json);
        }
    }
}