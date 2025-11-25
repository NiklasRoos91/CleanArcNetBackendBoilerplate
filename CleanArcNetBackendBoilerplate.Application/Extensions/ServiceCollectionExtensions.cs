using CleanArcNetBackendBoilerplate.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArcNetBackendBoilerplate.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {  
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(ServiceCollectionExtensions).Assembly;

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddScoped<PasswordHasher<User>>();

            return services;
        }
    }
}