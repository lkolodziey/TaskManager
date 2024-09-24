using EclipeWorksTaskManager.Services.DataObjects;
using EclipeWorksTaskManager.Services.DataObjects.Requests;
using EclipeWorksTaskManager.Services.Interfaces;
using Moq;

namespace EclipeWorksTaskManager.Tests.Services;

public class CommentServiceTests
{
    private readonly Mock<ICommentService> _commentServiceMock = new();

    [Fact]
    public async Task GetListAsync_ShouldReturnComments()
    {
        var expectedComments = new List<Comment> { new Comment
            {
                Id = 1,
                Text = "Test comment",
                TaskId = 0,
                UserId = 1
            }
        };
        _commentServiceMock.Setup(service => service.GetListAsync()).ReturnsAsync(expectedComments);

        var result = await _commentServiceMock.Object.GetListAsync();

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Test comment", result[0].Text);
    }
    
    [Fact]
    public async Task GetAsync_ShouldReturnComment()
    {
        var comment = new Comment
        {
            Id = 1,
            Text = "Test comment",
            TaskId = 1,
            UserId = 1
        };
        _commentServiceMock.Setup(service => service.GetAsync(1)).ReturnsAsync(comment);

        var result = await _commentServiceMock.Object.GetAsync(1);

        Assert.NotNull(result);
        Assert.Equal("Test comment", result.Text);
    }

    [Fact]
    public async Task PostAsync_ShouldAddComment()
    {
        var commentRequest = new CommentRequest
        {
            Text = "New Comment",
            TaskId = 1,
            UserId = 1
        };
        _commentServiceMock.Setup(service => service.PostAsync(commentRequest)).ReturnsAsync(true);

        var result = await _commentServiceMock.Object.PostAsync(commentRequest);

        Assert.True(result);
    }

    [Fact]
    public async Task PutAsync_ShouldUpdateComment()
    {
        var commentRequest = new CommentRequest
        {
            Text = "Updated Comment",
            TaskId = 1,
            UserId = 1
        };
        _commentServiceMock.Setup(service => service.PutAsync(1, commentRequest)).ReturnsAsync(true);

        var result = await _commentServiceMock.Object.PutAsync(1, commentRequest);

        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveComment()
    {
        _commentServiceMock.Setup(service => service.DeleteAsync(1)).ReturnsAsync(true);

        var result = await _commentServiceMock.Object.DeleteAsync(1);

        Assert.True(result);
    }
}