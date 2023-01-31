using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TestStore.Application.AutoMapper;
using TestStore.Application.Queries;
using TestStore.Application.Queries.QuerryHandlers;
using TestStore.Application.ViewModels;
using TestStore.Core.Interfaces.Data;

namespace TestStore.Application
{
    public static class ApplicationModule
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddScoped<IRequestHandler<GetOrderQuery, OrderViewModel>, GetOrderQueryHandler>();

            ConfigureMappingProfiles(services);
        }

        private static void ConfigureMappingProfiles(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(OrderToVMMappingProfile), typeof(VMToOrderMappingProfile));
            services.AddAutoMapper(typeof(OrderItemToVMMappingProfile), typeof(VMToOrderItemMappingProfile));
        }
    }
}
