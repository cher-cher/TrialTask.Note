using Microsoft.EntityFrameworkCore;
using TrialTask.Notes.Domain.Entities.Notes;

namespace TrialTask.Notes.Infrastructure
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
