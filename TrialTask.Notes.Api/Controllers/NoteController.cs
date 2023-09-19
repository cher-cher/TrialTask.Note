using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using TrialTask.Notes.Application.Notes.Commands;
using TrialTask.Notes.Application.Notes.Queries;

namespace TrialTask.Notes.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoteController : ControllerBase
{
    private readonly IMediator _mediator;

    public NoteController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoItem(int id)
    {
        var query = new GetNote(id);
        var note = await _mediator.Send(query);

        return Ok(note);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(int id, [FromBody] UpdateNote command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNote(int id)
    {
        var command = new DeleteNote(id);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNotes()
    {
        var query = new GetAllNotes();
        var notes = await _mediator.Send(query);
        return Ok(notes);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] CreateNote note)
    {
        var noteId = await _mediator.Send(note);
        return CreatedAtAction(nameof(GetTodoItem), new { id = noteId }, null);
    }

}
