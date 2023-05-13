using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services.Converter.NumeralToWordConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class DependencyContainer
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<INumeralToWordConverterService, NumeralToWordConverterService>();
        }
    }
}
