namespace BackendAssessment.Application.DTOs;

/// <summary>
/// Data transfer object representing the full details of a sample entity.
/// Used for returning entity data from query handlers.
/// </summary>
public record SampleDto(
    Guid Id,
    string Name,
    string Email,
    decimal Amount,
    string Status,
    DateTime CreatedAt
);
