using TrialTask.Notes.Domain.Entities.Notes;

namespace TrialTask.Notes.Domain.Repositories
{
    public interface INoteRepository
    {
        Task<ICollection<Note>> GetAllNotesAsync();
        Task<Note> GetByIdNoteAsync(int id);
        Task<int> CreateNoteAsync(Note note);
        Task<Note> UpdateNoteAsync(Note note);
        Task DeleteNoteAsync(Note note);
    }
}
