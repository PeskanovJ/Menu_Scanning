using Microsoft.Extensions.DependencyInjection;
using MenuParser.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MenuParser.Infrastructure.Persistence;

namespace MenuParser.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {   
            services.AddDbContext<MenuRepository>(options => options.UseSqlite(connectionString));
            services.AddScoped<IMenuRepository, MenuRepository>();
            return services;
        }
    }
}
