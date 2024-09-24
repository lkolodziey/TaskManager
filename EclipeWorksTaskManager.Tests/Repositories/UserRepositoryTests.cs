using EclipeWorksTaskManager.Domain.Core.Interfaces;
using EclipeWorksTaskManager.Domain.Core.Models;
using Moq;

namespace EclipeWorksTaskManager.Tests.Repositories;

public class UserRepositoryTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;

    public UserRepositoryTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
    }

    [Fact]
    public async Task GetListAsync_ShouldReturnUsers()
    {
        var users = new List<UserModel> { new UserModel { Id = 1, Username = "user1", Role = "User" } };
        _userRepositoryMock.Setup(repo => repo.GetListAsync()).ReturnsAsync(users);

        var result = await _userRepositoryMock.Object.GetListAsync();

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("user1", result.First().Username);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnUser()
    {
        var user = new UserModel
        {
            Id = 1,
            Username = "user1",
            Role = "User"
        };
        _userRepositoryMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(user);

        var result = await _userRepositoryMock.Object.GetAsync(1);

        Assert.NotNull(result);
        Assert.Equal("user1", result.Username);
    }

    [Fact]
    public async Task UserIsManager_ShouldReturnTrue_WhenUserIsManager()
    {
        var username = "managerUser";
        _userRepositoryMock.Setup(repo => repo.UserIsManager(username)).ReturnsAsync(true);

        var result = await _userRepositoryMock.Object.UserIsManager(username);

        Assert.True(result);
    }

    [Fact]
    public async Task UserIsManager_ShouldReturnFalse_WhenUserIsNotManager()
    {
        var username = "regularUser";
        _userRepositoryMock.Setup(repo => repo.UserIsManager(username)).ReturnsAsync(false);

        var result = await _userRepositoryMock.Object.UserIsManager(username);

        Assert.False(result);
    }
}