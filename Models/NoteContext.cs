using Microsoft.EntityFrameworkCore;

namespace TrialTask.Notes.Models;

public class NoteContext : DbContext
{
    public NoteContext(DbContextOptions<NoteContext> options)
        : base(options)
    {
    }

    public DbSet<Note> Notes { get; set; }
}