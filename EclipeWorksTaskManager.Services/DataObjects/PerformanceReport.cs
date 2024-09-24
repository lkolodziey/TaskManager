namespace EclipeWorksTaskManager.Services.DataObjects;

public class PerformanceReport
{
    public string UserName { get; set; }
    public int CompletedTasks { get; set; }
    public double AverageTasksPerDay { get; set; }
}