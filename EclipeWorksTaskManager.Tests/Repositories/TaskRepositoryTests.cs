using EclipeWorksTaskManager.Domain.Core.Interfaces;
using EclipeWorksTaskManager.Domain.Core.Models;
using Moq;

namespace EclipeWorksTaskManager.Tests.Repositories;

public class TaskRepositoryTests
{
    private readonly Mock<ITaskRepository> _taskRepositoryMock;

    public TaskRepositoryTests()
    {
        _taskRepositoryMock = new Mock<ITaskRepository>();
    }

    [Fact]
    public async Task GetListAsync_ShouldReturnTasks()
    {
        var tasks = new List<TaskModel> { new TaskModel
            {
                Id = 1,
                Title = "Task 1",
                DueDate = default
            }
        };
        _taskRepositoryMock.Setup(repo => repo.GetListAsync()).ReturnsAsync(tasks);

        var result = await _taskRepositoryMock.Object.GetListAsync();

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Task 1", result.First().Title);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnTask()
    {
        var task = new TaskModel
        {
            Id = 1,
            Title = "Task 1",
            DueDate = default
        };
        _taskRepositoryMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(task);

        var result = await _taskRepositoryMock.Object.GetAsync(1);

        Assert.NotNull(result);
        Assert.Equal("Task 1", result.Title);
    }

    [Fact]
    public async Task PostAsync_ShouldAddTask()
    {
        var task = new TaskModel
        {
            Title = "New Task",
            DueDate = default
        };
        _taskRepositoryMock.Setup(repo => repo.PostAsync(task)).ReturnsAsync(true);

        var result = await _taskRepositoryMock.Object.PostAsync(task);

        Assert.True(result);
    }

    [Fact]
    public async Task PutAsync_ShouldUpdateTask()
    {
        var task = new TaskModel
        {
            Id = 1,
            Title = "Updated Task",
            DueDate = default
        };
        _taskRepositoryMock.Setup(repo => repo.PutAsync(task)).ReturnsAsync(true);

        var result = await _taskRepositoryMock.Object.PutAsync(task);

        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveTask()
    {
        _taskRepositoryMock.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync(true);

        var result = await _taskRepositoryMock.Object.DeleteAsync(1);

        Assert.True(result);
    }

    [Fact]
    public async Task GetByProjectIdAsync_ShouldReturnTasks()
    {
        var projectId = 1;
        var tasks = new List<TaskModel> { new TaskModel
            {
                Id = 1,
                Title = "Task 1",
                DueDate = default
            }
        };
        _taskRepositoryMock.Setup(repo => repo.GetByProjectIdAsync(projectId)).ReturnsAsync(tasks);

        var result = await _taskRepositoryMock.Object.GetByProjectIdAsync(projectId);

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Task 1", result.First().Title);
    }

    [Fact]
    public async Task GetPerformanceReportAsync_ShouldReturnReport()
    {
        var report = new List<PerformanceReportModel> { new PerformanceReportModel { UserName = "user1", AverageTasksPerDay = 2 } };
        _taskRepositoryMock.Setup(repo => repo.GetPerformanceReportAsync()).ReturnsAsync(report);

        var result = await _taskRepositoryMock.Object.GetPerformanceReportAsync();

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("user1", result.First().UserName);
    }
}
