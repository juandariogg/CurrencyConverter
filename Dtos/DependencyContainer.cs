using Dtos.Converter.NumeralToWordConverter;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public static class DependencyContainer
    {
        public static void AddModelValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<NumeralToWordRequest>, NumeralToWordValidator>();
        }
    }
}
