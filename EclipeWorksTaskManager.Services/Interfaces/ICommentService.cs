using EclipeWorksTaskManager.Services.DataObjects;
using EclipeWorksTaskManager.Services.DataObjects.Requests;

namespace EclipeWorksTaskManager.Services.Interfaces;

public interface ICommentService
{
    Task<List<Comment>?> GetListAsync();
    Task<Comment?> GetAsync(int id);
    Task<bool> PostAsync(CommentRequest model);
    Task<bool> PutAsync(int id, CommentRequest model);
    Task<bool> DeleteAsync(int id);
}