using EclipeWorksTaskManager.Domain.Core.Interfaces;
using EclipeWorksTaskManager.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EclipeWorksTaskManager.Infrastructure.Repositories;

public class UserRepository(DataContext dataContext) : IUserRepository
{
    public async Task<IEnumerable<UserModel?>> GetListAsync()
    {
        return await dataContext.Users.ToListAsync();
    }

    public async Task<UserModel?> GetAsync(int id)
    {
        return await dataContext.Users.FindAsync(id);
    }

    public async Task<bool> UserIsManager(string username)
    {
        return await dataContext.Users.AnyAsync(x => x.Username == username && x.Role == "Manager");
    }
}