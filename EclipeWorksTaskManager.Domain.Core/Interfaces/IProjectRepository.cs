using EclipeWorksTaskManager.Domain.Core.Models;

namespace EclipeWorksTaskManager.Domain.Core.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<ProjectModel?>> GetListAsync();
    Task<ProjectModel?> GetAsync(int id);
    Task<bool> PostAsync(ProjectModel model);
    Task<bool> PutAsync(ProjectModel model);
    Task<bool> DeleteAsync(int id);
}