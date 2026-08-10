using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinancialManagement.Application.Interfaces.Repositories;
using PersonalFinancialManagement.Infrastructure.Persistence.Context;
using PersonalFinancialManagement.Infrastructure.Repositories;

namespace PersonalFinancialManagement.Infrastructure.DependencyInjaction;

public static class InfrastructureServiceCollection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterDbContext(services, configuration);
        RegisterRepositories(services);

        return services;
    }

    private static void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(option =>
        option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient, ServiceLifetime.Transient);
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IToPayRepository, ToPayRepository>();
        services.AddScoped<IToReceiveRepository, ToReceiveRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}