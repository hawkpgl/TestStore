using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestStore.Core.Interfaces.Data;
using TestStore.EntityFramework.Repositories;
using static System.Formats.Asn1.AsnWriter;

namespace TestStore.EntityFramework
{
    public static class EntityFrameworkModule
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddDbContext<TestStoreDbContext>();
        }
    }
}
