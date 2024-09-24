using EclipeWorksTaskManager.Services.DataObjects;
using EclipeWorksTaskManager.Services.DataObjects.Requests;
using EclipeWorksTaskManager.Services.Interfaces;
using Moq;

namespace EclipeWorksTaskManager.Tests.Services;

public class TaskServiceTests
{
    private readonly Mock<ITaskService> _taskServiceMock;

    public TaskServiceTests()
    {
        _taskServiceMock = new Mock<ITaskService>();
    }

    [Fact]
    public async Task GetListAsync_ShouldReturnTasks()
    {
        var tasks = new List<TaskDto> { new TaskDto
            {
                Id = 1,
                Title = "Task 1",
                ProjectId = 1,
                UserId = 1,
                DueDate = DateTime.UtcNow
            }
        };
        _taskServiceMock.Setup(service => service.GetListAsync()).ReturnsAsync(tasks);

        var result = await _taskServiceMock.Object.GetListAsync();

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Task 1", result[0].Title);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnTask()
    {
        var task = new TaskDto
        {
            Id = 1,
            Title = "Task 1",
            ProjectId = 1,
            UserId = 1,
            DueDate = DateTime.UtcNow
        };
        _taskServiceMock.Setup(service => service.GetAsync(1)).ReturnsAsync(task);

        var result = await _taskServiceMock.Object.GetAsync(1);

        Assert.NotNull(result);
        Assert.Equal("Task 1", result.Title);
    }

    [Fact]
    public async Task PostAsync_ShouldAddTask()
    {
        var taskRequest = new TaskRequest
        {
            Title = "New Task",
            ProjectId = 1,
            DueDate = DateTime.UtcNow
        };
        _taskServiceMock.Setup(service => service.PostAsync(taskRequest)).ReturnsAsync((true, "Added"));

        var (success, message) = await _taskServiceMock.Object.PostAsync(taskRequest);

        Assert.True(success);
        Assert.Equal("Added", message);
    }

    [Fact]
    public async Task PutAsync_ShouldUpdateTask()
    {
        var taskRequest = new TaskRequest
        {
            Title = "Updated Task",
            ProjectId = 1,
            DueDate = DateTime.UtcNow
        };
        _taskServiceMock.Setup(service => service.PutAsync(1, taskRequest)).ReturnsAsync((true, "Updated"));

        var (success, message) = await _taskServiceMock.Object.PutAsync(1, taskRequest);

        Assert.True(success);
        Assert.Equal("Updated", message);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveTask()
    {
        _taskServiceMock.Setup(service => service.DeleteAsync(1)).ReturnsAsync(true);

        var result = await _taskServiceMock.Object.DeleteAsync(1);

        Assert.True(result);
    }

    [Fact]
    public async Task GetPerformanceReportAsync_ShouldReturnReport()
    {
        var report = new List<PerformanceReport> { new PerformanceReport { UserName = "user1", AverageTasksPerDay = 2 } };
        _taskServiceMock.Setup(service => service.GetPerformanceReportAsynnc()).ReturnsAsync(report);

        var result = await _taskServiceMock.Object.GetPerformanceReportAsynnc();

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("user1", result[0].UserName);
    }
}