using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Persistence.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _db;

    public TaskRepository(TaskDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(TaskItem task, CancellationToken ct)
    {
        _db.Tasks.Add(task);
        await _db.SaveChangesAsync(ct);
    }

    public async Task<List<TaskItem>> GetAllAsync(CancellationToken ct)
    {
        return await _db.Tasks.AsNoTracking().ToListAsync(ct);
    }
}
