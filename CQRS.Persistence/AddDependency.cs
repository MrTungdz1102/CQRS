using CQRS.Application.InterfaceContracts.Persistence;
using CQRS.Persistence.Data;
using CQRS.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Persistence
{
    public static class AddDependency
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,  IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
