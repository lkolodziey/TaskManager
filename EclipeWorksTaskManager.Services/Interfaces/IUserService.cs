using EclipeWorksTaskManager.Services.DataObjects;

namespace EclipeWorksTaskManager.Services.Interfaces;

public interface IUserService
{
    Task<List<User>?> GetListAsync();
    Task<User?> GetAsync(int id);
    Task<bool> UserIsManager(string username);
}