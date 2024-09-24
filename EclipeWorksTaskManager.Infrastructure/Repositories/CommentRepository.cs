using EclipeWorksTaskManager.Domain.Core.Interfaces;
using EclipeWorksTaskManager.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EclipeWorksTaskManager.Infrastructure.Repositories;

public class CommentRepository(DataContext dataContext) : ICommentRepository
{
    public async Task<IEnumerable<CommentModel>?> GetListAsync()
    {
        return await dataContext.Comments.Where(x => !x.IsDeleted).ToListAsync();
    }

    public async Task<CommentModel?> GetAsync(int id)
    {
        return await dataContext.Comments.FindAsync(id);
    }

    public async Task<bool> PostAsync(CommentModel model)
    {
        dataContext.Comments.Add(model);
        var result = await dataContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> PutAsync(CommentModel model)
    {
        dataContext.Comments.Update(model);
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