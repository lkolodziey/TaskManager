using EclipeWorksTaskManager.Domain.Core.Enumerators;
using EclipeWorksTaskManager.Domain.Core.Interfaces;
using EclipeWorksTaskManager.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EclipeWorksTaskManager.Infrastructure.Repositories;

public class ProjectRepository(DataContext dataContext) : IProjectRepository
{
    public async Task<IEnumerable<ProjectModel>?> GetListAsync()
    {
        return await dataContext.Projects.Where(x => !x.IsDeleted).ToListAsync();
    }

    public async Task<ProjectModel?> GetAsync(int id)
    {
        return await dataContext.Projects.FindAsync(id);
    }

    public async Task<bool> PostAsync(ProjectModel model)
    {
        dataContext.Projects.Add(model);
        var result = await dataContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> PutAsync(ProjectModel model)
    {
        dataContext.Projects.Update(model);
        var result = await dataContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await GetAsync(id);
        item.IsDeleted = true;
        return await PutAsync(item);
    }
}