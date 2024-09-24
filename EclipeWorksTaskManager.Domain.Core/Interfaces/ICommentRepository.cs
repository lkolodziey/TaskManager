using EclipeWorksTaskManager.Domain.Core.Models;

namespace EclipeWorksTaskManager.Domain.Core.Interfaces;

public interface ICommentRepository
{
    Task<IEnumerable<CommentModel>?> GetListAsync();
    Task<CommentModel?> GetAsync(int id);
    Task<bool> PostAsync(CommentModel model);
    Task<bool> PutAsync(CommentModel model);
    Task<bool> DeleteAsync(int id);
}