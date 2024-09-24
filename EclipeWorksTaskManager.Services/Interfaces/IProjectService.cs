using EclipeWorksTaskManager.Services.DataObjects;
using EclipeWorksTaskManager.Services.DataObjects.Requests;

namespace EclipeWorksTaskManager.Services.Interfaces;

public interface IProjectService
{
    Task<List<Project>?> GetListAsync();
    Task<Project?> GetAsync(int id);
    Task<bool> PostAsync(ProjectRequest model);
    Task<bool> PutAsync(int id, ProjectRequest model);
    Task<(bool, string)> DeleteAsync(int id);
}