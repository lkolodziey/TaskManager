namespace EclipeWorksTaskManager.Services.DataObjects;

public class Comment : BaseDto
{
    public required int TaskId { get; set; }
    public required string Text { get; set; }
    public DateTime Date { get; set; }
    public required int UserId { get; set; }
}