using MediatR;
using TrialTask.Notes.Domain.Entities.Notes;

namespace TrialTask.Notes.Application.Notes.Queries
{
    public class GetAllNotes : IRequest<ICollection<Note>>
    {
    }
}
