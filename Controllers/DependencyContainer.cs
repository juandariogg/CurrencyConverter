using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Dtos.Converter.NumeralToWordConverter;
using Controllers.Converter.NumeralToWordConverter;

namespace Controllers
{
    public static class DependencyContainer 
    {
        public static void AddServiceControllers(this IServiceCollection services)
        {
            services.AddScoped<IController<NumeralToWordRequest, NumeralToWordResponse>, NumeralToWordConverterController>();
        }
    }
}
