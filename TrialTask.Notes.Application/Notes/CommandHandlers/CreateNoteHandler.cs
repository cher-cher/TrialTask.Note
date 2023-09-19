using MediatR;
using TrialTask.Notes.Application.Notes.Commands;
using TrialTask.Notes.Domain.Entities.Notes;
using TrialTask.Notes.Domain.Repositories;

namespace TrialTask.Notes.Application.Notes.CommandHandlers
{
    public class CreateNoteHandler : IRequestHandler<CreateNote, int>
    {
        private readonly INoteRepository _noteRepository;

        public CreateNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<int> Handle(CreateNote request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                Id = request.Id,
                Title = request.Title,
                Text = request.Text,
                IsPrivate = false
            };

            await _noteRepository.CreateNoteAsync(note);
            return note.Id;
        }
    }
}
