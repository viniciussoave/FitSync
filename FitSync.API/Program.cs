using FitSync.Domain.Interfaces;
using FitSync.Infrastructure.Data;
using FitSync.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FitSyncDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<ITreinoRepository, TreinoRepository>();
builder.Services.AddScoped<IProgressoRepository, ProgressoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IExercicioRepository, ExercicioRepository>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

