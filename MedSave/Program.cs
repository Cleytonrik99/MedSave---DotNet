using MedSave.Context;
using MedSave.Model;
using MedSave.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MedSave.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers (endpoints da API)
builder.Services.AddControllers();

// DbContext: como a conexão já está no OnConfiguring, não passe opções aqui
builder.Services.AddDbContext<MedSaveContext>();

// DI: repositórios e serviços
builder.Services.AddScoped<UsersSysRepository>();
builder.Services.AddScoped<ContactUserRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IUsersSysService, UsersSysService>();
builder.Services.AddScoped<IStockService, StockService>();

var app = builder.Build();

app.MapControllers();
app.Run();
