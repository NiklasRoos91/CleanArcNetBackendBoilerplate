using CleanArcNetBackendBoilerplate.Domain.Interfaces;
using CleanArcNetBackendBoilerplate.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArcNetBackendBoilerplate.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config, bool useInMemory)
        {

                var connectionString = config.GetConnectionString("DefaultConnection");
                services.AddDbContext<Persistence.AppDbContext>(options =>
                    options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
