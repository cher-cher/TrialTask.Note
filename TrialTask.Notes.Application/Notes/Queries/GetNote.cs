using MediatR;
using TrialTask.Notes.Domain.Entities.Notes;

namespace TrialTask.Notes.Application.Notes.Queries
{
    public record GetNote(int Id) : IRequest<Note>;
}
