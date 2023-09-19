using Microsoft.EntityFrameworkCore;
using TrialTask.Notes.Domain.Entities.Notes;
using TrialTask.Notes.Domain.Repositories;

namespace TrialTask.Notes.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly NoteContext _context;

        public NoteRepository(NoteContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Note>> GetAllNotesAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<Note> GetByIdNoteAsync(int id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public async Task<int> CreateNoteAsync(Note note)
        {
            var result = new Note
            {
                Id = note.Id,
                Title = note.Title,
                Text = note.Text,
                IsPrivate = false
            };

            _context.Notes.Add(result);
            await _context.SaveChangesAsync();

            return result.Id;
        }

        public async Task<Note> UpdateNoteAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();

            return await GetByIdNoteAsync(note.Id);
        }

        public async Task DeleteNoteAsync(Note note)
        {
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }
    }
}
