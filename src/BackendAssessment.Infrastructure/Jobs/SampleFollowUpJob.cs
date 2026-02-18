using Microsoft.Extensions.Logging;

namespace BackendAssessment.Infrastructure.Jobs;

/// <summary>
/// Hangfire background job that performs a follow-up action for a sample entity.
/// Scheduled after entity creation to handle deferred processing.
///
/// This job should be scheduled in the <see cref="Application.Commands.CreateSampleCommandHandler"/>
/// using: <c>BackgroundJob.Enqueue&lt;SampleFollowUpJob&gt;(job =&gt; job.Execute(entityId))</c>
///
/// Implementation steps:
/// 1. Log a follow-up reminder for the given entity Id.
/// 2. Optionally perform additional processing (e.g., status checks, notifications).
/// </summary>
public class SampleFollowUpJob
{
    private readonly ILogger<SampleFollowUpJob> _logger;

    public SampleFollowUpJob(ILogger<SampleFollowUpJob> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Executes the follow-up job for the specified entity.
    ///
    /// TODO: Implement the following:
    /// - Log: _logger.LogInformation("Follow-up reminder for entity {EntityId}", entityId)
    /// - Perform any follow-up actions (status check, notification, etc.)
    /// </summary>
    public Task Execute(Guid entityId)
    {
        throw new NotImplementedException();
    }
}
