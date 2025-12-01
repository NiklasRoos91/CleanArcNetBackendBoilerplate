using CleanArcNetBackendBoilerplate.Domain.Interfaces;
using CleanArcNetBackendBoilerplate.Infrastructure.Repositories;
using CleanArcNetBackendBoilerplate.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArcNetBackendBoilerplate.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config, bool useInMemory)
        {
            // Configure DbContext
            var connectionString = config.GetConnectionString("DefaultConnection");
                services.AddDbContext<Persistence.AppDbContext>(options =>
                    options.UseSqlServer(connectionString));

            // Add repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            // Add services
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
