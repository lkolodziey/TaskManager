using AutoMapper;
using EclipeWorksTaskManager.Domain.Core.Models;
using EclipeWorksTaskManager.Services.DataObjects;
using EclipeWorksTaskManager.Services.DataObjects.Requests;


namespace EclipeWorksTaskManager.Configurations;

public static class MapperConfig
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Comment, CommentModel>().ReverseMap();
            cfg.CreateMap<Project, ProjectModel>().ReverseMap();
            cfg.CreateMap<TaskDto, TaskModel>().ReverseMap();
            cfg.CreateMap<User, UserModel>().ReverseMap();
            
            
            cfg.CreateMap<CommentRequest, CommentModel>().ReverseMap();
            cfg.CreateMap<ProjectRequest, ProjectModel>().ReverseMap();
            cfg.CreateMap<TaskRequest, TaskModel>().ReverseMap();
            
            cfg.CreateMap<PerformanceReport, PerformanceReportModel>().ReverseMap();
            
            
        });
        return services.AddSingleton(config.CreateMapper());
    }
}