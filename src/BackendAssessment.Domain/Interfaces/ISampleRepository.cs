using BackendAssessment.Domain.Entities;

namespace BackendAssessment.Domain.Interfaces;

/// <summary>
/// Repository interface for <see cref="SampleEntity"/> persistence operations.
/// Follows the Repository pattern to abstract data access from the domain layer.
/// </summary>
public interface ISampleRepository
{
    /// <summary>
    /// Persists a new <see cref="SampleEntity"/> to the data store.
    /// Implementation should use Entity Framework Core for write operations.
    /// </summary>
    Task AddAsync(SampleEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a <see cref="SampleEntity"/> by its unique identifier.
    /// Implementation should use Dapper for optimized read queries.
    /// </summary>
    Task<SampleEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all <see cref="SampleEntity"/> records from the data store.
    /// Implementation should use Dapper for optimized read queries.
    /// </summary>
    Task<IEnumerable<SampleEntity>> GetAllAsync(CancellationToken cancellationToken = default);
}
