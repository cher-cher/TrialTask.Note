using MediatR;
using TrialTask.Notes.Application.Notes.Queries;
using TrialTask.Notes.Domain.Entities.Notes;
using TrialTask.Notes.Domain.Repositories;

namespace TrialTask.Notes.Application.Notes.QueryHandlers
{
    public class GetAllNotesHandler : IRequestHandler<GetAllNotes, ICollection<Note>>
    {
        private readonly INoteRepository _noteRepository;

        public GetAllNotesHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<ICollection<Note>> Handle(GetAllNotes request, CancellationToken cancellationToken)
        {
            return await _noteRepository.GetAllNotesAsync();
        }
    }
}
