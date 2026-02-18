using BackendAssessment.Domain.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace BackendAssessment.Infrastructure.Messaging;

/// <summary>
/// MassTransit consumer for <see cref="SampleEntityCreatedEvent"/>.
/// Processes domain events published when a new sample entity is created.
///
/// Implementation steps:
/// 1. Log the receipt of the event including the EntityId and Email.
/// 2. Perform any side effects (e.g., send notification, update read model).
/// 3. Mark the message as consumed by completing the <see cref="ConsumeContext"/>.
///
/// Logging: Use structured logging to record event processing details.
/// </summary>
public class SampleEntityCreatedEventConsumer : IConsumer<SampleEntityCreatedEvent>
{
    private readonly ILogger<SampleEntityCreatedEventConsumer> _logger;

    public SampleEntityCreatedEventConsumer(ILogger<SampleEntityCreatedEventConsumer> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Consumes the <see cref="SampleEntityCreatedEvent"/> message.
    ///
    /// TODO: Implement the following:
    /// - Log the event receipt: _logger.LogInformation("Received SampleEntityCreatedEvent for {EntityId}", context.Message.EntityId)
    /// - Process any side effects (notifications, read model updates, etc.)
    /// </summary>
    public Task Consume(ConsumeContext<SampleEntityCreatedEvent> context)
    {
        throw new NotImplementedException();
    }
}
