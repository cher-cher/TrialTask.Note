using MediatR;
using TrialTask.Notes.Application.Notes.Commands;
using TrialTask.Notes.Domain.Entities.Notes;
using TrialTask.Notes.Domain.Exceptions;
using TrialTask.Notes.Domain.Repositories;

namespace TrialTask.Notes.Application.Notes.CommandHandlers
{
    public class UpdateNoteHandler : IRequestHandler<UpdateNote, Note>
    {
        private readonly INoteRepository _repository;

        public UpdateNoteHandler(INoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Note> Handle(UpdateNote request, CancellationToken cancellationToken)
        {
            var note = await _repository.GetByIdNoteAsync(request.Id);

            if (note == null)
            {
                throw new NotFoundException($"{nameof(Note)} with {request.Id} not found.");
            }

            note.Title = request.Title;
            note.Text = request.Text;

            var result = await _repository.UpdateNoteAsync(note);
            return result;
        }
    }
}
