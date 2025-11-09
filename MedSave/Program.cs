using MedSave.Context;
using MedSave.Repositories;
using MedSave.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MedSaveContext>();

builder.Services.AddScoped<UsersSysRepository>();
builder.Services.AddScoped<ContactUserRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IUsersSysService, UsersSysService>();
builder.Services.AddScoped<IStockService, StockService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedSave API v1");
    c.RoutePrefix = "swagger";
});

app.MapControllers();

app.Run();