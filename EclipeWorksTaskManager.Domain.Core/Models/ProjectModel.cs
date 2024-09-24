using System.ComponentModel.DataAnnotations.Schema;

namespace EclipeWorksTaskManager.Domain.Core.Models;

[Table("Projects")]
public class ProjectModel : BaseModel
{
    public required string Name { get; set; }
    public int UserId { get; set; }
}