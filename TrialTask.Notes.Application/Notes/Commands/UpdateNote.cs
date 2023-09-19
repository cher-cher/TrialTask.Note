using MediatR;
using TrialTask.Notes.Domain.Entities.Notes;

namespace TrialTask.Notes.Application.Notes.Commands
{
    public record UpdateNote(int Id, string Title, string Text) : IRequest<Note>;
}
