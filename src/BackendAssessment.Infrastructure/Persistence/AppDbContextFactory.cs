using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace BackendAssessment.Infrastructure.Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
  public AppDbContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

    // hardcoded for local dev
    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=backendassessment;Username=postgres;Password=postgres");


    return new AppDbContext(optionsBuilder.Options);
  }
}