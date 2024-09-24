using AutoMapper;
using EclipeWorksTaskManager.Domain.Core.Interfaces;
using EclipeWorksTaskManager.Domain.Core.Models;
using EclipeWorksTaskManager.Services.DataObjects;
using EclipeWorksTaskManager.Services.DataObjects.Requests;
using EclipeWorksTaskManager.Services.Interfaces;

namespace EclipeWorksTaskManager.Services.Services;

public class CommentService(IMapper mapper, ICommentRepository repository) : ICommentService
{
    public async Task<List<Comment>?> GetListAsync()
    {
        var response = await repository.GetListAsync();
        return mapper.Map<List<Comment>>(response);
    }

    public async Task<Comment?> GetAsync(int id)
    {
        var response = await repository.GetAsync(id);
        return mapper.Map<Comment>(response);
    }

    public async Task<bool> PostAsync(CommentRequest model)
    {
        var mapped = mapper.Map<CommentModel>(model);
        return await repository.PostAsync(mapped);
    }

    public async Task<bool> PutAsync(int id, CommentRequest model)
    {
        var mapped = mapper.Map<CommentModel>(model);
        return await repository.PutAsync(mapped);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await repository.DeleteAsync(id);
    }
}