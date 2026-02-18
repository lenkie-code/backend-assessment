using Microsoft.EntityFrameworkCore;

namespace BackendAssessment.Infrastructure.Persistence;

/// <summary>
/// Entity Framework Core database context for the application.
/// Manages the persistence of domain entities to PostgreSQL.
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
