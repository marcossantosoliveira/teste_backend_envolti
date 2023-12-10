using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TesteBackend.Domain.Interfaces.Repository;
using TesteBackend.Domain.Interfaces.Services;
using TesteBackend.Domain.Services.Services;
using TesteBackend.Infra.Context;
using TesteBackend.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BdContexto>(
    options => options.UseSqlServer(
        "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=tarefa;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));


builder.Services.AddScoped<ITarefaDomainService, TarefaService>();
builder.Services.AddScoped<ITarefaDomainRepository, TarefaRepository>();

var assembly = AppDomain.CurrentDomain.Load("TesteBackend.Application");
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddMediatR(assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
