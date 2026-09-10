using DFIR.Application.Interfaces;
using DFIR.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFIR.Application.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDFIRApplication(
            this IServiceCollection services)
        {
            services.AddScoped<LogIngestionService>();

            services.AddScoped<FileIngestionService>();

            services.AddScoped<IFileIngestionService,FileIngestionService>();

            return services;
        }
    }
}
