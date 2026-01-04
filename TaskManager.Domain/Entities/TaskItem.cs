using TaskManager.Domain.Common;
using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;

public class TaskItem : BaseEntity
{
    public string Title { get; private set; } = default!;
    public Enums.TaskStatus Status { get; private set; }

    private TaskItem() { }

    public TaskItem(string title)
    {
        Title = title;
        Status = Enums.TaskStatus.Pending;
    }

    public void Complete()
    {
        Status = Enums.TaskStatus.Completed;
    }

}