using EclipeWorksTaskManager.Domain.Core.Interfaces;
using EclipeWorksTaskManager.Domain.Core.Models;
using Moq;

namespace EclipeWorksTaskManager.Tests.Repositories;

public class CommentRepositoryTests
{
    private readonly Mock<ICommentRepository> _commentRepositoryMock;

    public CommentRepositoryTests()
    {
        _commentRepositoryMock = new Mock<ICommentRepository>();
    }

    [Fact]
    public async Task GetListAsync_ShouldReturnComments()
    {
        var expectedComments = new List<CommentModel> { new CommentModel
            {
                Id = 1,
                Text = "Test comment",
                TaskId = 0,
                UserId = 0
            }
        };
        _commentRepositoryMock.Setup(repo => repo.GetListAsync()).ReturnsAsync(expectedComments);

        var result = await _commentRepositoryMock.Object.GetListAsync();

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Test comment", result.First().Text);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnComment()
    {
        var comment = new CommentModel
        {
            Id = 1,
            Text = "Test comment",
            TaskId = 0,
            UserId = 0
        };
        _commentRepositoryMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(comment);

        var result = await _commentRepositoryMock.Object.GetAsync(1);

        Assert.NotNull(result);
        Assert.Equal("Test comment", result.Text);
    }

    [Fact]
    public async Task PostAsync_ShouldAddComment()
    {
        var comment = new CommentModel
        {
            Text = "New Comment",
            TaskId = 0,
            UserId = 0
        };
        _commentRepositoryMock.Setup(repo => repo.PostAsync(comment)).ReturnsAsync(true);

        var result = await _commentRepositoryMock.Object.PostAsync(comment);

        Assert.True(result);
    }

    [Fact]
    public async Task PutAsync_ShouldUpdateComment()
    {
        var comment = new CommentModel
        {
            Id = 1,
            Text = "Updated Comment",
            TaskId = 0,
            UserId = 0
        };
        _commentRepositoryMock.Setup(repo => repo.PutAsync(comment)).ReturnsAsync(true);

        var result = await _commentRepositoryMock.Object.PutAsync(comment);

        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveComment()
    {
        _commentRepositoryMock.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync(true);

        var result = await _commentRepositoryMock.Object.DeleteAsync(1);

        Assert.True(result);
    }
}
