using DFIR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Application.Interfaces
{
    public interface IReportGenerator
    {
        Task<InvestigationReport> GenerateAsync(
            Incident incident,
            CancellationToken cancellationToken = default);
    }
}
