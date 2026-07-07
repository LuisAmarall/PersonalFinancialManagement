using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinancialManagement.Infrastructure.Persistence.Context;

namespace PersonalFinancialManagement.Infrastructure.DependencyInjaction;

public static class InfrastructureServiceCollection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        RegisterDbContext(service, configuration);

        return service;
    }

    private static void RegisterDbContext(IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<ApplicationContext>(option =>
        option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient, ServiceLifetime.Transient);
    }
}