using EclipeWorksTaskManager.Services.DataObjects;
using EclipeWorksTaskManager.Services.DataObjects.Requests;


namespace EclipeWorksTaskManager.Services.Interfaces;

public interface ITaskService
{
    Task<List<TaskDto>?> GetListAsync();
    Task<TaskDto?> GetAsync(int id);
    Task<(bool, string)> PostAsync(TaskRequest model);
    Task<(bool, string)> PutAsync(int id, TaskRequest model);
    Task<bool> DeleteAsync(int id);
    Task<List<TaskDto>?> GetByProjectIdAsync(int projectId);
    Task<List<PerformanceReport>> GetPerformanceReportAsynnc();
}