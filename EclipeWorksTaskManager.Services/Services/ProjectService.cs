using AutoMapper;
using EclipeWorksTaskManager.Domain.Core.Enumerators;
using EclipeWorksTaskManager.Domain.Core.Interfaces;
using EclipeWorksTaskManager.Domain.Core.Models;
using EclipeWorksTaskManager.Services.DataObjects;
using EclipeWorksTaskManager.Services.DataObjects.Requests;
using EclipeWorksTaskManager.Services.Interfaces;


namespace EclipeWorksTaskManager.Services.Services;

public class ProjectService(
    IMapper mapper,
    IProjectRepository repository,
    ITaskRepository taskRepository) : IProjectService
{
    public async Task<List<Project>?> GetListAsync()
    {
        var response = await repository.GetListAsync();
        var result = mapper.Map<List<Project>>(response);
        foreach (var project in result)
        {
            project.Tasks = mapper.Map<List<TaskDto>>(await taskRepository.GetByProjectIdAsync(project.Id));
        }

        return mapper.Map<List<Project>>(result);
    }

    public async Task<Project?> GetAsync(int id)
    {
        var response = await repository.GetAsync(id);
        var result = mapper.Map<Project>(response);
        result.Tasks = mapper.Map<List<TaskDto>>(await taskRepository.GetByProjectIdAsync(id));
        return result;
    }

    public async Task<bool> PostAsync(ProjectRequest model)
    {
        var mapped = mapper.Map<ProjectModel>(model);
        return await repository.PostAsync(mapped);
    }

    public async Task<bool> PutAsync(int id, ProjectRequest model)
    {
        var mapped = mapper.Map<ProjectModel>(model);
        return await repository.PutAsync(mapped);
    }

    public async Task<(bool, string)> DeleteAsync(int id)
    {
        var tasks = await taskRepository.GetByProjectIdAsync(id);
        var openedTasks = tasks.Count(x => x.Status == TaskStatusEnum.Active);
        return openedTasks == 0
            ? (await repository.DeleteAsync(id), "Successfully deleted")
            : (false, $"There are {openedTasks}, yet opened");
    }
}