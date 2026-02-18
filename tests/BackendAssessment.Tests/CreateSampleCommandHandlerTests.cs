using BackendAssessment.Application.Commands;
using BackendAssessment.Domain.Events;
using BackendAssessment.Domain.Interfaces;
using FluentAssertions;
using MassTransit;
using NSubstitute;

namespace BackendAssessment.Tests;

/// <summary>
/// Unit tests for <see cref="CreateSampleCommandHandler"/>.
/// Uses NSubstitute for mocking dependencies and FluentAssertions for expressive assertions.
/// </summary>
public class CreateSampleCommandHandlerTests
{
    private readonly ISampleRepository _repository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly CreateSampleCommandHandler _handler;

    public CreateSampleCommandHandlerTests()
    {
        _repository = Substitute.For<ISampleRepository>();
        _publishEndpoint = Substitute.For<IPublishEndpoint>();
        _handler = new CreateSampleCommandHandler(_repository, _publishEndpoint);
    }

    /// <summary>
    /// Tests that a valid command results in:
    /// 1. The entity being persisted via the repository's AddAsync method.
    /// 2. A <see cref="SampleEntityCreatedEvent"/> being published via MassTransit's IPublishEndpoint.
    ///
    /// Arrange: Create a valid CreateSampleCommand with Name, Email, and Amount.
    /// Act: Call _handler.Handle(command, CancellationToken.None).
    /// Assert:
    ///   - _repository.Received(1).AddAsync(Arg.Any&lt;SampleEntity&gt;(), Arg.Any&lt;CancellationToken&gt;())
    ///   - _publishEndpoint.Received(1).Publish(Arg.Any&lt;SampleEntityCreatedEvent&gt;(), Arg.Any&lt;CancellationToken&gt;())
    /// </summary>
    [Fact]
    public async Task Handle_ValidCommand_ShouldSaveEntityAndPublishEvent()
    {
        // Implement test here
        throw new NotImplementedException();
    }

    /// <summary>
    /// Tests that the returned Id matches the persisted entity's Id.
    ///
    /// Arrange: Create a valid CreateSampleCommand.
    /// Act: Call _handler.Handle(command, CancellationToken.None) and capture the returned Guid.
    /// Assert:
    ///   - The returned Guid should not be Guid.Empty.
    ///   - The entity passed to _repository.AddAsync should have the same Id as the returned value.
    ///     Use: _repository.Received(1).AddAsync(Arg.Is&lt;SampleEntity&gt;(e => e.Id == result), ...)
    /// </summary>
    [Fact]
    public async Task Handle_ValidCommand_ShouldReturnEntityId()
    {
        // Implement test here
        throw new NotImplementedException();
    }
}
