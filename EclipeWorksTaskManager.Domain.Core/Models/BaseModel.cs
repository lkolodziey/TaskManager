using System.ComponentModel.DataAnnotations;

namespace EclipeWorksTaskManager.Domain.Core.Models;

public class BaseModel
{
    [Key]
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
}