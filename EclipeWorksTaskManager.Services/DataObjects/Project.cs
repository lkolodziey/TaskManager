namespace EclipeWorksTaskManager.Services.DataObjects;

public class Project : BaseDto
{
    public required string Name { get; set; }
    public List<TaskDto>? Tasks { get; set; }
    public required int UserId { get; set; }
    public string? Username { get; set; }
}