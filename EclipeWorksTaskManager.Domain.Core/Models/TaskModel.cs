using System.ComponentModel.DataAnnotations.Schema;
using EclipeWorksTaskManager.Domain.Core.Enumerators;

namespace EclipeWorksTaskManager.Domain.Core.Models;

[Table("Tasks")]
public class TaskModel : BaseModel
{
    public int ProjectId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required DateTime DueDate { get; set; }
    public TaskStatusEnum Status { get; set; }
    public TaskPriorityEnum Priority { get; set; }
    public int UserId { get; set; }
}