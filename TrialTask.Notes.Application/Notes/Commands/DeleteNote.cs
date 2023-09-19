using MediatR;

namespace TrialTask.Notes.Application.Notes.Commands
{
    public record DeleteNote(int Id) : IRequest<Unit>;

}
