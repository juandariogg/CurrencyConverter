using Controllers.Convert;
using Core.Interface.Convert;
using Dtos.Convert.NumberToWord;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public static class DependencyContainer
    {
        public static void RegisterControllers(this IServiceCollection services)
        {
            services.AddScoped<IController<NumberToWordRequest, NumberToWordResponse>, NumberToWordController>();
        }
    }
}
