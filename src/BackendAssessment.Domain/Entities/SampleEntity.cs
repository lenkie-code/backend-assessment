using BackendAssessment.Domain.Events;
using BackendAssessment.Domain.ValueObjects;

namespace BackendAssessment.Domain.Entities;

/// <summary>
/// Represents a sample entity in the domain.
/// This entity demonstrates DDD principles including factory methods and domain events.
/// </summary>
public class SampleEntity
{
    private readonly List<object> _domainEvents = new();

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public decimal Amount { get; private set; }
    public SampleEntityStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Gets the domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<object> DomainEvents => _domainEvents.AsReadOnly();

    private SampleEntity() { }

    /// <summary>
    /// Factory method to create a new <see cref="SampleEntity"/>.
    /// Sets default values for Id, Status, and CreatedAt, and raises a <see cref="SampleEntityCreatedEvent"/>.
    /// </summary>
    /// <param name="name">The name of the entity.</param>
    /// <param name="email">The email associated with the entity.</param>
    /// <param name="amount">The monetary amount.</param>
    /// <returns>A new instance of <see cref="SampleEntity"/>.</returns>
    public static SampleEntity Create(string name, string email, decimal amount)
    {
        var entity = new SampleEntity
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email,
            Amount = amount,
            Status = SampleEntityStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };

        entity._domainEvents.Add(new SampleEntityCreatedEvent(entity.Id, entity.Email));

        return entity;
    }

    /// <summary>
    /// Clears all domain events from this entity.
    /// Should be called after events have been dispatched.
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();
}

/// <summary>
/// Represents the possible statuses for a <see cref="SampleEntity"/>.
/// </summary>
public enum SampleEntityStatus
{
    Pending,
    Approved,
    Rejected
}
