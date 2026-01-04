using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Persistence;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options) { }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();

}
