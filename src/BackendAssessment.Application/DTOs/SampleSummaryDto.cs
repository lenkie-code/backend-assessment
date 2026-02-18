namespace BackendAssessment.Application.DTOs;

/// <summary>
/// Lightweight data transfer object for summary views of a sample entity.
/// Used in list/collection endpoints where full details are not needed.
/// </summary>
public record SampleSummaryDto(
    Guid Id,
    string Name,
    string Status
);
