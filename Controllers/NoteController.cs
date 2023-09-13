using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrialTask.Notes.Models;

namespace TrialTask.Notes.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoteController : ControllerBase
{
    private readonly NoteContext _context;

    public NoteController(NoteContext context)
    {
        _context = context;
    }

    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<NoteDto>>> GetNotes()
    {
        return await _context.Notes
            .Select(x => ItemToDto(x))
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NoteDto>> GetTodoItem(int id)
    {
        var todoItem = await _context.Notes.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return ItemToDto(todoItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(int id, NoteDto noteDto)
    {
        if (id != noteDto.Id)
        {
            return BadRequest();
        }

        var todoItem = await _context.Notes.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        todoItem.Title = noteDto.Title;
        todoItem.Text = noteDto.Text;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!NoteExists(id))
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<NoteDto>> CreateNote(NoteDto noteDto)
    {
        var note = new Note
        {
            Title = noteDto.Title,
            Text = noteDto.Text,
            IsPrivate = false
        };

        _context.Notes.Add(note);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetTodoItem),
            new { id = note.Id },
            ItemToDto(note));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNote(int id)
    {
        var todoItem = await _context.Notes.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        _context.Notes.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool NoteExists(int id) => _context.Notes.Any(e => e.Id == id);

    private static NoteDto ItemToDto(Note note) =>
        new NoteDto
        {
            Id = note.Id,
            Title = note.Title,
            Text = note.Text
        };
}
