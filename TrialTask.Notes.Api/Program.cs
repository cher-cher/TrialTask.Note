using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TrialTask.Notes.Application;
using TrialTask.Notes.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services
   .AddEndpointsApiExplorer()
   .AddSwaggerGen(c => c.EnableAnnotations())
   .AddInfrastructure()
   .AddApplication()
   .AddControllers();

var server = builder.Build();

server.UseDeveloperExceptionPage()
    .UseSwagger()
    .UseSwaggerUI() 
    .UseAuthentication()
    .UseAuthorization();

server.MapControllers();

await server.RunAsync();