using BackendAssessment.Domain.Interfaces;
using MassTransit;
using MediatR;

namespace BackendAssessment.Application.Commands;

/// <summary>
/// Handles the <see cref="CreateSampleCommand"/> by persisting a new entity and publishing a domain event.
///
/// Implementation steps:
/// 1. Create a new <see cref="Domain.Entities.SampleEntity"/> using the static factory method <c>SampleEntity.Create(...)</c>.
/// 2. Persist the entity using <see cref="ISampleRepository.AddAsync"/>.
/// 3. Publish the <see cref="Domain.Events.SampleEntityCreatedEvent"/> via MassTransit's <see cref="IPublishEndpoint"/>.
/// 4. Optionally schedule a follow-up job using Hangfire's <c>BackgroundJob.Enqueue</c> to invoke <c>SampleFollowUpJob.Execute</c>.
/// 5. Return the new entity's Id.
///
/// Logging: Add structured logging at the start and end of the handler using Serilog's <c>ILogger</c>.
/// </summary>
public class CreateSampleCommandHandler : IRequestHandler<CreateSampleCommand, Guid>
{
    private readonly ISampleRepository _repository;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateSampleCommandHandler(ISampleRepository repository, IPublishEndpoint publishEndpoint)
    {
        _repository = repository;
        _publishEndpoint = publishEndpoint;
    }

    /// <summary>
    /// Handles the command to create a new sample entity.
    ///
    /// TODO: Implement the following:
    /// - Create entity via SampleEntity.Create(request.Name, request.Email, request.Amount)
    /// - Save via _repository.AddAsync(entity, cancellationToken)
    /// - Publish domain event via _publishEndpoint.Publish(domainEvent, cancellationToken)
    /// - Schedule Hangfire job: BackgroundJob.Enqueue&lt;SampleFollowUpJob&gt;(job => job.Execute(entity.Id))
    /// - Return entity.Id
    /// </summary>
    public Task<Guid> Handle(CreateSampleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
