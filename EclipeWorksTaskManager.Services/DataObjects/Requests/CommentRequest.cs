namespace EclipeWorksTaskManager.Services.DataObjects.Requests;

public class CommentRequest
{
    public required int TaskId { get; set; }
    public required string Text { get; set; }
    public DateTime Date { get; set; }
    public required int UserId { get; set; }
}