using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            // services.AddDbContext<QaContext>(
            //     c => c.UseSqlServer(configuration.GetConnectionString("QAConnection")),
            //     ServiceLifetime.Singleton);

            services.AddDbContext<QaContext>(
                c => c.UseSqlServer(configuration.GetConnectionString("QAConnection")),
                ServiceLifetime.Transient);
            return services;
        }
    }
}