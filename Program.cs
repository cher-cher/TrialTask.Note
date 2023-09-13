using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrialTask.Notes.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services
   .AddEndpointsApiExplorer()
   .AddSwaggerGen(c => c.EnableAnnotations())
   .AddDbContext<NoteContext>(opt => opt.UseInMemoryDatabase("notes_db"))
   .AddControllers();

var server = builder.Build();

server.UseDeveloperExceptionPage()
    .UseSwagger()
    .UseSwaggerUI() 
    .UseAuthentication()
    .UseAuthorization();

server.MapControllers();

await server.RunAsync();