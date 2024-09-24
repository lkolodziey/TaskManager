using AutoMapper;
using EclipeWorksTaskManager.Domain.Core.Enumerators;
using EclipeWorksTaskManager.Domain.Core.Interfaces;
using EclipeWorksTaskManager.Domain.Core.Models;
using EclipeWorksTaskManager.Services.DataObjects;
using EclipeWorksTaskManager.Services.DataObjects.Requests;
using EclipeWorksTaskManager.Services.Interfaces;


namespace EclipeWorksTaskManager.Services.Services;

public class TaskService(IMapper mapper, ITaskRepository repository) : ITaskService
{
    public async Task<List<TaskDto>?> GetListAsync()
    {
        var response = await repository.GetListAsync();
        return mapper.Map<List<TaskDto>>(response);
    }

    public async Task<TaskDto?> GetAsync(int id)
    {
        var response = await repository.GetAsync(id);
        return mapper.Map<TaskDto>(response);
    }

    public async Task<(bool, string)> PostAsync(TaskRequest model)
    {
        // validar se há mais de 20 tarefas
        var tasks = await repository.GetByProjectIdAsync(model.ProjectId);
        if (tasks.Count(x => x is { IsDeleted: false, Status: TaskStatusEnum.Active }) == 20)
        {
            return (false, "There are 20 tasks created, maximum 20 tasks are allowed for project.");
        }

        // segue o fluxo
        var mapped = mapper.Map<TaskModel>(model);
        return (await repository.PostAsync(mapped), "Task Created Sussessfully");
    }

    public async Task<(bool, string)> PutAsync(int id, TaskRequest model)
    {
        var response = await GetAsync(id);
        if (response.Priority != model.Priority)
            return (false, "The priority of the task cannot be changed.");

        var mapped = mapper.Map<TaskModel>(response);
        mapped.ProjectId = model.ProjectId;
        mapped.Title = model.Title;
        mapped.Description = model.Description;
        mapped.DueDate = model.DueDate;
        mapped.Status = model.Status;
        return (await repository.PutAsync(mapped), "Successfully saved the task.");
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await repository.DeleteAsync(id);
    }

    public async Task<List<TaskDto>?> GetByProjectIdAsync(int projectId)
    {
        var response = await repository.GetByProjectIdAsync(projectId);
        return mapper.Map<List<TaskDto>>(response);
    }

    public async Task<List<PerformanceReport>> GetPerformanceReportAsynnc()
    {
        var response = repository.GetPerformanceReportAsync();
        return mapper.Map<List<PerformanceReport>>(response);

    }
}