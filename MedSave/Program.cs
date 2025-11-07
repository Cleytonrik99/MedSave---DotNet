using MedSave.Context;
using MedSave.Repositories;
using MedSave.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers (endpoints da API)
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext: a conexão já está no OnConfiguring
builder.Services.AddDbContext<MedSaveContext>();

// DI: repositórios e serviços
builder.Services.AddScoped<UsersSysRepository>();
builder.Services.AddScoped<ContactUserRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IUsersSysService, UsersSysService>();
builder.Services.AddScoped<IStockService, StockService>();

var app = builder.Build();

// Swagger UI sempre habilitado em dev; se quiser, pode deixar sempre
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedSave API v1");
    c.RoutePrefix = "swagger"; // URL final: /swagger
});

// (opcional) redireciona HTTP→HTTPS se você estiver usando https
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();