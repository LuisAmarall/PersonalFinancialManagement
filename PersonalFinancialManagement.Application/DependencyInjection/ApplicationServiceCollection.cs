using Microsoft.Extensions.DependencyInjection;

namespace PersonalFinancialManagement.Application.DependencyInjection;

public static class ApplicationServiceCollection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        RegisterServices(services);

        return services;
    }

    private static void RegisterServices(IServiceCollection services)
    {
        //services.AddScoped<ICategoryService, CategoryService>();
        //services.AddScoped<IToPayService, ToPayService>();
        //services.AddScoped<IToReceiveService, ToReceiveService>();
        //services.AddScoped<IUserService, UserService>();
    }
}