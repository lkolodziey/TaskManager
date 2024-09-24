namespace EclipeWorksTaskManager.Domain.Core.Models;

public class PerformanceReportModel
{
    public string UserName { get; set; }
    public int CompletedTasks { get; set; }
    public double AverageTasksPerDay { get; set; }
}