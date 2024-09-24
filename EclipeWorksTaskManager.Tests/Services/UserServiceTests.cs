using EclipeWorksTaskManager.Services.DataObjects;
using EclipeWorksTaskManager.Services.Interfaces;
using Moq;

namespace EclipeWorksTaskManager.Tests.Services;

public class UserServiceTests
{
    private readonly Mock<IUserService> _userServiceMock;

    public UserServiceTests()
    {
        _userServiceMock = new Mock<IUserService>();
    }

    [Fact]
    public async Task GetListAsync_ShouldReturnUsers()
    {
        var users = new List<User>
        {
            new User
            {
                Id = 1,
                Username = "user1",
                Role = "Manager"
            }
        };
        _userServiceMock.Setup(service => service.GetListAsync()).ReturnsAsync(users);

        var result = await _userServiceMock.Object.GetListAsync();

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("user1", result[0].Username);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnUser()
    {
        var user = new User { Id = 1, Username = "user1", Role = "Manager" };
        _userServiceMock.Setup(service => service.GetAsync(1)).ReturnsAsync(user);

        var result = await _userServiceMock.Object.GetAsync(1);

        Assert.NotNull(result);
        Assert.Equal("user1", result.Username);
    }

    [Fact]
    public async Task UserIsManager_ShouldReturnTrue_WhenUserIsManager()
    {
        var username = "managerUser";
        _userServiceMock.Setup(service => service.UserIsManager(username)).ReturnsAsync(true);

        var result = await _userServiceMock.Object.UserIsManager(username);

        Assert.True(result);
    }

    [Fact]
    public async Task UserIsManager_ShouldReturnFalse_WhenUserIsNotManager()
    {
        var username = "regularUser";
        _userServiceMock.Setup(service => service.UserIsManager(username)).ReturnsAsync(false);

        var result = await _userServiceMock.Object.UserIsManager(username);

        Assert.False(result);
    }
}