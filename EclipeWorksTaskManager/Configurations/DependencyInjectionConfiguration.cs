using EclipeWorksTaskManager.Domain.Core.Interfaces;
using EclipeWorksTaskManager.Infrastructure.Repositories;
using EclipeWorksTaskManager.Services.Interfaces;
using EclipeWorksTaskManager.Services.Services;

namespace EclipeWorksTaskManager.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        // Services
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<IUserService, UserService>();

        // Repositories
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}