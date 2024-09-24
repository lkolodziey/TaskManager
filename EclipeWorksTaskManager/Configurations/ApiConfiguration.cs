using EclipeWorksTaskManager.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EclipeWorksTaskManager.Configurations;

public class ApiConfiguration
{
    public void ConfigureServices(IServiceCollection services)
    {
        var mysqlConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        services.AddDbContext<DataContext>(options => options.UseNpgsql(mysqlConnectionString));
    }
}