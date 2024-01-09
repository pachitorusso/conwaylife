using Microsoft.Extensions.DependencyInjection;

namespace ConwayLife.Application;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGameUseCase, GameUseCase>();
        return services;
    }
}