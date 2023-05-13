using Core.Interface.Convert;
using Microsoft.Extensions.DependencyInjection;
using Services.Convert.NumberToWord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class DependencyContainer
    {
        public static void AddServices (this IServiceCollection services)
        {
            services.AddScoped<INumberToWordService, NumberToWordConverterService>();
        }
    }
}
