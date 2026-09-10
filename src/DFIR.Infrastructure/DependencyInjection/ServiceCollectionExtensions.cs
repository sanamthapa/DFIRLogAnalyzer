using DFIR.Application.Interfaces;
using DFIR.Application.Services;
using DFIR.Infrastructure.Detection;
using DFIR.Infrastructure.Normalization;
using DFIR.Infrastructure.Parsers;
using DFIR.Infrastructure.Readers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDFIRInfrastructure(
            this IServiceCollection services)
        {   
            services.AddScoped<ILogReader, JsonLogReader>();

            services.AddScoped<ILogParser, JsonLogParser>();

            services.AddScoped<ILogNormalizer, LogNormalizer>();

            services.AddScoped<LogIngestionService>();

            services.AddScoped<IFileFormatDetector, FileFormatDetector>();

            services.AddScoped<FileIngestionService>();

            return services;
        }
    }
}
    

