using MediatR;

namespace TrialTask.Notes.Application.Notes.Commands
{
    public record CreateNote(int Id, string Title, string Text, bool IsPrivate ) : IRequest<int>;
}
