namespace EclipeWorksTaskManager.Services.DataObjects;

public class User : BaseDto
{
    public required string Username { get; set; }
    public required string Role { get; set; }
}