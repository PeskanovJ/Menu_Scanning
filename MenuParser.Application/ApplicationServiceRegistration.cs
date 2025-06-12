using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MenuParser.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
       }
    }
}
