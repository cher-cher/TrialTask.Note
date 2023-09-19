using MediatR;
using TrialTask.Notes.Application.Notes.Commands;
using TrialTask.Notes.Domain.Entities.Notes;
using TrialTask.Notes.Domain.Exceptions;
using TrialTask.Notes.Domain.Repositories;

namespace TrialTask.Notes.Application.Notes.CommandHandlers
{
    public class DeleteNoteHandler : IRequestHandler<DeleteNote, Unit>
    {
        private readonly INoteRepository _repository;

        public DeleteNoteHandler(INoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteNote request, CancellationToken cancellationToken)
        {
            var note = await _repository.GetByIdNoteAsync(request.Id);

            if (note == null)
            {
                throw new NotFoundException($"{nameof(Note)} with {request.Id} not found.");
            }

            await _repository.DeleteNoteAsync(note);
            return Unit.Value;
        }
    }
}
