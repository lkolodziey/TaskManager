using EclipeWorksTaskManager.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EclipeWorksTaskManager.Infrastructure;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> contextOptions) : base(contextOptions)
    {
    }

    public DbSet<CommentModel> Comments { get; set; }
    public DbSet<ProjectModel> Projects { get; set; }
    public DbSet<TaskModel> Tasks { get; set; }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<ChangeLog> ChangeLogs { get; set; }

    public override int SaveChanges()
    {
        AddChangeLogs();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddChangeLogs();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void AddChangeLogs()
    {
        var modifiedEntries = ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Modified)
            .ToList();

        foreach (var entry in modifiedEntries)
        {
            var entityName = entry.Entity.GetType().Name;
            var userIdProperty =
                entry.CurrentValues.Properties.FirstOrDefault(p =>
                    p.Name.Equals("UserId", StringComparison.OrdinalIgnoreCase));

            if (userIdProperty == null)
                continue;

            var userId = entry.CurrentValues[userIdProperty]?.ToString();

            foreach (var property in entry.OriginalValues.Properties)
            {
                var originalValue = entry.OriginalValues[property]?.ToString();
                var currentValue = entry.CurrentValues[property]?.ToString();

                if (originalValue == currentValue) continue;

                var changeLog = new ChangeLog
                {
                    EntityName = entityName,
                    PropertyName = property.Name,
                    OriginalValue = originalValue,
                    NewValue = currentValue,
                    ModifiedAt = DateTime.UtcNow,
                    UserId = userId is not null ? int.Parse(userId) : 0
                };

                ChangeLogs.Add(changeLog);
            }
        }
    }
}