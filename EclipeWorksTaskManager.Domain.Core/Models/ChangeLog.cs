using System.ComponentModel.DataAnnotations.Schema;

namespace EclipeWorksTaskManager.Domain.Core.Models;

[Table("ChangeLogs")]
public class ChangeLog
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    public string EntityName { get; set; } 
    public string PropertyName { get; set; } 
    public string OriginalValue { get; set; } 
    public string NewValue { get; set; } 
    public DateTime ModifiedAt { get; set; }
}