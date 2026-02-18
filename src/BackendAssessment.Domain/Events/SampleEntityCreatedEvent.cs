using MediatR;

namespace BackendAssessment.Domain.Events;

/// <summary>
/// Domain event raised when a new <see cref="Entities.SampleEntity"/> is created.
/// This event is published via MassTransit to notify other parts of the system.
/// </summary>
/// <param name="EntityId">The unique identifier of the created entity.</param>
/// <param name="Email">The email associated with the created entity.</param>
public record SampleEntityCreatedEvent(Guid EntityId, string Email) : INotification;
