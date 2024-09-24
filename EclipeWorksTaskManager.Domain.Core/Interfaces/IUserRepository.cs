using EclipeWorksTaskManager.Domain.Core.Models;

namespace EclipeWorksTaskManager.Domain.Core.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<UserModel?>> GetListAsync();
    Task<UserModel?> GetAsync(int id);
    Task<bool> UserIsManager(string username);
}