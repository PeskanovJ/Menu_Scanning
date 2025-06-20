

using MenuParser.Application.Interfaces;
using MenuParser.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MenuParser.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // other registrations...
            services.AddScoped<IMenuImageParser, TesseractMenuImageParser>();
            return services;
        }
    }
}
