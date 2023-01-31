using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestStore.CurrencyService.Interfaces;

namespace TestStore.CurrencyService.Tests
{
    public class TestSetup
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public TestSetup()
        {
            var serviceCollection = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(
                     path: "appsettings.json",
                     optional: false,
                     reloadOnChange: true)
               .Build();

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddTransient<ICurrencyService, CurrencyService>();
            serviceCollection.AddHttpClient();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
