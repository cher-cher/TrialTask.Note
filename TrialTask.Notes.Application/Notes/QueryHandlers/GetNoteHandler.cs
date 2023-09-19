using MediatR;
using TrialTask.Notes.Application.Notes.Queries;
using TrialTask.Notes.Domain.Entities.Notes;
using TrialTask.Notes.Domain.Repositories;

namespace TrialTask.Notes.Application.Notes.QueryHandlers
{
    public class GetNoteHandler : IRequestHandler<GetNote, Note>
    {
        private readonly INoteRepository _noteRepository;

        public GetNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Note> Handle(GetNote request, CancellationToken cancellationToken)
        {
            return await _noteRepository.GetByIdNoteAsync(request.Id);
        }
    }
}
