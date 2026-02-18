using BackendAssessment.Domain.Entities;
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

    /// <summary>
    /// DbSet for <see cref="SampleEntity"/> — maps to the "SampleEntities" table in PostgreSQL.
    /// </summary>
    public DbSet<SampleEntity> SampleEntities => Set<SampleEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SampleEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Amount).HasPrecision(18, 2);
            entity.Property(e => e.Status)
                .HasConversion<string>()
                .HasMaxLength(50);
            entity.Property(e => e.CreatedAt).IsRequired();

            // Ignore domain events — they are not persisted
            entity.Ignore(e => e.DomainEvents);
        });
    }
}
