using BackendAssessment.Domain.Entities;
using BackendAssessment.Domain.Interfaces;

namespace BackendAssessment.Infrastructure.Persistence;

/// <summary>
/// Repository implementation for <see cref="SampleEntity"/>.
/// Follows CQRS principles:
/// - Write operations (AddAsync) use Entity Framework Core for change tracking and transactional writes.
/// - Read operations (GetByIdAsync, GetAllAsync) use Dapper for lightweight, performant queries.
///
/// Dependencies:
/// - <see cref="AppDbContext"/> for EF Core write operations.
/// - A raw <c>NpgsqlConnection</c> (or <c>IDbConnection</c>) for Dapper read operations.
/// </summary>
public class SampleRepository : ISampleRepository
{
    private readonly AppDbContext _dbContext;

    public SampleRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Persists a new <see cref="SampleEntity"/> using Entity Framework Core.
    ///
    /// TODO: Implement the following:
    /// - Add entity to _dbContext.SampleEntities
    /// - Call _dbContext.SaveChangesAsync(cancellationToken)
    /// </summary>
    public Task AddAsync(SampleEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves a <see cref="SampleEntity"/> by Id using Dapper for optimized read performance.
    ///
    /// TODO: Implement the following:
    /// - Open a new NpgsqlConnection using the connection string from AppDbContext.Database
    /// - Execute a Dapper query: SELECT * FROM "SampleEntities" WHERE "Id" = @Id
    /// - Return the result or null if not found
    /// </summary>
    public Task<SampleEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves all <see cref="SampleEntity"/> records using Dapper for optimized read performance.
    ///
    /// TODO: Implement the following:
    /// - Open a new NpgsqlConnection using the connection string from AppDbContext.Database
    /// - Execute a Dapper query: SELECT * FROM "SampleEntities" ORDER BY "CreatedAt" DESC
    /// - Return the results
    /// </summary>
    public Task<IEnumerable<SampleEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
