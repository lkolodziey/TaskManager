using EclipeWorksTaskManager.Domain.Core.Enumerators;

namespace EclipeWorksTaskManager.Services.DataObjects.Requests;

public class TaskRequest
{
    public required int ProjectId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required DateTime DueDate { get; set; }
    public TaskStatusEnum Status { get; set; }
    public TaskPriorityEnum Priority { get; set; }
}