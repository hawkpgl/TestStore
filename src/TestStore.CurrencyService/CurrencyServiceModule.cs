using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestStore.CurrencyService.Interfaces;

namespace TestStore.CurrencyService
{
    public static class CurrencyServiceModule
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICurrencyService, CurrencyService>();
        }
    }
}
