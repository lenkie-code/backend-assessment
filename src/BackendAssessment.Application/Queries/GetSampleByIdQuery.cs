using BackendAssessment.Application.DTOs;
using MediatR;

namespace BackendAssessment.Application.Queries;

/// <summary>
/// Query to retrieve a sample entity by its unique identifier.
/// Follows CQRS pattern — this query represents a read operation.
/// </summary>
/// <param name="Id">The unique identifier of the entity to retrieve.</param>
public record GetSampleByIdQuery(Guid Id) : IRequest<SampleDto>;
