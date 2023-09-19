using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrialTask.Notes.Domain.Repositories;
using TrialTask.Notes.Infrastructure.Repositories;

namespace TrialTask.Notes.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services.AddDbContext<NoteContext>(opt => opt.UseInMemoryDatabase("notes_db"));

            services.AddScoped<INoteRepository, NoteRepository>();

            return services;
        }
    }
}
