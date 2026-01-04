using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Features.Tasks.Create;
using TaskManager.Application.Features.Tasks.Get;

namespace TaskManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateTaskHandler>();
        services.AddScoped<GetTasksHandler>();
        return services;
    }
}
