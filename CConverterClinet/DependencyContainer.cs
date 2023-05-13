using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CConverterClient
{
    public static class DependencyContainer
    {
        public static void AddViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddScoped<MainWindowViewModel>();
        }
    }
}
