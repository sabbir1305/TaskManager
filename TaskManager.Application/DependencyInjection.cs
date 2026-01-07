using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Abstractions.Strategies;
using TaskManager.Application.Features.Tasks.Create;
using TaskManager.Application.Features.Tasks.Get;

namespace TaskManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateTaskHandler>();
        services.AddScoped<GetTasksHandler>();
        services.AddScoped<ITaskAssignmentStrategyResolver,
                  TaskAssignmentStrategyResolver>();

        return services;
    }
}
