using System.ComponentModel.DataAnnotations.Schema;

namespace EclipeWorksTaskManager.Domain.Core.Models;

[Table("Users")]
public class UserModel : BaseModel
{
    public required string Username { get; set; }
    public required string Role { get; set; }
}