using MediatR;

namespace BackendAssessment.Application.Commands;

/// <summary>
/// Command to create a new sample entity.
/// Follows CQRS pattern — this command represents a write operation.
/// </summary>
/// <param name="Name">The name for the new entity.</param>
/// <param name="Email">The email associated with the new entity.</param>
/// <param name="Amount">The monetary amount for the new entity.</param>
public record CreateSampleCommand(string Name, string Email, decimal Amount) : IRequest<Guid>;
