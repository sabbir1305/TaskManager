using TaskManager.Domain.Entities;

namespace TaskManager.Application.Abstractions.Persistence;

public interface ITaskRepository
{
    Task AddAsync(TaskItem task, CancellationToken ct);
    Task<List<TaskItem>> GetAllAsync(CancellationToken ct);
}
