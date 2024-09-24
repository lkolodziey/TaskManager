using EclipeWorksTaskManager.Services.DataObjects;
using EclipeWorksTaskManager.Services.DataObjects.Requests;
using EclipeWorksTaskManager.Services.Interfaces;
using Moq;

namespace EclipeWorksTaskManager.Tests.Services;

public class ProjectServiceTests
{
    private readonly Mock<IProjectService> _projectServiceMock = new();

    [Fact]
    public async Task GetListAsync_ShouldReturnProjects()
    {
        var projects = new List<Project> { new Project
            {
                Id = 1,
                Name = "Project 1",
                UserId = 1
            }
        };
        _projectServiceMock.Setup(service => service.GetListAsync()).ReturnsAsync(projects);

        var result = await _projectServiceMock.Object.GetListAsync();

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Project 1", result[0].Name);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnProject()
    {
        var project = new Project
        {
            Id = 1,
            Name = "Project 1",
            UserId = 1
        };
        _projectServiceMock.Setup(service => service.GetAsync(1)).ReturnsAsync(project);

        var result = await _projectServiceMock.Object.GetAsync(1);

        Assert.NotNull(result);
        Assert.Equal("Project 1", result.Name);
    }

    [Fact]
    public async Task PostAsync_ShouldAddProject()
    {
        var projectRequest = new ProjectRequest
        {
            Name = "New Project",
            UserId = 1
        };
        _projectServiceMock.Setup(service => service.PostAsync(projectRequest)).ReturnsAsync(true);

        var result = await _projectServiceMock.Object.PostAsync(projectRequest);

        Assert.True(result);
    }

    [Fact]
    public async Task PutAsync_ShouldUpdateProject()
    {
        var projectRequest = new ProjectRequest
        {
            Name = "Updated Project",
            UserId = 1
        };
        _projectServiceMock.Setup(service => service.PutAsync(1, projectRequest)).ReturnsAsync(true);

        var result = await _projectServiceMock.Object.PutAsync(1, projectRequest);

        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveProject()
    {
        _projectServiceMock.Setup(service => service.DeleteAsync(1)).ReturnsAsync((true, "Deleted"));

        var (success, message) = await _projectServiceMock.Object.DeleteAsync(1);

        Assert.True(success);
        Assert.Equal("Deleted", message);
    }
}