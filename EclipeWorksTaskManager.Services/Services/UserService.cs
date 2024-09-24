using AutoMapper;
using EclipeWorksTaskManager.Domain.Core.Interfaces;
using EclipeWorksTaskManager.Services.DataObjects;
using EclipeWorksTaskManager.Services.Interfaces;

namespace EclipeWorksTaskManager.Services.Services;

public class UserService(IMapper mapper, IUserRepository repository) : IUserService
{
    public async Task<List<User>?> GetListAsync()
    {
        var response = await repository.GetListAsync();
        return mapper.Map<List<User>>(response);
    }

    public async Task<User?> GetAsync(int id)
    {
        var response = await repository.GetAsync(id);
        return mapper.Map<User>(response);
    }

    public async Task<bool> UserIsManager(string username)
    {
        return await repository.UserIsManager(username);
    }
}