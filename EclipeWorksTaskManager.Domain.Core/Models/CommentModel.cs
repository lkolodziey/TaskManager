using System.ComponentModel.DataAnnotations.Schema;

namespace EclipeWorksTaskManager.Domain.Core.Models;


[Table("Comments")]
public class CommentModel : BaseModel
{
    public required int TaskId { get; set; }
    public required string Text { get; set; }
    public DateTime? Date { get; set; }
    public required int UserId { get; set; }
}