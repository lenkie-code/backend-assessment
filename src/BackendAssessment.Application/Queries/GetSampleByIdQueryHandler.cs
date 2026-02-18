using BackendAssessment.Application.DTOs;
using BackendAssessment.Domain.Interfaces;
using MediatR;

namespace BackendAssessment.Application.Queries;

/// <summary>
/// Handles the <see cref="GetSampleByIdQuery"/> by retrieving an entity from the data store.
///
/// Implementation steps:
/// 1. Use <see cref="ISampleRepository.GetByIdAsync"/> to fetch the entity.
///    Note: The repository read methods should use Dapper for optimized read performance (CQRS read side).
/// 2. Map the <see cref="Domain.Entities.SampleEntity"/> to a <see cref="SampleDto"/>.
/// 3. Return the DTO, or throw an appropriate exception if the entity is not found.
///
/// Logging: Add structured logging for query execution and not-found scenarios using Serilog's <c>ILogger</c>.
/// </summary>
public class GetSampleByIdQueryHandler : IRequestHandler<GetSampleByIdQuery, SampleDto>
{
    private readonly ISampleRepository _repository;

    public GetSampleByIdQueryHandler(ISampleRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the query to retrieve a sample entity by Id.
    ///
    /// TODO: Implement the following:
    /// - Fetch entity via _repository.GetByIdAsync(request.Id, cancellationToken)
    /// - Map to SampleDto (Id, Name, Email, Amount, Status, CreatedAt)
    /// - Return the DTO or throw KeyNotFoundException if not found
    /// </summary>
    public Task<SampleDto> Handle(GetSampleByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
