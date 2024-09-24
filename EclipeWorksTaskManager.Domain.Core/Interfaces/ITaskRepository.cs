using EclipeWorksTaskManager.Domain.Core.Models;

namespace EclipeWorksTaskManager.Domain.Core.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<TaskModel>?> GetListAsync();
    Task<TaskModel?> GetAsync(int id);
    Task<bool> PostAsync(TaskModel model);
    Task<bool> PutAsync(TaskModel model);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<TaskModel>?> GetByProjectIdAsync(int projectId);
    Task<List<PerformanceReportModel>> GetPerformanceReportAsync();
}