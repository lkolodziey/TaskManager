using EclipeWorksTaskManager.Domain.Core.Enumerators;
using EclipeWorksTaskManager.Domain.Core.Interfaces;
using EclipeWorksTaskManager.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EclipeWorksTaskManager.Infrastructure.Repositories;

public class TaskRepository(DataContext dataContext) : ITaskRepository
{
    public async Task<IEnumerable<TaskModel>?> GetListAsync()
    {
        return await dataContext.Tasks.Where(x => !x.IsDeleted).ToListAsync();
    }

    public async Task<TaskModel?> GetAsync(int id)
    {
        return await dataContext.Tasks.FindAsync(id);
    }

    public async Task<bool> PostAsync(TaskModel model)
    {
        model.DueDate = DateTime.SpecifyKind(model.DueDate, DateTimeKind.Utc);
        dataContext.Tasks.Add(model);
        var result = await dataContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> PutAsync(TaskModel model)
    {
        dataContext.Tasks.Update(model);
        var result = await dataContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await GetAsync(id);
        item.IsDeleted = true;
        return await PutAsync(item);
    }

    public async Task<IEnumerable<TaskModel>?> GetByProjectIdAsync(int projectId)
    {
        return await dataContext.Tasks.Where(x => x.ProjectId == projectId && !x.IsDeleted).ToListAsync();
    }

    public async Task<List<PerformanceReportModel>> GetPerformanceReportAsync()
    {
        var daysAverage = 30.0;
        return await dataContext.Tasks
            .Where(t => t.Status == TaskStatusEnum.Completed &&
                        t.DueDate >= DateTime.UtcNow.AddDays(daysAverage * -1))
            .GroupBy(t => t.UserId)
            .Select(g => new PerformanceReportModel
            {
                UserName = dataContext.Users.FirstOrDefault(u => u.Id == g.Key)!.Username,
                CompletedTasks = g.Count(),
                AverageTasksPerDay = g.Count() / daysAverage
            }).ToListAsync();
    }
}