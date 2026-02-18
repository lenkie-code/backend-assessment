using BackendAssessment.Application.Commands;
using BackendAssessment.Application.DTOs;
using BackendAssessment.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackendAssessment.Api.Controllers;

/// <summary>
/// API controller for managing sample entities.
/// Uses MediatR v14's ISender to dispatch commands and queries following the CQRS pattern.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SampleController : ControllerBase
{
    private readonly ISender _sender;

    public SampleController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Creates a new sample entity.
    /// Dispatches a <see cref="CreateSampleCommand"/> via MediatR.
    /// </summary>
    /// <param name="command">The command containing entity details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The Id of the newly created entity.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateSampleCommand command, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    /// <summary>
    /// Retrieves a sample entity by its unique identifier.
    /// Dispatches a <see cref="GetSampleByIdQuery"/> via MediatR.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The sample entity details.</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SampleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetSampleByIdQuery(id), cancellationToken);
        return Ok(result);
    }
}
