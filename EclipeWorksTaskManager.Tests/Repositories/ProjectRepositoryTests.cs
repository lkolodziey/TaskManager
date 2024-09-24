using EclipeWorksTaskManager.Domain.Core.Interfaces;
using EclipeWorksTaskManager.Domain.Core.Models;
using Moq;

namespace EclipeWorksTaskManager.Tests.Repositories;

public class ProjectRepositoryTests
{
    private readonly Mock<IProjectRepository> _projectRepositoryMock;

    public ProjectRepositoryTests()
    {
        _projectRepositoryMock = new Mock<IProjectRepository>();
    }

    [Fact]
    public async Task GetListAsync_ShouldReturnProjects()
    {
        var projects = new List<ProjectModel> { new ProjectModel { Id = 1, Name = "Project 1" } };
        _projectRepositoryMock.Setup(repo => repo.GetListAsync()).ReturnsAsync(projects);

        var result = await _projectRepositoryMock.Object.GetListAsync();

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Project 1", result.First().Name);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnProject()
    {
        var project = new ProjectModel { Id = 1, Name = "Project 1" };
        _projectRepositoryMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(project);

        var result = await _projectRepositoryMock.Object.GetAsync(1);

        Assert.NotNull(result);
        Assert.Equal("Project 1", result.Name);
    }

    [Fact]
    public async Task PostAsync_ShouldAddProject()
    {
        var project = new ProjectModel { Name = "New Project" };
        _projectRepositoryMock.Setup(repo => repo.PostAsync(project)).ReturnsAsync(true);

        var result = await _projectRepositoryMock.Object.PostAsync(project);

        Assert.True(result);
    }

    [Fact]
    public async Task PutAsync_ShouldUpdateProject()
    {
        var project = new ProjectModel { Id = 1, Name = "Updated Project" };
        _projectRepositoryMock.Setup(repo => repo.PutAsync(project)).ReturnsAsync(true);

        var result = await _projectRepositoryMock.Object.PutAsync(project);

        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveProject()
    {
        _projectRepositoryMock.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync(true);

        var result = await _projectRepositoryMock.Object.DeleteAsync(1);

        Assert.True(result);
    }
}
