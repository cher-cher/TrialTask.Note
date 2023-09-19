using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TrialTask.Notes.Application.Notes.CommandHandlers;
using TrialTask.Notes.Application.Notes.Commands;
using TrialTask.Notes.Application.Notes.Queries;
using TrialTask.Notes.Application.Notes.QueryHandlers;
using TrialTask.Notes.Domain.Entities.Notes;

namespace TrialTask.Notes.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });
            services.AddTransient<IRequestHandler<CreateNote, int>, CreateNoteHandler>();
            services.AddTransient<IRequestHandler<GetNote, Note>, GetNoteHandler>();
            services.AddTransient<IRequestHandler<UpdateNote, Note>, UpdateNoteHandler>();
            services.AddTransient<IRequestHandler<DeleteNote, Unit>, DeleteNoteHandler>();
            services.AddTransient<IRequestHandler<GetAllNotes, ICollection<Note>>, GetAllNotesHandler>();

            return services;
        }
    }
}
